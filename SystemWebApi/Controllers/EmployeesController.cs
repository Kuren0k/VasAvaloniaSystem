using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemWebApi.DB;
using SystemWebApi.DTO.EmployeeDTO;

namespace SystemWebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
[Authorize]
public class EmployeesController : Controller
{
    private readonly VasAvaloniaContext _context;

    public EmployeesController(VasAvaloniaContext context)
    {
        _context = context;
    }
    
    [HttpGet("login")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        var employees = await _context.Employees
            .Where(e => e.IsActive == true)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Position = e.Position,
                HireDate = e.HireDate,
                IsActive = e.IsActive
            })
            .ToListAsync();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
    {
        var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Position = e.Position,
                HireDate = e.HireDate,
                IsActive = e.IsActive
            })
            .FirstOrDefaultAsync();

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee(CreateEmployeeDto createDto)
    {
        var existingUser = await _context.Credentials
            .FirstOrDefaultAsync(c => c.Username == createDto.Username);
            
        if (existingUser != null)
        {
            return BadRequest("Username already exists");
        }
        
        var employee = new Employee
        {
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Position = createDto.Position,
            HireDate = createDto.HireDate,
            IsActive = createDto.IsActive
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
            
        var credential = new Credential
        {
            EmployeeId = employee.Id,
            Username = createDto.Username,
            PasswordHash = createDto.Password,
            RoleId = createDto.RoleId
        };

        await _context.Credentials.AddAsync(credential);
        await _context.SaveChangesAsync();

        var employeeDto = new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Position = employee.Position,
            HireDate = employee.HireDate,
            IsActive = employee.IsActive
        };
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employeeDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateDto)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        employee.FirstName = updateDto.FirstName;
        employee.LastName = updateDto.LastName;
        employee.Position = updateDto.Position;
        employee.HireDate = updateDto.HireDate;
        employee.IsActive = updateDto.IsActive;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}