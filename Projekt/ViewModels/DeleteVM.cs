using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class DeleteVM
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Deadline")]
        public DateTime LimitTime { get; set; }

        public DeleteVM(TodoItem todoItem)
        {
            Name = todoItem.Name;
            Description = todoItem.Description;
            CreationTime = todoItem.CreationTime;
            LimitTime = todoItem.LimitTime;
        }

        public DeleteVM()
        {

        }
    }
}