using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public interface IVisitorDataAccess
    {
        Task<Visitor> GetById(int id);
        Task<Visitor> GetByEmail(string email);
        Task<Visitor> Add(Visitor visitor);
    }
}