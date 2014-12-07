using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class CommentModel
    {
        public CommentModel()
        {

        }

        public CommentModel(int commentId, string content, DateTime dateAdded, UserModel user)
        {
            CommentId = commentId;
            Content = content;
            DateAdded = dateAdded;
            User = user;
        }

        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public UserModel User { get; set; }
    }
}