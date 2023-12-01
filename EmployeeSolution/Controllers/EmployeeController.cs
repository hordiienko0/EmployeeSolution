using EmployeeSolution.Repositories;
using EmployeeSolution.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeeService;

        public EmployeeController(IEmployeesService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("EnableEmployee/{id}")]
        public IActionResult EnableEmployee(int id, bool enable)
        {
            _employeeService.EnableEmployee(id, enable);
            return Ok();
        }

        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}