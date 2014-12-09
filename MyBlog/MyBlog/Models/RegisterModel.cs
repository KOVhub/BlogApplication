using MyBlog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Name")]
        [StringLength(50, ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "StringLengthMaxTemplate")]
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

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}