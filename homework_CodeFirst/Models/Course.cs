namespace homework_CodeFirst.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }

         public virtual Teacher Teacher { get; set; }

        public virtual List<Lesson> Lessons { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<StudentCourse> StudentCourses { get; set; } = new();
    }
}
