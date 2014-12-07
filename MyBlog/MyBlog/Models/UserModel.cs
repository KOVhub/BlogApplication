using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        public UserModel(int userId, string name, string email, string password, string userRole)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            UserRole = userRole;
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}