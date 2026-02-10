namespace EmployeeApp.Models
{
    public class ApiResponse<T>
    {
        public bool isSucess { get; set; }
        public string Message { get; set; } = null!;
        public T? Data { get; set; }
    }
}
