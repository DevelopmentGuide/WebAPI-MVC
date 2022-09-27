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

namespace Frontend.Controllers
{
    public class ErrorController : Controller
    {

        [Route("{*url}", Order = 999)]
        public IActionResult Error404()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            Response.StatusCode = 404;
            return View("Error404");
        }

        public IActionResult Error401()
        {
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            Response.StatusCode = 401;
            return View();
        }

        public async Task<IActionResult> NotLoggedIn()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Unexpected()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Load1()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Load2()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Load3()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Load4()
        {
            await Task.Delay(100);
            ViewBag.LogMessage = HttpContext.Session.GetString("UserName");
            return View();
        }

    }
}
