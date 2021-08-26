using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public interface IRegistrationDataAccess
    {
        Task<bool> add(Registration registration);

        Task<bool> update(Registration registration);

        Task<Registration> GetById(int id);

        Task<Registration> GetOpenRegistrationForVisitor(int visitorId);

        Task<bool> OpenRegistrationForCurrentDayForVisitor(int visitorId);

        Task<List<Registration>> GetAllOpenRegistrationsForCurrentDay();

        Task<List<Registration>> GetAllRegistrationsForCurrentDay();

    }
}