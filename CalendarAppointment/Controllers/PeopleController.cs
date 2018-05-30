using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalendarAppointment.Models;
using CalendarAppointment.Models.Data;

namespace CalendarAppointment.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            List<Person> people = db.Persons.ToList();
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Phone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult CreateUpdate(Person person)
        {
            Person existingPerson = db.Persons.Find(person.Id);
            if(existingPerson !=null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Email = person.Email;
                existingPerson.Phone = person.Phone;

                db.Entry(existingPerson).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            db.Persons.Add(person);
            db.SaveChanges();
            return Json(new { id = person.Id });
        }
        [HttpPost]
        public ActionResult DeletePerson(Person person)
        {
            Person existingPerson = db.Persons.Find(person.Id);
            if (existingPerson != null)
            {
                db.Persons.Remove(existingPerson);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, Reason = "Unable to find person with ID:" + person.Id });
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return Json(new { success = true });
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
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
