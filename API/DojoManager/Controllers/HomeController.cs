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
using RestSharp;
using RestSharp.Authenticators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using DojoManager.Classes;

namespace DojoManager.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient Client = new HttpClient();
        private static RestClient client = new RestClient();

        private static AppConfig _appConfig;
        public HomeController(IOptions<AppConfig> values)
        {
            _appConfig = values.Value;
        }


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

            // GetAToken().Wait();
            var test = GetMailGunConfig();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private static User GetMailGunConfig()
        {
            User data = new User();
            DateTime startDT = new DateTime();
            DateTime endDT = new DateTime();

            startDT = DateTime.Now;

            UserEngine un = new UserEngine();

            data = un.CreateUser(data);

            endDT = DateTime.Now;

            var timeTaken = (endDT - startDT);

            return data;
        }



        private static async Task GetAToken()
        {
            /*
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

            */

            /*
            Client.BaseAddress = new Uri("https://api.mailgun.net/v3/m.onthedojo.com");
            var request = new HttpRequestMessage(HttpMethod.Post, "/messages");
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("api", "key-371f1e8caa1e61a5067a3267dfb9e576"));
            keyValues.Add(new KeyValuePair<string, string>("from", "OnTheDojo.com <info@m.onthedojo.com>"));
            keyValues.Add(new KeyValuePair<string, string>("to", "richard@electro.tk"));
            keyValues.Add(new KeyValuePair<string, string>("subject", "Hello"));
            keyValues.Add(new KeyValuePair<string, string>("text", "testing mailgun mail!"));

            request.Content = new FormUrlEncodedContent(keyValues);

            var response = await Client.SendAsync(request);
            */


            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "key-371f1e8caa1e61a5067a3267dfb9e576");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxbc6895f9a9e3411a84d46e62a4c6dac3.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "OnTheDojo <mailgun@m.onthedojo.com>");
            request.AddParameter("to", "richard@electro.tk");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing Mailgun mail!");
            request.AddParameter("html", "<html>The email in HTML.<p>Lets click <a href='http://m.onthedojo.com'>this</a> link</p></html>");

            request.Method = Method.POST;

            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();

            RestRequestAsyncHandle handle = client.ExecuteAsync(
                        request, r => taskCompletion.SetResult(r));

            RestResponse response = (RestResponse)(await taskCompletion.Task);

            var mailgunResponse = JsonConvert.DeserializeObject<MailgunResponse>(response.Content);

            

        }
    }
}
