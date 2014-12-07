using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Repository.Database
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}