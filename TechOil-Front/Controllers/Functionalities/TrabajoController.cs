using Microsoft.AspNetCore.Mvc;

namespace TechOilFront.Controllers.Functionalities;

public class TrabajoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Trabajo/Index.cshtml");
    }
}