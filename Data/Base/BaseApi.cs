using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Data.DTOs;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        //Todo: Agregar PutToApi, DeleteToApi, y GetToApy


        //Genera funcion para Login/Consumir Datos con post
        public async Task<IActionResult> PostToApi(string controllerName, object model, string token = "")
        {
            try
            {
                //Se almacena url de la api en client
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }
                
                //Se appendea el nombre del controller al final, posiblemente mas cosas
                var response = await client.PostAsJsonAsync(controllerName, model);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        public async Task<IActionResult> PutToApi(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }

                var functionality = controllerName + "/" + ((UsuarioDto)model).Id;
                
                var response = await client.PutAsJsonAsync(functionality, model);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        
        public async Task<IActionResult> SoftDeleteToApi(string controllerName, int id, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }
                
                var apiUrl = $"{controllerName}/sd/{id}";
                
                var response = await client.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        
        public async Task<IActionResult> HardDeleteToApi(string controllerName, int id, string token = "")
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }
                
                var apiUrl = $"{controllerName}/hd/{id}";
                
                var response = await client.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        
        
        
    }
}
