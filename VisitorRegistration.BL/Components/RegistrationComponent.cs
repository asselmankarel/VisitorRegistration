using System;
using System.Threading.Tasks;
using VisitorRegistration.BL.Requests;
using VisitorRegistration.BL.Responses;
using VisitorRegistration.DataAccess.Services;

namespace VisitorRegistration.BL.Components
{
    public class RegistrationComponent
    {
        private readonly IRegistrationDataAccess _registrationDataAccess;
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IVisitorDataAccess _visitorDataAccess;

        public RegistrationComponent(
            IRegistrationDataAccess registrationDataAccess,
            IEmployeeDataAccess employeeDataAccess,
            ICompanyDataAccess companyDataAccess,
            IVisitorDataAccess visitorDataAccess)
        {
            _registrationDataAccess = registrationDataAccess;
            _employeeDataAccess = employeeDataAccess;
            _companyDataAccess = companyDataAccess;
            _visitorDataAccess = visitorDataAccess;
        }

        public async Task<ResponseBase> CheckIn(CheckInRequest request)
        {
            return await Task.FromResult(new CheckInResponse());
        }

        public async Task<ResponseBase> CheckOut(CheckOutRequest request)
        {
            return await Task.FromResult(new CheckOutResponse());
        }

    }
}
