using SimpleBloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.Net.Http;
//using System.Web.Http;

namespace SimpleBloggingSystem.Controllers
{
    public class AuthenticationController : Controller
    {

        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var context = new BlogContext();
            var userFromDB = context.Users.SingleOrDefault(u=>u.Name == user.Name);

            if (userFromDB == null)
            {
                return Json(new { StatusCode = HttpStatusCode.NotFound, HttpMessage = "User Not Found"});

                //return new HttpResponseMessage { StatusCode= HttpStatusCode.NotFound , ReasonPhrase = "User not found"};
            }
            Boolean credentials = userFromDB.Password.Equals(user.Password);

            if (!credentials)
                return Json(new { StatusCode = HttpStatusCode.Forbidden, HttpMessage = "User and password don't match" });
            //return new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden , ReasonPhrase="User and password don't match"};


            Session["UserId"] = userFromDB.Id;
            Session["UserRole"] = userFromDB.Role;
            Session["token"] = TokenManagement.GenerateToken(user.Name);

            return Json(new { StatusCode = HttpStatusCode.OK, HttpMessage = TokenManagement.GenerateToken(user.Name) });
            //return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = TokenManagement.GenerateToken(user.Name) };
        }

        [HttpGet]
        public HttpResponseMessage Validate(string token, string username)
        {
            var context = new BlogContext();

            User user = context.Users.SingleOrDefault(u=>u.Name == username);

            if (user == null)
                //return Json(new { StatusCode = HttpStatusCode.NotFound, HttpMessage = "The user was not found"});
                return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, ReasonPhrase = "The user was not found" };
            string tokenUsername = TokenManagement.ValidateToken(token);
            if (username.Equals(tokenUsername))
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK};
            //return  Json ( new { StatusCode= HttpStatusCode.OK });
            return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            //return  Json ( new { StatusCode= HttpStatusCode.OK });
        }
    }
}