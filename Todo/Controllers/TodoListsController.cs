using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    public class TodoListsController : Controller
    {
        private TodoDBContext db = new TodoDBContext();

        // GET: TodoLists
        public ActionResult Index(string todoType, string searchString)
        {
            var TodoLst = new List<string>();

            var TodoQry = from d in db.Todos
                          orderby d.Type
                          select d.Type;
            TodoLst.AddRange(TodoQry.Distinct());
            ViewBag.todoType = new SelectList(TodoLst);

            var todos = from m in db.Todos
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                todos = todos.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(todoType))
            {
                todos = todos.Where(x => x.Type == todoType);
            }

            return View(todos);
        }

        // GET: TodoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.Todos.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // GET: TodoLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DueDate,Type,Hours,Difficulty")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Todos.Add(todoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoList);
        }

        // GET: TodoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.Todos.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DueDate,Type,Hours,Difficulty")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoList);
        }

        // GET: TodoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.Todos.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoList todoList = db.Todos.Find(id);
            db.Todos.Remove(todoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
