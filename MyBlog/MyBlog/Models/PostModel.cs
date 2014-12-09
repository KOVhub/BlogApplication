using MyBlog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Title")]
        [StringLength(100, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthMaxTemplate")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Content")]
        [AllowHtml]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}