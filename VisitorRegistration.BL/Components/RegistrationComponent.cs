using System;
using System.Threading.Tasks;
using VisitorRegistration.BL.Requests;
using VisitorRegistration.BL.Responses;
using VisitorRegistration.DataAccess.Services;
using VisitorRegistration.Domain.Models;

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

        public ResponseBase CheckIn(CheckInRequest request)
        {
            var visitor = _visitorDataAccess.GetById(request.VisitorId).Result;
            var company = _companyDataAccess.GetById(request.CompanyId).Result;
            var employee = _employeeDataAccess.GetById(request.EmployeeId).Result;
            var response = new CheckInResponse();

            if (visitor == null || company == null || employee == null)
            {
                response.AddErrorMessage("Invalid request");
                return response;
            }
            
            if (!_registrationDataAccess.OpenRegistrationForCurrentDayForVisitor(visitor.Id).Result)  
            {
                response.AddErrorMessage("Already checked in");
                return response;
            }

            if (_registrationDataAccess.add(new Registration { Visitor = visitor, Employee = employee, StartOfVisit = request.StartOfVisit }).Result)
                    return response;
            
            return response;
        }

        private bool VisitorAlreadyCheckedIn(Visitor visitor)
        {
            
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> CheckOut(CheckOutRequest request)
        {
            return await Task.FromResult(new CheckOutResponse());
        }

    }
}
