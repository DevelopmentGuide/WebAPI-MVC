using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Frontend.Controllers
{
    public class NewUserController : Controller
    {

        private static HttpClient http_Client = new HttpClient();

        public NewUserController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await http_Client.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/administration");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var user = new List<Users>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    user = JsonConvert.DeserializeObject<List<Users>>(content);
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }


        //CREATE
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            await Task.Delay(1000);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users new_user)
        {
            var serializedProductToCreate = JsonConvert.SerializeObject(new_user);
            var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/administration");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedProductToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await http_Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CreateMessage", "Messages");
            }
            else
            {
                return RedirectToAction("Load1", "Error");
            }
        }





        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await http_Client.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            var edit_user = new Users();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                edit_user = JsonConvert.DeserializeObject<Users>(content);
            }
            return View(edit_user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users edit_user)
        {
            if (ModelState.IsValid)
            {
                //http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // http_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var serializedProductToEdit = JsonConvert.SerializeObject(edit_user);
                var request = new HttpRequestMessage(HttpMethod.Put, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/{edit_user.UserId}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToEdit);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http_Client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Users", "NewUser");
                }
                else
                {
                    return RedirectToAction("Load1", "Error");
                }
            }
            else
                return RedirectToAction("Load1", "Error");
        }






        //EDIT BY EMAIL
        [HttpGet]
        public async Task<IActionResult> EditByMail(string id)
        {
            var response = await http_Client.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/email/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            var edit_user = new Users();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                edit_user = JsonConvert.DeserializeObject<Users>(content);
            }
            return View(edit_user);
        }

        [HttpPost]
        public async Task<IActionResult> EditByMail(Users edit_user)
        {
            if (ModelState.IsValid)
            {
                //http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // http_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var serializedProductToEdit = JsonConvert.SerializeObject(edit_user);
                var request = new HttpRequestMessage(HttpMethod.Put, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/email/{edit_user.UserId}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToEdit);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http_Client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("EditMessage", "Messages");
                }
                else
                {
                    return RedirectToAction("Load1", "Error");
                }
            }
            else
                return RedirectToAction("Load1", "Error");
        }





        //DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await http_Client.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            var del_user = new Users();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                del_user = JsonConvert.DeserializeObject<Users>(content);
            }
            return View(del_user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Users del_user)
        {
            if (ModelState.IsValid)
            {
                //http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                http_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var serializedProductToDelete = JsonConvert.SerializeObject(del_user);
                var request = new HttpRequestMessage(HttpMethod.Delete, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/{del_user.UserId}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToDelete);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http_Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Users", "NewUser");
                }
                else
                {
                    return RedirectToAction("Load1", "Error");
                }
            }
            else
                return RedirectToAction("Load1", "Error");
        }




        //DELETEBYMAIL
        [HttpGet]
        public async Task<IActionResult> DeleteByMail(string id)
        {
            var response = await http_Client.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/email/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            var del_user = new Users();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                del_user = JsonConvert.DeserializeObject<Users>(content);
            }
            return View(del_user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteByMail(Users del_user)
        {
            if (ModelState.IsValid)
            {
                //http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var serializedProductToDelete = JsonConvert.SerializeObject(del_user);
                var request = new HttpRequestMessage(HttpMethod.Delete, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/administration/email/{del_user.Email}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToDelete);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http_Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DeleteMessage", "Messages");
                }
                else
                {
                    return RedirectToAction("Load1", "Error");
                }
            }
            else
                return RedirectToAction("Load1", "Error");
        }

    }
}
