using MyBlog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Comment")]
        [StringLength(100, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthMaxTemplate")]
        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public UserModel User { get; set; }
    }
}