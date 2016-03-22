using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{
    public class HomeController : Controller
    {
        private static int nextID = -1;
        ToDoItem model = new ToDoItem();

        public ActionResult Index()
        {
           model.ToDoItems = _toDoList;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCheckBox([Bind(Include = "ID,TaskDescription,Checked")] ToDoItem toDoItem)
        {
            var newTask = _toDoList.FirstOrDefault(x => x.ID == toDoItem.ID);
            if (newTask != null) newTask.Checked = toDoItem.Checked;

            return RedirectToAction("Index");
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _create([Bind(Include = "ID,TaskDescription,Checked")] ToDoItem toDoItem)
        {
            toDoItem.ID = GetNextId();
            _toDoList.Add(toDoItem);

            return RedirectToAction("Index");
        }

        // GET: ToDoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            ToDoItem toDoItem = _toDoList.Find(i => i.ID == id);
            _toDoList.Remove(toDoItem);
            
            return RedirectToAction("Index");
        }


        static  List<ToDoItem> _toDoList = new List<ToDoItem>
        {
            new ToDoItem
            {
                ID = GetNextId(),
                TaskDescription = "Code a todo app",
                Checked = true
            },
            new ToDoItem()
            {
                ID = GetNextId(),
                TaskDescription = "Feed the cat",
                Checked = false
            },
            new ToDoItem()
            {
                ID = GetNextId(),
                TaskDescription = "Sell the cat",
                Checked = false
            },
            new ToDoItem()
            {
                ID = GetNextId(),
                TaskDescription = "Go out dancing",
                Checked = false
            },

        };

        protected static int GetNextId()
        {
            nextID = nextID + 1;
            return nextID; }
    }
}