using Microsoft.AspNetCore.Mvc;

namespace SystemWebApi.Controllers;

public class ShiftsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}