using MyBlog.Models;
using MyBlog.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication
{
    public class CurrentUserService
    {
        public static string CurrentUserKey = "CurrentUserKey";

        public UserModel GetCurentUser()
        {
            if (HttpContext.Current == null)
            {
                throw new InvalidOperationException();
            }

            return HttpContext.Current.Items[CurrentUserKey] as UserModel;
        }
    }
}