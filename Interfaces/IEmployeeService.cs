using EmployeeApp.Models;

namespace EmployeeApp.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> CreateEmployee(Employee obj);
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> DeleteEmployeeById(int id);
    }
}
