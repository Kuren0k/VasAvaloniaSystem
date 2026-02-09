namespace SystemWebApi.DTO.EmployeeDTO;

public class UpdateEmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
}