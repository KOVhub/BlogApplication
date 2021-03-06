﻿using MyBlog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class AddCommentModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Comment")]
        [StringLength(100, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthMaxTemplate")]
        public string Content { get; set; }
    }
}
