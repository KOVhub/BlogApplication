using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class PostModel
    {
        public PostModel()
        {

        }

        public PostModel(string title, string content, DateTime dateCreated)
        {
            Title = title;
            Content = content;
            DateCreated = dateCreated;
        }

        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}