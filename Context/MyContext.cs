using Day4_MVC.Models;
using Microsoft.EntityFrameworkCore;
using MVC_Day4.Models;

namespace MVC_Day4.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=MVC_Day4 ;trusted_connection=true;trustServerCertificate=true");
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var depts = new List<Department>
            {
                new Department { Id = 1, Name = ".NET" },
                new Department { Id = 2, Name = "Mob" },
                new Department { Id = 3, Name = "Cloud" },
                new Department { Id = 4, Name = "ui" },
            };
            var stds = new List<Student>
            {
                new Student{Id=1,Name="Ahmed",Age=20,Address="Cairo",Email ="Ahmed@gmail.com" ,Password="Ahmed123" , DeptId =1},
                new Student{Id=2,Name="Mohamed",Age=19,Address="Alex",Email ="Mohamed@gmail.com" ,Password="Mohamed123" , DeptId =2},
                new Student{Id=3,Name="Ali",Age=22,Address="Menoufia",Email ="Ali@gmail.com" ,Password="Ali123" , DeptId =3},
                new Student{Id=4,Name="Adel",Age=23,Address="Gize",Email ="Adel@gmail.com" ,Password="Adel123" , DeptId =4},
                new Student{Id=5,Name="Adham",Age=18,Address="Cairo",Email ="Adham@gmail.com" ,Password="Adham123" , DeptId =1},

            };
            modelBuilder.Entity<Department>().HasData(depts);
            modelBuilder.Entity<Student>().HasData(stds);
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<User> Users { get; set; }

    }
}
