using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public class VisitorDataAccess : IVisitorDataAccess
    {
        private readonly VisitorRegistrationDbContext _dbContext;

        public VisitorDataAccess(VisitorRegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Visitor> GetById(int id)
        {
            var result = await _dbContext.Visitors.FindAsync(id);

            return result;
        }

        public async Task<Visitor> GetByEmail(string email)
        {
            var result = await _dbContext.Visitors.FirstOrDefaultAsync(v => v.Email == email.ToLower());

            return result;
        }

        public async Task<Visitor> Add(Visitor visitor)
        {
            _dbContext.Add(visitor);
            await _dbContext.SaveChangesAsync();
            var savedVisitor = await _dbContext.Visitors.FirstOrDefaultAsync(v => v.Email == visitor.Email);
            
            return savedVisitor;
        }
    }
}
