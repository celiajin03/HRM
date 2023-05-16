using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        
        // http:localhost/api/Employees
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var Employees = await _EmployeeService.GetAllEmployees();

            if (!Employees.Any())
            {
                // no Employees exists, then 404
                return NotFound(new { error = "No Employees found, please try later" });
            }
            return Ok(Employees);
        }
        
        // http:localhost/api/Employees/1
        [HttpGet]
        [Route("{id:int}", Name="GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var Employee = await _EmployeeService.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound(new { errorMessage = "No Employee found for this id" });
            }

            return Ok(Employee);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var Employee = await _EmployeeService.AddEmployee(model);
            return CreatedAtAction("GetEmployeeDetails", new { controller = "Employee", id = Employee }, "Employee Created");
        }
    }
}
