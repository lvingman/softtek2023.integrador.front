using Microsoft.AspNetCore.Mvc;

namespace TechOilFront.Controllers.Functionalities;

public class ServicioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Servicio/Servicio.cshtml");
    }
}