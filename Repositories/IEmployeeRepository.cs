using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
	public interface IEmployeeRepository
	{
		//Read Functions
		Task<IEnumerable<Employee>> GetAllAsync();
		Task<Employee?> GetByIdAsync(int id);

		//Update Function
		Task AddEmployeeAsync(Employee employee);
		Task UpdateEmplooyeeAsync(Employee employee);

		//Delete Function
		Task DeleteEmployeeAsync(int id);
	}
}

