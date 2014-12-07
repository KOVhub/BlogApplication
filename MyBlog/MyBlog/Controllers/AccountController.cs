using MyBlog.Models;
using MyBlog.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        private void CookieService(User user)
        {
            var ticket = new FormsAuthenticationTicket(2, user.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, String.Empty);
            var entryptTicket = FormsAuthentication.Encrypt(ticket);

            var cookieAuth = new HttpCookie(FormsAuthentication.FormsCookieName, entryptTicket);
            cookieAuth.Expires = DateTime.Now.AddMinutes(30);

            Response.Cookies.Add(cookieAuth);            
        }
      
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    if (user != null)
                    {
                        CookieService(user);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверно указан Email или Пароль");
                    }
                }
            }
            return View(model);           
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var user = db.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                    if (user == null)
                    {
                        db.Users.Add(new User { Name = model.Name, Email = model.Email, Password = model.Password, UserRole = "User" });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                        if (user != null)
                        {
                            CookieService(user);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователь с таким Email уже существует");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}