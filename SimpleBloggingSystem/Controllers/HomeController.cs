using SimpleBloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBloggingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["UserId"] == null)
            return View();

            return RedirectToAction("GetArticles","Article");
        }

        public ActionResult LoginAsAdmin()
        {
            //Create DB instance
            var context = new BlogContext();
            User loggedUser = context.Users.First(u=>u.Role == UserRole.Admin);

            Session["UserId"] = loggedUser.Id;
            Session["UserRole"] = loggedUser.Role;

            return RedirectToAction("GetArticles","Article");
        }
        public ActionResult LoginAsModerator()
        {
            //Create DB instance
            var context = new BlogContext();
            User loggedUser = context.Users.First(u => u.Role == UserRole.Moderator);

            Session["UserId"] = loggedUser.Id;
            Session["UserRole"] = loggedUser.Role;

            return RedirectToAction("GetArticles", "Article");
        }
        public ActionResult LoginAsVisitor()
        {
            //Create DB instance
            var context = new BlogContext();
            User loggedUser = context.Users.First(u => u.Role == UserRole.Visitor);

            Session["UserId"] = loggedUser.Id;
            Session["UserRole"] = loggedUser.Role;

            return RedirectToAction("GetArticles", "Article");
        }


        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Authentication");
        }
    }
}