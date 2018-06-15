using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class ListVM
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Deadline")]
        public DateTime LimitTime { get; set; }

        public ListVM(TodoItem item)
        {
            ID = item.ID;
            Name = item.Name;
            Description = item.Description;
            LimitTime = item.LimitTime;
        }
    }
}