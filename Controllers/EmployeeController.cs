using EmployeeApp.Interfaces;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _emp;
        public EmployeeController(IEmployeeService emp)
        {
            _emp = emp;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _emp.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee Emp)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    isSucess = false,
                    Message = "Invalid Data",
                    Data = null
                });
            }
            var emp = await _emp.CreateEmployee(Emp);
            return Ok(new ApiResponse<Employee>
            {
                isSucess = true,
                Message = "Employee Added Successfully",
                Data = emp
            });
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GEtEmployeeById(int id)
        {
            try
            {
                var data = await _emp.GetEmployeeById(id);
                if (data == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        isSucess = false,
                        Message = "Employee Not Found",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<Employee>
                {
                    isSucess = true,
                    Message = "Employee Retrieved Successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var data = await _emp.DeleteEmployeeById(id);
                if (data == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        isSucess = false,
                        Message = "Employee Not Found",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<Employee>
                {
                    isSucess = true,
                    Message = "Employee Deleted Successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
