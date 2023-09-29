using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechOilFront.Controllers.Functionalities;

[Authorize]
public class UsuarioController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Usuario/Index.cshtml");
    }
}