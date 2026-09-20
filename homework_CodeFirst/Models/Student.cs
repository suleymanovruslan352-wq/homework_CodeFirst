namespace homework_CodeFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        virtual public StudentProfile StudentProfile { get; set; } 

        public virtual List<Course> Courses { get; set; }

        public virtual List<StudentCourse> StudentCourses { get; set; } = new();

    }
}
