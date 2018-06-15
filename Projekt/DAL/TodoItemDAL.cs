using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Projekt.Models;

namespace Projekt.DAL
{
    public class TodoItemDAL : DbContext
    {
        public DbSet<TodoItem> TodoItemDB { get; set; } // przez ten atrybut będziemy odwoływać się do bazy danych

        public TodoItemDAL() : base("DBLoc") // automatycznie powstanie baza danych jesli nie istnieje
        {

        }
    }
}