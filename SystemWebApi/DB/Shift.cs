using System;
using System.Collections.Generic;

namespace SystemWebApi.DB;

public partial class Shift
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string Description { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
