using EmployeeApp.Data;
using EmployeeApp.Interfaces;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> CreateEmployee(Employee obj)
        {
            await _context.Employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var Empdata = await _context.Employees.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (Empdata == null)
            {

            }
            return Empdata;
        }
        public async Task<Employee> DeleteEmployeeById(int id)
        {
            var Empdata = await _context.Employees.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (Empdata == null)
            {
                return null;
            }
            _context.Employees.Remove(Empdata);
            await _context.SaveChangesAsync();
            return Empdata;
        }
    }
}
