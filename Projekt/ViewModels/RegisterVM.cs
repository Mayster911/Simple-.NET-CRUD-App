using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 30 characters long")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 30 characters long")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}