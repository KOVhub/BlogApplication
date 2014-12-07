using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class RecentPostsModel
    {
        public RecentPostsModel()
        {

        }

        public RecentPostsModel(string postTitle, string postDateCreated)
        {
            PostTitle = postTitle;
            PostDateCreated = postDateCreated;
        }

        public string PostTitle { get; set; }
        public string PostDateCreated { get; set; }
    }
}