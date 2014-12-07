using MyBlog.Repository;
using MyBlog.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {

        }

        public ArticleModel(PostModel post, ICollection<CommentModel> comments)
        {
            Post = post;
            Comments = comments;
        }

        public PostModel Post { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

        public AddCommentModel NewComment { get; set; }

    }
}