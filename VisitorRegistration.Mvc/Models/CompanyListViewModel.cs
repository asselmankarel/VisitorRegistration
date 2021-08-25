using AutoMapper;
using System.Collections.Generic;
using VisitorRegistration.DataAccess.Services;

namespace VisitorRegistration.Mvc.Models
{
    public class CompanyListViewModel
    {

        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IMapper _mapper;

        public List<CompanyViewModel> Companies { get; private set; }
        public int CompanyId { get; set; }

        public CompanyListViewModel(ICompanyDataAccess companyDataAccess, IMapper mapper)
        {
            _companyDataAccess = companyDataAccess;
            _mapper = mapper;
            LoadCompanies();
        }


        private async void LoadCompanies()
        {
            var companies = await _companyDataAccess.GetAll();
            Companies = new List<CompanyViewModel>();

            foreach (var company in companies)
            {                
                Companies.Add(_mapper.Map<CompanyViewModel>(company));
            }
        }
       

    }
}
