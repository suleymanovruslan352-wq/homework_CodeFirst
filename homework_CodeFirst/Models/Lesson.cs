namespace homework_CodeFirst.Models
{
    public class Lesson
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }

        virtual public Course Course { get; set; }


    }
}
