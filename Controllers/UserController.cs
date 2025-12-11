using Day4_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Day4.Context;

namespace Day4_MVC.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        //   ***********************  New User ********************************

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register (User usr)
        {
            db.Users.Add(usr); 
            db.SaveChanges();

            return RedirectToAction("GetAll", "Student");

        }

        //**************************** Login ***********************************

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // هنا تقدر تخزن سيشن أو تعمل أي لوجيك
                return RedirectToAction("GetAll", "Student");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View();
        }
    }
}
