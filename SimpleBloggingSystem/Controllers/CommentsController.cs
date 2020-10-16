using SimpleBloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBloggingSystem.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Add Comments view
        public ActionResult AddComment(int ArticleId)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ArticleId = ArticleId;
            return View();
        }


        //Adding comment method
        [HttpPost]
        public ActionResult AddComment(Comment model,int articleId)
        {
            var context = new BlogContext();

            var newComment = new Comment();
            newComment.CommentBody = model.CommentBody;
            newComment.CommentDate = DateTime.Now;

            var UserId = Session["UserId"];
            
            newComment.CommentOwner = context.Users.First(x=>x.Id.ToString() == UserId.ToString());
            newComment.IsApproved = false;
            newComment.Article = context.Articles.First(x => x.Id == articleId);

            context.Comments.Add(newComment);

            context.SaveChanges();

            return RedirectToAction("GetArticles","Article");
        }


        [HttpGet]
        public ActionResult ApproveComment(int CommentId)
        {
            var context = new BlogContext();
            var comment = context.Comments.First(x=>x.Id == CommentId);

            comment.IsApproved = true;

            context.SaveChanges();

            return RedirectToAction("GetArticles","Article");
        }

        [HttpGet]
        public ActionResult DisapproveComment(int CommentId)
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            if (Session["UserRole"].ToString() != "Admin" && Session["UserRole"].ToString() != "Moderator")
            {
                return RedirectToAction("GetArticles", "Article");
            }
            var context = new BlogContext();
            var comment = context.Comments.First(x => x.Id == CommentId);

            return View(comment);
        }

        [HttpPost]
        public ActionResult DisapproveComment(Comment model)
        {
            

            var context = new BlogContext();
            var comment = context.Comments.First(x => x.Id == model.Id);
                
            comment.reasonForDisApproval = model.reasonForDisApproval;
            comment.IsApproved = false;

            context.SaveChanges();
            return RedirectToAction("GetArticles","Article");
        }
    }
}