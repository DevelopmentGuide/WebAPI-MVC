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
    public class UserController : Controller
    {
        private readonly static HttpClient httpClient = new();
        public UserController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            if (user.Email == null || user.Password == null)
            {
                return View("Login");
            }
            var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/authenticate");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user.Email}:{user.Password}")));

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var token = response.Content.ReadAsStringAsync().Result;
                JWT jwt = JsonConvert.DeserializeObject<JWT>(token);
                HttpContext.Session.SetString("token", jwt.Token);
                HttpContext.Session.SetString("UserName", user.Email);
                HttpContext.Session.SetString("UserId", user.UserId.ToString());

                ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

                return RedirectToAction("HomePage", "User");
            }
            ViewBag.Message = "Invalid Username or Password";
            return View("Login");
        }

        public async Task<IActionResult> ControlPannel()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }


        public async Task<IActionResult> HomePage()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }


        public async Task<IActionResult> MyAccount()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
