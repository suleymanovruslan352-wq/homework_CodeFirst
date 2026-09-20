namespace homework_CodeFirst.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StudentId { get; set; }

        virtual public Student Student { get; set; }

    }
}
