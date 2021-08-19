﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess.Services
{
    public interface IEmployeeDataAccess
    {
        Task<List<Employee>> GetByCompanyId(int companyId);
    }
}