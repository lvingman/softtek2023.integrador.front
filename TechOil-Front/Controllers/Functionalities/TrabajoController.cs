using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOilFront.ViewModels;

namespace TechOilFront.Controllers.Functionalities;

[Authorize]
public class TrabajoController : Controller
{
    // GET
    private readonly IHttpClientFactory _httpClient;

    public TrabajoController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Trabajo/Trabajo.cshtml");
    }

    public async Task<IActionResult> TrabajosAddPartial([FromBody] TrabajoDto trabajo)
    {
        var trabajosViewModel = new TrabajoViewModel(); //Todo: Que es un viewModel?
        if (trabajo != null)
        {
            trabajosViewModel = trabajo;
        }

        return PartialView("~/Views/Functionalities/Trabajo/Partial/TrabajosAddPartial.cshtml", trabajosViewModel);
    }
    
    public IActionResult BajaLogicaTrabajo(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var trabajos = baseApi.SoftDeleteToApi("Trabajo", id, token);
        return View("~/Views/Functionalities/Trabajo/Trabajo.cshtml");
    }
    
    public IActionResult GuardarTrabajo(TrabajoDto trabajo)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        
        var submitButton = Request.Form["submitButton"];
        if (submitButton == "Registrar")
        {
            var trabajos = baseApi.PostToApi("Trabajo", trabajo, token);
        }
        else if (submitButton == "Modificar")
        {
        
            var trabajos = baseApi.PutToApi("Trabajo", trabajo.Id, trabajo, token);
           
        
        }
        return View("~/Views/Functionalities/Trabajo/Trabajo.cshtml");
    }
    


    
}