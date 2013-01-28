using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using EFMVC.CommandProcessor.Command;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Infrastructure;
using EFMVC.Data.Repositories;
using EFMVC.Web.Core.Authentication;
using System.Web.Http;
using EFMVC.Web.Mappers;
using EFMVC.Web.Caching;
namespace EFMVC.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }    
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();          
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterType<AzureCacheProvider>().As<ICacheProvider>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();          
            var services = Assembly.Load("EFMVC.Domain");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerHttpRequest();
            builder.RegisterType<DefaultFormsAuthentication>().As<IFormsAuthentication>().InstancePerHttpRequest();
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();                  
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }        
    }
}
