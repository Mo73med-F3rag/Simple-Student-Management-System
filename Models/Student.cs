using Day4_MVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day4.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }

        [DisplayName("Student Address")]
        public string Address { get; set; }

        [DisplayName("Student Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        //=======================================================================

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department Department { get; set; }
    }
}