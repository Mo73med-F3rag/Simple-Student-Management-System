using System.ComponentModel.DataAnnotations;

namespace MVC_Day4.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
