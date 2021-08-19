using System;
using System.Collections.Generic;
using VisitorRegistration.DataAccess;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;
using Xunit;

namespace VisitorRegistration.Test
{
    public class EmployeeDataAccessTests
    {
        private VisitorRegistrationDbContext _dbContext { get; set; }
        private IEmployeeDataAccess _employeeDataAccess { get; set; }
        public EmployeeDataAccessTests()
        {
            var connectionString = Environment.GetEnvironmentVariable("VisitorRegistrationConnectionString");
            _dbContext = new VisitorRegistrationDbContext(connectionString);
            _employeeDataAccess = new EmployeeDataAccess(_dbContext);
        }

        [Fact]
        public void GetByCompanyId_ShouldReturnListOfEmployees()
        {
            var list = _employeeDataAccess.GetByCompanyId(1).Result;

            Assert.True(list.GetType() == typeof(List<Employee>));
        }

        [Fact]
        public void GetByCompanyId_ShouldReturnListWithAtLeastOneEmployee()
        {
            var list = _employeeDataAccess.GetByCompanyId(1).Result;
            
            Assert.True(list.Count > 0);
        }
    }
}
