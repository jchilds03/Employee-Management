using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeController(IEmployeeRepository repository)
		{
			_employeeRepository = repository;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsyc()
		{
            return Ok(await _employeeRepository.GetAllAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(int id)
		{
			var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
			{
				return NotFound();
			}

            return Ok(employee);
        }

		[HttpPost]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
		{
			await _employeeRepository.AddEmployeeAsync(employee);
			return CreatedAtAction(nameof(GetEmployeeById), new {id = employee.Id}, employee);
        }

		[HttpPut("{id}")]
		public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
		{
			if(id != employee.Id)
			{
				return BadRequest();
			}

			await _employeeRepository.UpdateEmplooyeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployeeById(int id)
		{
			await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
	}
}

