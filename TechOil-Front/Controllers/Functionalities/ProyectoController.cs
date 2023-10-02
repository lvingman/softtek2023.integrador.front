using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOilFront.ViewModels;

namespace TechOilFront.Controllers.Functionalities;


[Authorize]
public class ProyectoController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public ProyectoController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Proyecto/Proyecto.cshtml");
    }

    public async Task<IActionResult> ProyectosAddPartial([FromBody] ProyectoDto proyecto)
    {
        var proyectosViewModel = new ProyectoViewModel(); //Todo: Que es un viewModel?
        if (proyecto != null)
        {
            proyectosViewModel = proyecto;
        }

        return PartialView("~/Views/Functionalities/Proyecto/Partial/ProyectosAddPartial.cshtml", proyectosViewModel);
    }
    
    public IActionResult BajaLogicaProyecto(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var proyectos = baseApi.SoftDeleteToApi("Proyecto", id, token);
        return View("~/Views/Functionalities/Proyecto/Proyecto.cshtml");
    }
    
    public IActionResult GuardarProyecto(ProyectoDto proyecto)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);

        var submitButton = Request.Form["submitButton"];
        if (submitButton == "Registrar")
        {
            var proyectos = baseApi.PostToApi("Proyecto", proyecto, token);
        }
        else if (submitButton == "Modificar")
        {
        
                var proyectos = baseApi.PutToApi("Proyecto", proyecto.Id, proyecto, token);
           
        
        }
        return View("~/Views/Functionalities/Proyecto/Proyecto.cshtml");
    }
    

    //No se va a usar
    public IActionResult BajaFisicaProyecto(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var proyectos = baseApi.HardDeleteToApi("Proyecto", id, token);
        return View("~/Views/Functionalities/Proyecto/Proyecto.cshtml");
    }
    
    
}