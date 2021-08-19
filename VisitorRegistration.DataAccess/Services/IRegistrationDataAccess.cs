using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public interface IRegistrationDataAccess
    {
        Task<Registration> GetById(int id);

        Task<Registration> GetCurrentDayOpenRegistrationByVisitorId(int visitorId);

        Task<List<Registration>> GetAllOpenRegistrationsForCurrentDay();

        Task<List<Registration>> GetAllRegistrationsForCurrentDay();

    }
}