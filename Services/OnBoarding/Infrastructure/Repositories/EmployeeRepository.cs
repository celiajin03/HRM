using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
	{
		private OnBoardingDbContext _dbContext;
		public EmployeeRepository(OnBoardingDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Employee>> GetAllEmployees()
		{
			var Employees = await _dbContext.Employees.ToListAsync();
			return Employees;
		}

		public async Task<Employee> GetEmployeeById(int id)
		{
			var Employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
			return Employee;
		}
	}
}

