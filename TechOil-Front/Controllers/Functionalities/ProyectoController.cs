using Microsoft.AspNetCore.Mvc;

namespace TechOilFront.Controllers.Functionalities;

public class ProyectoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Proyecto/Proyecto.cshtml");
    }
}