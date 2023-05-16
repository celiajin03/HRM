using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
		Task<List<EmployeeResponseModel>> GetAllEmployees();
		
		Task<EmployeeResponseModel> GetEmployeeById(int id);

		Task<int> AddEmployee(EmployeeRequestModel model);
	}
}

