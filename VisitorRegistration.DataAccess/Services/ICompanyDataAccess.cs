using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public interface ICompanyDataAccess
    {
        Task<Company> GetById(int id);

        Task<List<Company>> GetAll();

    }
}
