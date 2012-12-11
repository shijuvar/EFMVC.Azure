using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EFMVC.Domain.Commands;
using EFMVC.Web.ViewModels;

namespace EFMVC.Web.Mappers
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoryFormModel, CreateOrUpdateCategoryCommand>();
            Mapper.CreateMap<ExpenseFormModel, CreateOrUpdateExpenseCommand>();
            Mapper.CreateMap<UserFormModel, UserRegisterCommand>(); 
        }
    }
}