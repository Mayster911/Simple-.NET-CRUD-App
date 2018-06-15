using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.ViewModels
{
    public class DetailsVM
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Deadline")]
        public DateTime LimitTime { get; set; }

        public DetailsVM()
        {

        }

        public DetailsVM(TodoItem item)
        {
            ID = item.ID;
            Name = item.Name;
            Description = item.Description;
            CreationTime = item.CreationTime;
            LimitTime = item.LimitTime;
        }
    }
}