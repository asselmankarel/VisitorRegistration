using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VisitorRegistration.Domain.Models;
using VisitorRegistration.Mvc.Models;

namespace VisitorRegistration.Mvc.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyViewModel>()
                .ForSourceMember(source => source.Employees, act => act.DoNotValidate());

            CreateMap<CompanyViewModel, Company>()
                .ForMember(dest => dest.Employees, act => act.Ignore());
        }
    }
}
