using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace TechOilFront.Controllers
{
	public class LoginController : Controller
	{

		private readonly IHttpClientFactory _httpClient;
		public LoginController(IHttpClientFactory httpClient) 
		{
			_httpClient = httpClient;
		}

		public IActionResult Login()
		{
			return View();
		}
		//Instalar Newtonsoft.JSON en el proyecto del front

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
			var baseApi = new BaseApi(_httpClient);
			var token = await baseApi.PostToApi("Login", login);
			var resultadoLogin = token as OkObjectResult;
			var resultadoObjeto = JsonConvert.DeserializeObject<Models.LoginModel>(resultadoLogin.Value.ToString());
				
			
			//Viewbag sirve para mandar atributos por sesion

			//return RedirectToAction("Index", "Home");
			return View("~/Views/Home/Index.cshtml", resultadoObjeto);
        }
    }
}
