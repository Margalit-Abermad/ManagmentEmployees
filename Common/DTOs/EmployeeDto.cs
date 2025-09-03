namespace Common.DTOs
{
    public class EmployeeDto
    {
        public int Employeeid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly Hiredate { get; set; }
        public string Jobtitle { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? Departmentid { get; set; }
        public string? DepartmentName { get; set; }
    }
}