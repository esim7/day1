using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        public List<Student> Students { get; set; }

        public StudentController()
        {
            Students = new List<Student>()
            {
                new Student() {Id = 1, FirstName = "First1", LastName = "Last"},
                new Student() {Id = 2, FirstName = "Third1", LastName = "Fourth"}
            };
        }

        // localhost/Student/Index
        public ActionResult Index()
        {
            return RedirectToAction("List2");
        }
        
        public ActionResult List2()
        {
            return View(Students);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
            int index = Students.IndexOf(Students.FirstOrDefault(n => n.Id == student.Id));
            Students[index] = newStudent;
            return RedirectToAction("List2");
        }

        public ActionResult Delete(int? id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Students.Remove(Students.Find(s => s.Id == id)); 
            return RedirectToAction("List2");
        }
    }
}