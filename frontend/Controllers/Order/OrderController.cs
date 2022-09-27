using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Frontend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Frontend.Controllers
{

    public class OrderController : Controller
    {
        private static HttpClient httpOrderClient = new HttpClient();
        public OrderController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }



        //CREATE
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            await Task.Delay(1000);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(Order orderNo)
        {

            var serializedProductToCreate = JsonConvert.SerializeObject(orderNo);
            var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/Order");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedProductToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpOrderClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("OrderMessage", "Messages");
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }

        }



        //INDEX
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            httpOrderClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpOrderClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpOrderClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/Order/Order");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var orderNo = new List<Order>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    orderNo = JsonConvert.DeserializeObject<List<Order>>(content);
                }
                return View(orderNo);
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }
        }


        //MyOrder
        [HttpGet]
        public async Task<IActionResult> MyOrder(string email)
        {
            httpOrderClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpOrderClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpOrderClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/Order/Email/admin@localhost");
            var content = await response.Content.ReadAsStringAsync();

            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");

            if (response.IsSuccessStatusCode)
            {
                var orderNo = new List<Order>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    orderNo = JsonConvert.DeserializeObject<List<Order>>(content);
                }
                return View(orderNo);
            }
            else
            {
                return RedirectToAction("Load4", "Error");
            }
        }

    }
}
