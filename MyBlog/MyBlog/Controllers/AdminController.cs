using Microsoft.Security.Application;
using MyBlog.Models;
using MyBlog.Repository.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult CreateArticle()
        {
            return View(new PostModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public ActionResult CreateArticle(PostModel model)
        {
            if (model.Title != null && model.Content != null && ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    model.Content = Sanitizer.GetSafeHtmlFragment(model.Content);  

                    var post = db.Posts.Where(p => p.Title == model.Title).FirstOrDefault();
                    if (post == null)
                    {
                        db.Posts.Add(new Post { Title = model.Title, Content = model.Content, DateCreated = DateTime.Now });
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home", new { title = model.Title });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Статья с таким Заголовком уже существует. Измените название (заголовок) статьи");
                        return View(model); 
                    }
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult ChangeArticle(string title)
        {
            using (var db = new BlogDbContext()) 
            {
                if (title != null)
                {
                    var post = db.Posts.Where(p => p.Title == title).FirstOrDefault();
                    if (post != null)
                    {
                        var postModel = new PostModel(post.Title, post.Content, post.DateCreated);
                        return View("ChangeArticle", postModel);
                    }
                    else
                    {
                        return RedirectToAction("ListArticles", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("ListArticles", "Home");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public ActionResult ChangeArticle(PostModel model)
        {
            if (model.Title != null && model.Content != null && ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var postChange = db.Posts.Where(p => p.DateCreated == model.DateCreated).FirstOrDefault();
                    
                    if (postChange == null)
                    {
                        return RedirectToAction("ListArticles", "Home");
                    }                   
                    else
                    {
                        var postSame = db.Posts.Where(p => p.Title == model.Title).FirstOrDefault();

                        if (postSame != null && postChange.PostId != postSame.PostId)
                        {
                            ModelState.AddModelError("", "Статья с таким Заголовком уже существует. Измените название (заголовок) статьи");
                            return View(model);                       
                        }
                        else
                        {
                            postChange.Title = model.Title;
                            postChange.Content = Sanitizer.GetSafeHtmlFragment(model.Content);
                            db.Entry(postChange).State = EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("Index", "Home", new { title = model.Title });
                        }
                    }
                }
            }
            return View(model);          
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult RemoveArticle(string title)
        {
            if (title != null)
            {
                using (var db = new BlogDbContext())
                {
                    var post = db.Posts.Where(p => p.Title == title).FirstOrDefault();
                    if (post != null)
                    {
                        db.Posts.Remove(post);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("ListArticles", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult RemoveComment(int? id, string title)
        {
            if (id != null && title != null)
            {
                using (var db = new BlogDbContext())
                {
                    var comment = db.Comments.Find(id);
                    if (comment != null)
                    {
                        db.Comments.Remove(comment);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { title = title } );
        }
    }
}                   