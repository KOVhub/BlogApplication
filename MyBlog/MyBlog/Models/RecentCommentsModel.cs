using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class RecentCommentsModel
    {
        public RecentCommentsModel()
        {

        }

        public RecentCommentsModel(string content, DateTime dateAdded)
        {
            Content = content;
            DateAdded = dateAdded;
        }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }
    }
}