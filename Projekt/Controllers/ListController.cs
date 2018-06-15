using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.ViewModels;
using Projekt.BL;
using Projekt.Models;

namespace Projekt.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        // GET: List
        public ActionResult List()
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            UserBL userBL = new UserBL();
            int userID = userBL.GetLoggedUserID((string)Session["LoggedUser"]);
            
            List<TodoItem> list = todoItemBL.GetItems(userID);
            List<ListVM> list2 = new List<ListVM>();
            string username = (string)Session["LoggedUser"];
            string page = Request.QueryString["page"];
            
            int pageNr;
            if (page == null)
            {
                pageNr = 1;
            }
            else
            {
                try
                {
                    pageNr = Int32.Parse(page);
                }
                catch (FormatException e)
                {
                    return RedirectToAction("Forbidden");
                }
            }

            int listCount = list.Count;
            const int max_items = 10;
            if (pageNr*5>listCount + max_items)
            {
                return RedirectToAction("Forbidden");
            }

            int index = (pageNr-1) * max_items;
            for (int i=0; i< max_items && index<listCount; i++)
            {
                list2.Add(new ListVM(list[index]));
                index++;
            }

            ListVMBroad vm = new ListVMBroad();
            vm.list = list2;
            vm.pageNr = pageNr;
            vm.listCount = listCount;
            vm.max_items = max_items;

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CreateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (Session["LoggedUser"] == null)
                return View(vm);
            TodoItemBL todoItemBL = new TodoItemBL();
            UserBL userBL = new UserBL();
            int userID = userBL.GetLoggedUserID((string)Session["LoggedUser"]);
            TodoItem todoItem = new TodoItem(vm, userID);

            todoItemBL.AddItem(todoItem);
            
            return RedirectToAction("List", "List");
        }
        
        public ActionResult Details(int id)
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            TodoItem todoItem = todoItemBL.GetItemByID(id);
            if (todoItem == null)
                return RedirectToAction("Forbidden");
            string loggedUser = (string)Session["LoggedUser"];
            UserBL userBL = new UserBL();
            int userID = userBL.GetLoggedUserID(loggedUser);
            if (todoItem.UserID != userID)
                return RedirectToAction("Forbidden");

            DetailsVM vm = new DetailsVM(todoItem);
            return View(vm);
        }
        
        public ActionResult Edit(int id)
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            TodoItem todoItem = todoItemBL.GetItemByID(id);
            if (todoItem == null)
                return RedirectToAction("Forbidden");
            string loggedUser = (string)Session["LoggedUser"];
            UserBL userBL = new UserBL();
            int userID = userBL.GetLoggedUserID(loggedUser);
            if (todoItem.UserID != userID)
                return RedirectToAction("Forbidden");

            EditVM vm = new EditVM(todoItem);
            return View(vm);
        }
        
        [HttpPost]
        public ActionResult Edit(EditVM vm, int id)
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            todoItemBL.UpdateItem(vm, id);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            TodoItem todoItem = todoItemBL.GetItemByID(id);
            if (todoItem == null)
                return RedirectToAction("Forbidden");
            string loggedUser = (string)Session["LoggedUser"];
            UserBL userBL = new UserBL();
            int userID = userBL.GetLoggedUserID(loggedUser);
            if (todoItem.UserID != userID)
                return RedirectToAction("Forbidden");

            DeleteVM deleteVM = new DeleteVM(todoItem);

            return View(deleteVM);
        }

        [HttpPost]
        public ActionResult Delete(DeleteVM vm, int id)
        {
            TodoItemBL todoItemBL = new TodoItemBL();
            TodoItem todoItem = todoItemBL.GetItemByID(id);
            if (todoItem == null)
                return RedirectToAction("Forbidden");
            todoItemBL.DeleteItem(id);
            return RedirectToAction("List");
        }

        public ActionResult Forbidden()
        {
            return View();
        }

    }
}