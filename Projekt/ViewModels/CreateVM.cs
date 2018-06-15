using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.ViewModels
{
    public class CreateVM
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage ="Description must be less than 255 characters")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Deadline")]
        public DateTime LimitTime { get; set; }
    }
}