using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class EditVM
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters long")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Deadline")]
        public DateTime LimitTime { get; set; }

        public EditVM()
        {

        }

        public EditVM(TodoItem item)
        {
            ID = item.ID;
            Name = item.Name;
            Description = item.Description;
            LimitTime = item.LimitTime;
        }
    }
}