
namespace homework_CodeFirst.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual List<Course> Courses { get; set; }


    }
}
