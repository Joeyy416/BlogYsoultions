using SimpleBloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBloggingSystem.Controllers
{
    public class ArticleController : Controller
    {
        // GET: the Articles and preview them
        public ActionResult GetArticles()
        {
            //Check the authentication of the user
            var token = "";
            if(Session["token"] != null)
            {
                token = Session["token"].ToString();
            }

            if(token == "")
            {
                return RedirectToAction("Login", "Authentication");
            }

            //Getting an instance of the DB
            var context = new BlogContext();
            var userId = Session["UserId"].ToString();
            User user = context.Users.SingleOrDefault(u=> u.Id.ToString() == userId);

            var auth = new AuthenticationController().Validate(token,user.Name);
            bool isAUth = (auth.StatusCode == System.Net.HttpStatusCode.OK);

            if (!isAUth)
            {
                return RedirectToAction("Login", "Authentication");
            }
            

            //Getting the articles list
            var articles= context.Articles.ToList();
            
                
            
            var categories = context.Categories.ToList();

            ViewBag.articles = articles;
            ViewBag.categories = categories;

            //returning the list of the articles to the view
            return View(articles);
        }

        
        //Adding articles
        //GET: Add article view

        public ActionResult AddArticle()
        {
            //check the user before getting the view of adding new article
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (Session["UserRole"].ToString() != "Admin")
            {
                return RedirectToAction("GetArticle", "Article");
            }
            //Getting an instance of the DB
            var context = new BlogContext();

            //Getting the categories list
            var categories = context.Categories.ToList();

            //List<SelectListItem> item = categories.ConvertAll(a =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = a.Name.ToString(),
            //        Value = a
            //    };
            //});
            
            ViewBag.Category = new SelectList(categories, "Id", "Name"); 
            ViewBag.CategoriesList = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Article model)
        {
            //Get instance of the DB
            var context = new BlogContext();

            //Create a new instance of article
            var newlyInsertedArticle = new Article();

            var UserId = Session["UserId"];
            newlyInsertedArticle.ArticleBody = model.ArticleBody;
            newlyInsertedArticle.ArticleOwner = context.Users.Single(x => x.Id.ToString() == UserId.ToString());
            newlyInsertedArticle.PublishingDate = DateTime.Today;
            
            newlyInsertedArticle.Category = context.Categories.Single(c=>c.Id== model.Category.Id);

            context.Articles.Add(newlyInsertedArticle);
            context.SaveChanges();
            return RedirectToAction("GetArticles");
        }

        //Editing Article
        //Get the view of editing article
        [HttpGet]
        public ActionResult EditArticle(int ArticleId)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (Session["UserRole"].ToString() != "Admin" && Session["UserRole"].ToString() != "Moderator")
            {
                return RedirectToAction("GetArticles", "Article");
            }
            //Create instance of the DB
            var context = new BlogContext();

            var article = context.Articles.First(a=>a.Id == ArticleId);
            ViewBag.Category = new SelectList(context.Categories.ToList(),"Id","Name", article.Category);

            return View(article);
        }
        [HttpPost]
        public ActionResult EditArticle(Article model)
        {
            //Create instance of the DB
            var context = new BlogContext();

            var article = context.Articles.First(a => a.Id == model.Id);

            article.ArticleBody = model.ArticleBody;
            article.Category = context.Categories.First(c => c.Id == model.Category.Id);

            context.SaveChanges();
            return RedirectToAction("GetArticles");
        }

    }
}