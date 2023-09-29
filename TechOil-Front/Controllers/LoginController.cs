﻿using System.Net;
using System.Security.Claims;
using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TechOilFront.ViewModels;

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

			var identity = new ClaimsIdentity
			(
				CookieAuthenticationDefaults.AuthenticationScheme,
				ClaimTypes.Name,
				ClaimTypes.Role
			);
			Claim claimNombre = new(ClaimTypes.Name, resultadoObjeto.Nombre);
			Claim claimRol = new(ClaimTypes.Role, "Administrador");
			Claim claimEmail = new(ClaimTypes.Email, resultadoObjeto.Email);
			
			identity.AddClaim(claimNombre);
			identity.AddClaim(claimRol);
			identity.AddClaim(claimEmail);

			var claimPrincipal = new ClaimsPrincipal(identity);
			
			await HttpContext.SignInAsync
			(
				CookieAuthenticationDefaults.AuthenticationScheme,
				claimPrincipal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.Now.AddHours(1),
				}
			);

			var homeViewModel = new HomeViewModel();
			homeViewModel.Token = resultadoObjeto.Token;
			
			//return RedirectToAction("Index", "Home");
			return View("~/Views/Home/Index.cshtml", resultadoObjeto);
        }

        public async Task<IActionResult> CerrarSesion()
        {
	        await HttpContext.SignOutAsync
	        (
		        CookieAuthenticationDefaults.AuthenticationScheme
	        );
	        return RedirectToAction("Login", "Login");
        }
        
    }
}
