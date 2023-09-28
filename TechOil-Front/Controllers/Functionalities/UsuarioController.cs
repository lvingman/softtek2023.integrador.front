using Microsoft.AspNetCore.Mvc;

namespace TechOilFront.Controllers.Functionalities;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Usuario/Index.cshtml");
    }
}