using MyBlog.Models;
using MyBlog.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication
{
    public class UserAccountDao
    {
        public UserModel GetUserAccount(string UserEmail)
        {
            using (var db = new BlogDbContext())
            {
                var user = db.Users.Where(u => u.Email == UserEmail).FirstOrDefault();
                if (user != null)
                {
                    return new UserModel()
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        UserRole = user.UserRole
                    };
                }
                else 
                { 
                    return null; 
                }
            }
        }
    }
}