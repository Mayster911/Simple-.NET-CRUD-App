using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string userName { get; set; }
        public string pwHash { get; set; }
    }
}