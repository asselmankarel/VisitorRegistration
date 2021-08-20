using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Registration>> GetAllRegistrationsForCurrentDay()
        {
            var date = DateTime.Now;
            var result = await _dbContext.Registrations
                .Where(r =>
                    r.StartOfVisit.Year == date.Year &&
                    r.StartOfVisit.DayOfYear == date.DayOfYear)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Add(Registration registration)
        {
            await _dbContext.Registrations.AddAsync(registration);
            var numberOfSavedChanges = await _dbContext.SaveChangesAsync();
     
            return numberOfSavedChanges == 1;
        }

        public Task<bool> add(Registration registration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> update(Registration registration)
        {
            throw new NotImplementedException();
        }
    }
}
