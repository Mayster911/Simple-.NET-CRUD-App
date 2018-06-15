using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using Projekt.ViewModels;

namespace Projekt.Models
{
    public class TodoItem
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LimitTime { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(CreateVM vm, int id)
        {
            UserID = id;
            Name = vm.Name;
            Description = vm.Description;
            CreationTime = DateTime.Now;
            LimitTime = vm.LimitTime;
        }
    }
}