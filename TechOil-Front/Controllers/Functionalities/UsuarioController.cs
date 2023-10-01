using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOilFront.ViewModels;


namespace TechOilFront.Controllers.Functionalities;

[Authorize]
public class UsuarioController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public UsuarioController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IActionResult Index()
    {
        return View("~/Views/Functionalities/Usuario/Usuario.cshtml");
    }

    public async Task<IActionResult> UsuariosAddPartial([FromBody] UsuarioDto usuario)
    {
        var usuariosViewModel = new UsuarioViewModel(); //Todo: Que es un viewModel?
        if (usuario != null)
        {
            usuariosViewModel = usuario;
        }

        return PartialView("~/Views/Functionalities/Usuario/Partial/UsuariosAddPartial.cshtml", usuariosViewModel);
    }
    
    public IActionResult BajaLogicaUsuario(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var usuarios = baseApi.SoftDeleteToApi("Usuario", id, token);
        return View("~/Views/Functionalities/Usuario/Usuario.cshtml");
    }
    
    public IActionResult GuardarUsuario(UsuarioDto usuario)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);

        var submitButton = Request.Form["submitButton"];
        if (submitButton == "Registrar")
        {
            var usuarios = baseApi.PostToApi("Usuario", usuario, token);
        }
        else if (submitButton == "Modificar")
        {
        
                var usuarios = baseApi.PutToApi("Usuario", usuario, token);
           
        
        }
        return View("~/Views/Functionalities/Usuario/Usuario.cshtml");
    }

    //no se porque hice esto 🥴🥴🥴🥴🥴🥴🥴🥴🥴🥴🥴🥴🥴 momento cruelty
    public IActionResult ModificarUsuario(UsuarioDto usuario, int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var usuarios = baseApi.PutToApi("Usuario", usuario, token);
        return View("~/Views/Functionalities/Usuario/Usuario.cshtml");
    }
    


    public IActionResult BajaFisicaUsuario(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient);
        var usuarios = baseApi.HardDeleteToApi("Usuario", id, token);
        return View("~/Views/Functionalities/Usuario/Usuario.cshtml");
    }
    
    
}