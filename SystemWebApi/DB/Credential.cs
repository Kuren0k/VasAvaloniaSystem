using System;
using System.Collections.Generic;

namespace SystemWebApi.DB;

public partial class Credential
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
