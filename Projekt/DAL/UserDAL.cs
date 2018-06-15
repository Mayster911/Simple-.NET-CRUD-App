using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Projekt.Models;

namespace Projekt.DAL
{
    public class UserDAL : DbContext
    {
        public DbSet<User> UserDB { get; set; } // przez ten atrybut będziemy odwoływać się do bazy danych

        public UserDAL() : base("DBLoc") // automatycznie powstanie baza danych jesli nie istnieje
        {

        }
    }
}