namespace Common.DTOs
{
    public class EmployeeProjectDto
    {
        public int Employeeid { get; set; }
        public int Projectid { get; set; }
        public DateOnly? Assigneddate { get; set; }
        public string? EmployeeName { get; set; }
        public string? ProjectName { get; set; }
    }
}