using Microsoft.AspNetCore.Mvc;

namespace SystemWebApi.Controllers;

public class EmployeesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}