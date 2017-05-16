using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DojoManager.Data;
using DojoManager.Models;

namespace DojoManager.Controllers
{
    public class HomeController : Controller
    {
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

        //[Route("api/UserList")]
        //[HttpGet]
        //public IActionResult UserList()
        //{
        //    DBManager context = 
        //    List<User> users = new List<User>();
        //    users = 
        //    return new JsonResult(context.GetAllUsers());
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
