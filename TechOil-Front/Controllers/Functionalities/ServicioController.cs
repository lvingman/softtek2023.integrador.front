using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOilFront.ViewModels;

namespace TechOilFront.Controllers.Functionalities;


[Authorize]
public class ServicioController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public ServicioController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Servicio/Servicio.cshtml");
    }

    public async Task<IActionResult> ServiciosAddPartial([FromBody] ServicioDto servicio)
    {
        var serviciosViewModel = new ServicioViewModel(); //Todo: Que es un viewModel?
        if (servicio != null)
        {
            serviciosViewModel = servicio;
        }

        return PartialView("~/Views/Functionalities/Servicio/Partial/ServiciosAddPartial.cshtml", serviciosViewModel);
    }
    
    public IActionResult BajaLogicaServicio(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var servicios = baseApi.SoftDeleteToApi("Servicio", id, token);
        return View("~/Views/Functionalities/Servicio/Servicio.cshtml");
    }
    
    public IActionResult GuardarServicio(ServicioDto servicio)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);

        var submitButton = Request.Form["submitButton"];
        if (submitButton == "Registrar")
        {
            servicio.Estado = true;
            var servicios = baseApi.PostToApi("Servicio", servicio, token);
        }
        else if (submitButton == "Modificar")
        {
        
                var servicios = baseApi.PutToApi("Servicio", servicio.Id, servicio, token);
           
        
        }
        return View("~/Views/Functionalities/Servicio/Servicio.cshtml");
    }
    


    
    
}