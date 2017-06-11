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
using Microsoft.AspNetCore.Http;
using DojoManager.TokenProvider;
using System.Net;

namespace DojoManager.Controllers
{
    public class UserController : Controller
    {
        private static HttpClient Client = new HttpClient();
        private static RestClient client = new RestClient();

        private static AppConfig _appConfig;
        public UserController(IOptions<AppConfig> values)
        {
            _appConfig = values.Value;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("api/user/create")]
        [HttpPost]
        //[Authorize]
        public IActionResult create(User model)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                UserEngine un = new UserEngine();
                // make sure the user does not exist already
                if (!un.DoesUserExist(model.Email))
                {

                    // create the user
                    model.Status = 1;
                    model.EmailConfirmed = 0;

                    model = un.CreateUser(model);
                    response.Status = "SUCCESS";
                    response.Message = "User created";
                    

                }
                else
                {
                    response.Status = "ERROR";
                    response.Message = "Email already exists";
                }
            }
            catch(Exception ex)
            {
                response.Status = "ERROR";
                response.Message = string.Format("ERROR: {0}", ex.Message);
            }

            return Json(new {
                    Status = response.Status,
                    Message = response.Message,
                    Data = model
            });
        }

        [Route("api/user/whoami")]
        [HttpPost]
        [Authorize]
        public IActionResult WhoAmI(string email)
        {
            ResponseObject response = new ResponseObject();
            User model = new User();
            model.Email = email;
            try
            {
                UserEngine un = new UserEngine();
                // make sure the user exists
                if (un.DoesUserExist(model.Email))
                {

                    model = un.GetUserDetailsFromEmail(model);
                    response.Status = "SUCCESS";
                    response.Message = "User data";
                    model.Password = "";
                    model.Salt = "";


                }
                else
                {
                    response.Status = "ERROR";
                    response.Message = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                response.Status = "ERROR";
                response.Message = string.Format("ERROR: {0}", ex.Message);
            }

            return Json(new
            {
                Status = response.Status,
                Message = response.Message,
                Data = model
            });
        }

        [Route("api/user/GetListOfAllowedPermissions")]
        [HttpPost]
        [Authorize]
        public IActionResult GetListOfAllowedPermissions(int userId)
        {
            ResponseObject response = new ResponseObject();
            List<PermissionFunction> permissions = new List<PermissionFunction>();
            try
            {
                UserEngine un = new UserEngine();
                // get list of user permissions

                permissions = un.GetListOfAllowedPermissions(userId);
                response.Status = "SUCCESS";
                response.Message = "";
            }
            catch (Exception ex)
            {
                response.Status = "ERROR";
                response.Message = string.Format("ERROR: {0}", ex.Message);
            }

            return Json(new
            {
                Status = response.Status,
                Message = response.Message,
                Data = permissions
            });
        }


    }
}
