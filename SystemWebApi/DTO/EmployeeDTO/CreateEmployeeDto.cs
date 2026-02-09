namespace SystemWebApi.DTO.EmployeeDTO;

public class CreateEmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
}