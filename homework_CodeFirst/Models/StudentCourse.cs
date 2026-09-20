namespace homework_CodeFirst.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        virtual public Student Student { get; set; } = null!;

        virtual public Course Course { get; set; } = null!;
    }
}
