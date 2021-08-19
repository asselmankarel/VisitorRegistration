using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public class RegistrationDataAccess : IRegistrationDataAccess
    {
        private readonly VisitorRegistrationDbContext _dbContext;

        public RegistrationDataAccess(VisitorRegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Registration> GetById(int id)
        {
            var result =  await _dbContext.Registrations.FindAsync(id);

            return result;
        }

        public async Task<Registration> GetCurrentDayOpenRegistrationByVisitorId(int visitorId)
        {
            var date = DateTime.Now;
            var result = await _dbContext.Registrations
                .Where(r =>
                    r.StartOfVisit.DayOfYear == date.DayOfYear &&
                    r.StartOfVisit.Year == date.Year &&
                    r.Visitor.Id == visitorId &&
                    r.EndOfVisit == null)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Registration>> GetAllOpenRegistrationsForCurrentDay()
        {
            var date = DateTime.Now;
            var result = await _dbContext.Registrations.Where(r =>
                r.EndOfVisit == null &&
                r.StartOfVisit.Year == date.Year &&
                r.StartOfVisit.DayOfYear == date.DayOfYear)
                .ToListAsync();

            return result;
        }

        public Task<List<Registration>> GetAllRegistrationsForCurrentDay()
        {
            throw new NotImplementedException();
        }
    }
}
