using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly VisitorRegistrationDbContext _dbContext;
        public EmployeeDataAccess(VisitorRegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetByCompanyId(int companyId)
        {
            return await _dbContext.Employees.Where(e => e.Company.Id == companyId).ToListAsync();
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _dbContext.Employees.FindAsync(employeeId);
        }
    }
}
