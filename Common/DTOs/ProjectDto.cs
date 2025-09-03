namespace Common.DTOs
{
    public class ProjectDto
    {
        public int Projectid { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Startdate { get; set; }
        public DateOnly? Enddate { get; set; }
        public int EmployeeCount { get; set; }
    }
}