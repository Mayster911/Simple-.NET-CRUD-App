using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models;
using Projekt.DAL;
using Projekt.ViewModels;

namespace Projekt.BL
{
    public class TodoItemBL
    {
        public List<TodoItem> GetItems(int userID) // TODO: update logic
        {
            TodoItemDAL db = new TodoItemDAL();
            return db.TodoItemDB.Where(x => x.UserID == userID).ToList(); // pobranie wszystkich elementów
        }
        public void AddItem(TodoItem u)
        {
            TodoItemDAL db = new TodoItemDAL();
            db.TodoItemDB.Add(u);
            db.SaveChanges();
        }

        public TodoItem GetItemByID(int id)
        {
            TodoItemDAL db = new TodoItemDAL();
            return db.TodoItemDB.Find(id);
        }

        public void DeleteItem(int id)
        {
            TodoItemDAL db = new TodoItemDAL();
            var userToRemove = db.TodoItemDB.Find(id);
            db.TodoItemDB.Remove(userToRemove);
            db.SaveChanges();
        }

        public void UpdateItem(EditVM item, int id)
        {
            TodoItemDAL db = new TodoItemDAL();
            var toUpdate = db.TodoItemDB.Find(id);
            toUpdate.Name = item.Name;
            toUpdate.Description = item.Description;
            toUpdate.LimitTime = item.LimitTime;
            db.SaveChanges();
        }
        
    }
}