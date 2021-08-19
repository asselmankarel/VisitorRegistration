using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public class CompanyDataAccess : ICompanyDataAccess
    {
        private readonly VisitorRegistrationDbContext _dbContext;

        public CompanyDataAccess(VisitorRegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAll()
        {
            var companies = await _dbContext.Companies.OrderBy(c => c.Name).ToListAsync();

            return companies;
        }

        public async Task<Company> GetById(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);

            return company;
        }
    }
}
