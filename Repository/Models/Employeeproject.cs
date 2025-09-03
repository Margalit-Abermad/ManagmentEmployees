using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Employeeproject
{
    public int Employeeid { get; set; }

    public int Projectid { get; set; }

    public DateOnly? Assigneddate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
