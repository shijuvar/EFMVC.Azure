using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EFMVC.Model;
using EFMVC.Web.ViewModels;

namespace EFMVC.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryFormModel>();
            Mapper.CreateMap<Expense, ExpenseFormModel>().ForMember(dest => dest.Category, opt => opt.Ignore());

        }
    }
}