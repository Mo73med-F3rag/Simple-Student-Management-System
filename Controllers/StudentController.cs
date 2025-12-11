using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Day4.Context;
using MVC_Day4.Models;

namespace Day4_MVC.Controllers
{
    public class StudentController : Controller
    {
        MyContext db = new MyContext();

        // ================== Get All ==================
        [HttpGet]
        public IActionResult GetAll()
        {
            var stds = db.Students
                         .Include(s => s.Department)
                         .ToList();

            return View(stds);
        }

        // ================== Create ==================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        // ================== Details ==================

        [HttpGet]
        public IActionResult Details(int id)
        {
            var std = db.Students
                        .Include(s => s.Department)   // دي الإضافة المهمة
                        .FirstOrDefault(s => s.Id == id);

            return View(std);
        }

        //  =================== Edit ======================


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var std = db.Students.Find(id);
            ViewBag.depts = new SelectList(db.Departments, "Id", "Name", std.DeptId);

            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student std)
        {
            db.Update(std);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        //=============================  Delete ====================================

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var std = db.Students.Find(id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

    }
}
