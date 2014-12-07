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
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [EmailAddress]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "Password")]
        [StringLength(100, ErrorMessage = " {0} должен быть по крайне мере {2} символов в длину", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesValidation), ErrorMessageResourceName = "RequiredTemplate")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(DisplayNamesValidation), Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}