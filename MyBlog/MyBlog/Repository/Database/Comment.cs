using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Repository.Database
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int PostId { get; set; }
        
        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}