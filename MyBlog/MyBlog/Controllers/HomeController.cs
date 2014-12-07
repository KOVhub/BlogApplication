using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Authentication;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(string title)
        {
            using (var db = new BlogDbContext())
            {
                var post = (title == null) ? db.Posts.OrderByDescending(p => p.PostId).FirstOrDefault() : 
                    db.Posts.Where(p => p.Title == title).FirstOrDefault();
                if (post != null)
                {
                    var postModel = new PostModel(post.Title, post.Content, post.DateCreated);

                    var commentCollectionModel = new Collection<CommentModel>();
                    if (post.Comments != null && post.Comments.Any())
                    {
                        foreach (var item in post.Comments)
                        {
                            var userModel = new UserModel(item.User.UserId, item.User.Name, item.User.Email, item.User.Password, item.User.UserRole);
                            commentCollectionModel.Add(new CommentModel(item.CommentId, item.Content, item.DateAdded, userModel));      
                        }
                    }

                    var cus = new CurrentUserService();
                    var user = cus.GetCurentUser();

                    if (user != null && user.UserRole == "ADMIN")
                    {
                        return View("IndexAdmin", new ArticleModel(postModel, commentCollectionModel));
                    }
                    else
                    {
                        return View("Index", new ArticleModel(postModel, commentCollectionModel));
                    }

                }
                else
                {
                    return View("HttpError","Errors");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(ArticleModel model, string title)
        {
            if (model.NewComment != null && ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var post = (title == null) ? db.Posts.OrderByDescending(p => p.PostId).FirstOrDefault() : 
                        db.Posts.Where(p => p.Title == title).FirstOrDefault();
                    if (post != null)
                    {
                        var cus = new CurrentUserService();
                        var user = cus.GetCurentUser();

                        db.Comments.Add(new Comment { Content = model.NewComment.Content, PostId = post.PostId, UserId = user.UserId, DateAdded = DateTime.Now });
                        db.SaveChanges();
                    } 
                }
                return RedirectToAction("Index", new { title = title });
            }
            else 
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ListArticles(int? page)
        {
            using (var db = new BlogDbContext())
            {
                var posts = db.Posts.ToList().OrderByDescending(d => d.DateCreated);
                var postsModel = new Collection<PostModel>();
                
                foreach (var item in posts)
                {
                    postsModel.Add(new PostModel(item.Title, item.Content, item.DateCreated));
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                
                var cus = new CurrentUserService();
                var user = cus.GetCurentUser();

                if (user != null && user.UserRole == "ADMIN")
                {
                    return View("ListArticlesAdmin", postsModel.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View("ListArticlesUser", postsModel.ToPagedList(pageNumber, pageSize));
                }
            }
        }
       
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

    }
}