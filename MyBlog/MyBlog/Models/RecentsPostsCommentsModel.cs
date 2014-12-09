using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class RecentsPostsCommentsModel
    {
        public RecentsPostsCommentsModel()
        {

        }

        public RecentsPostsCommentsModel(ICollection<PostModel> recentPosts, ICollection<RecentCommentModel> recentComments)
        {
            RecentPosts = recentPosts;
            RecentComments = recentComments;
        }

        public ICollection<PostModel> RecentPosts { get; set; }
        public ICollection<RecentCommentModel> RecentComments { get; set; }
    }
}