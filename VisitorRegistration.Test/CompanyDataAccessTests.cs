using System;
using System.Collections.Generic;
using VisitorRegistration.DataAccess;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;
using Xunit;

namespace VisitorRegistration.Test
{
    public class CompanyDataAccessTests
    {
        private VisitorRegistrationDbContext _dbContext { get; set; }
        private ICompanyDataAccess _companyDataAccess { get; set; }

        public CompanyDataAccessTests()
        {
            var connectionString = Environment.GetEnvironmentVariable("VisitorRegistrationConnectionString");
            _dbContext = new VisitorRegistrationDbContext(connectionString);
            _companyDataAccess = new CompanyDataAccess(_dbContext);
        }

        [Fact]
        public void GetAll_ShouldReturnListOfCompanies()
        {
            var companies = _companyDataAccess.GetAll();
            var result = companies.Result;

            Assert.True(result.GetType() == typeof(List<Company>));
        }

        [Fact]
        public void GetAll_ShouldReturnAtLeastOneCompany()
        {
            var companies = _companyDataAccess.GetAll();
            var result = companies.Result;

            Assert.True(result.Count > 0 );
        }
    }
}