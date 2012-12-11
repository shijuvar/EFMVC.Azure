using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using EFMVC.CommandProcessor.Command;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Infrastructure;
using EFMVC.Data.Repositories;
using EFMVC.Web.Core.Authentication;
using System.Web.Http;
namespace EFMVC.Web.API
{
    public static class Bootstrapper
    {
        public static void Run()
        {
           
            SetAutofacWebAPIServices();
        }       
        private static void SetAutofacWebAPIServices()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();          
            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerApiRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerApiRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerApiRequest();
            builder.RegisterAssemblyTypes(typeof(CategoryRepository)
                .Assembly).Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerApiRequest();
            var services = Assembly.Load("EFMVC.Domain");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerApiRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerApiRequest();
            var container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;           
        }
    }
}
