using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorRegistration.DataAccess.Services;
using AutoMapper;

namespace VisitorRegistration.Mvc.Models
{
    public class CompanyListViewModel
    {

        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IMapper _mapper;

        public CompanyListViewModel(ICompanyDataAccess companyDataAccess, IMapper mapper)
        {
            _companyDataAccess = companyDataAccess;
            _mapper = mapper;
            LoadCompanies();
        }

        public List<CompanyViewModel> Companies { get; private set; }

        private async void LoadCompanies()
        {
            var companies = await _companyDataAccess.GetAll();

            foreach(var company in companies)
            {
                Companies.Add(_mapper.Map<CompanyViewModel>(company));
            }
        }
       

    }
}
