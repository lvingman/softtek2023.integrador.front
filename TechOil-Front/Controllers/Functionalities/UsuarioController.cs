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
        return View("~/Views/Functionalities/Usuario/Index.cshtml");
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
    
    public IActionResult GuardarUsuario(UsuarioDto usuario)
    {
        var token = HttpContext.Session.GetString("Token");
        var baseApi = new BaseApi(_httpClient); //Todo: Que hace esto?
        var usuarios = baseApi.PostToApi("Usuario", usuario, token);
        return View("~/Views/Functionalities/Usuario/Index.cshtml");
        
    }
    
    
    
}