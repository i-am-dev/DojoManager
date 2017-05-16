using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DojoManager.Data;
using DojoManager.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace DojoManager.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient Client = new HttpClient();


        public IActionResult Index()
        {
            return View();
        }

        [Route("api/Test")]
        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return new JsonResult("testing");
        }

        [Route("api/Test1")]
        [HttpGet]
        public IActionResult Test1()
        {
            return new JsonResult("testing");
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            GetAToken().Wait();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }



        private static async Task GetAToken()
        {
            UserParamater user = new UserParamater();
            user.Username = "TEST";
            user.Password = "TEST123";

            Client.BaseAddress = new Uri("http://localhost:59857");
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/token");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", user.Username));
            keyValues.Add(new KeyValuePair<string, string>("password", user.Password));

            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await Client.SendAsync(request);

            //var msg = await stringPost;
        }
    }
}
