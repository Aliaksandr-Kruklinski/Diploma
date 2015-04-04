using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Models
{
    public class LogInModel
    {
        [Required]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage="Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class SignUpModel
    {
        [Display(Name = "User name")]
        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Password question")]
        [HiddenInput(DisplayValue = false)]
        public string PasswordQuestion { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Password answer")]
        [HiddenInput(DisplayValue = false)]
        public string PasswordAnswer { get; set; }
    }

    public class ActivateModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Display(Name = "Very secret code")]
        [HiddenInput(DisplayValue = false)]
        public string SecretCode { get; set; }
    }
}