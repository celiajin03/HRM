using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task< List<EmployeeResponseModel>> GetAllEmployees()
        {
            var Employees = await _EmployeeRepository.GetAllEmployees();
            
            var EmployeeResponseModel = new List<EmployeeResponseModel>();
            foreach (var Employee in Employees)
            {
                EmployeeResponseModel.Add(new EmployeeResponseModel
                {
                    Id = Employee.Id, 
                    Address = Employee.Address, 
                    Email = Employee.Email, 
                    EmployeeIdentityId = Employee.EmployeeIdentityId, 
                    EmployeeStatusId = Employee.EmployeeStatusId, 
                    EndDate = Employee.EndDate,
                    FirstName = Employee.FirstName,
                    HireDate = Employee.HireDate,
                    LastName = Employee.LastName,
                    MiddleName = Employee.MiddleName,
                    SSN = Employee.SSN
                });
            }
            return EmployeeResponseModel;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var Employee = await _EmployeeRepository.GetEmployeeById(id);
            if (Employee == null)
            {
                return null;
            }
            var EmployeeResponseModel = new EmployeeResponseModel
            {
                Id = Employee.Id, 
                Address = Employee.Address, 
                Email = Employee.Email, 
                EmployeeIdentityId = Employee.EmployeeIdentityId, 
                EmployeeStatusId = Employee.EmployeeStatusId, 
                EndDate = Employee.EndDate,
                FirstName = Employee.FirstName,
                HireDate = Employee.HireDate,
                LastName = Employee.LastName,
                MiddleName = Employee.MiddleName,
                SSN = Employee.SSN
            };
            return EmployeeResponseModel;
        }

        public async Task<int> AddEmployee(EmployeeRequestModel model)
        {
            var EmployeeEntity = new Employee
            {
                Address = model.Address, 
                Email = model.Email, 
                EmployeeIdentityId = Guid.NewGuid(), 
                EmployeeStatusId = model.EmployeeStatusId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                EndDate = model.EndDate,
                HireDate = model.HireDate,
                MiddleName = model.MiddleName,
            };

            var Employee = await _EmployeeRepository.AddSync(EmployeeEntity);
            return Employee.Id;
        }
    }
}

