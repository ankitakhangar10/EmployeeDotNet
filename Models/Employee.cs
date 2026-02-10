using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Department { get; set; } = null!;

        [Range(18, 60)]
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateOnly DOB { get; set; }
    }
}
