namespace SimpleBloggingSystem.Migrations
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleBloggingSystem.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleBloggingSystem.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Adding Categories
            context.Categories.AddOrUpdate(c=>c.Name,new Category
            {
                Name="Health"
            });
            context.Categories.AddOrUpdate(c => c.Name, new Category
            {
                Name = "Politics"
            });
            context.Categories.AddOrUpdate(c => c.Name, new Category
            {
                Name = "Sports"
            });
            context.Categories.AddOrUpdate(c => c.Name, new Category
            {
                Name = "Art"
            });


            //Adding Users
            context.Users.AddOrUpdate(u=>u.Name, new User
            {
                Name="Hazem",
                Email="admin@admin.com",
                Password="admin",
                Role=UserRole.Admin
            });
            context.Users.AddOrUpdate(u => u.Name, new User
            {
                Name = "Hatem",
                Email = "another@admin.com",
                Password = "admin",
                Role = UserRole.Admin
            });
            context.Users.AddOrUpdate(u => u.Name, new User
            {
                Name = "Ali",
                Email = "moderator@Mod.com",
                Password = "moderator",
                Role = UserRole.Moderator
            });
            context.Users.AddOrUpdate(u => u.Name, new User
            {
                Name = "Alia",
                Email = "another@Mod.com",
                Password = "moderator",
                Role = UserRole.Moderator
            });
            context.Users.AddOrUpdate(u => u.Name, new User
            {
                Name = "Farid",
                Email = "visitor@visit.com",
                Password = "visitor",
                Role = UserRole.Visitor
            });
            context.Users.AddOrUpdate(u => u.Name, new User
            {
                Name = "Farida",
                Email = "another@visit.com",
                Password = "visitor",
                Role = UserRole.Visitor
            });

            ////Adding Articles
            //context.Articles.AddOrUpdate(a => a.Id, new Article
            //{
            //    PublishingDate = DateTime.Today,
            //    ArticleBody = "Sport is too good way to play football. too much energetic",
            //    ArticleOwner = context.Users.Single(u => u.Id == 1),
            //    Category = context.Categories.Single(c => c.Name == "Sports"),
               
            //});
            //context.Articles.AddOrUpdate(a => a.Id, new Article
            //{
            //    PublishingDate = DateTime.Today,
            //    ArticleBody = "Art is too good way to Understand how people think. too much senstaions",
            //    ArticleOwner = context.Users.Single(u => u.Id == 1),
            //    Category = context.Categories.Single(c => c.Name == "Art"),

            //});
            ////Adding Comments
            //context.Comments.AddOrUpdate(c => c.Id, new Comment
            //{
            //    CommentDate = DateTime.Today,
            //    CommentBody = "That's right",
            //    CommentOwner = context.Users.Single(u => u.Id == 4),
            //    Article = context.Articles.Single(a => a.Id == 1),
            //    IsApproved = false
            //});
            //context.Comments.AddOrUpdate(c=>c.Id, new Comment
            //{
            //    CommentDate = DateTime.Today,
            //    CommentBody = "That's wrong btw",
            //    CommentOwner = context.Users.Single(u => u.Id == 5),
            //    Article = context.Articles.Single(a => a.Id == 1),
            //    IsApproved = false
            //});                    
                 
            //context.SaveChanges();
        }
    }
}
