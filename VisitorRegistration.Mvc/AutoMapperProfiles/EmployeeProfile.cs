using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VisitorRegistration.Domain.Models;
using VisitorRegistration.Mvc.Models;

namespace VisitorRegistration.Mvc.AutoMapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ForMember(dest => dest.Registrations, opt => opt.Ignore());

            CreateMap<Employee, EmployeeViewModel>()
                .ForSourceMember(source => source.Company, opt => opt.DoNotValidate());
        }
    }
}
