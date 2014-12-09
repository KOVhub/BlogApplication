using MyBlog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        public UserModel(int userId, string name, string email, string password, string userRole)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            UserRole = userRole;
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [EmailAddress]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "EmailRegularTemplate")]
        [StringLength(100, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthMaxTemplate")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Password")]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthTemplate")]
        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}