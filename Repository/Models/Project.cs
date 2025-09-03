using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public virtual ICollection<Employeeproject> Employeeprojects { get; set; } = new List<Employeeproject>();
}
