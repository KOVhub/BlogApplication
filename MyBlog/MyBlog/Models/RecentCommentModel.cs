using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class RecentCommentModel
    {
        public RecentCommentModel()
        {

        }

        public RecentCommentModel(string content, DateTime dateAdded, string postTitle)
        {
            Content = content;
            DateAdded = dateAdded;
            PostTitle = postTitle;
        }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public string PostTitle { get; set; }
    }
}