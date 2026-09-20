
using homework_CodeFirst.Models;
using homework_CodeFirst.context;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    if (context.Students.Any() == null)
    {
        var teacher1 = new Teacher { Name = "Александр Иванов", Email = "ivanov@example.com" };
        var teacher2 = new Teacher { Name = "Елена Смирнова", Email = "smirnova@example.com" };

        context.Teachers.AddRange(teacher1, teacher2);
        context.SaveChanges();

        var student1 = new Student
        {
            Name = "Иван Петров",
            Email = "petrov@example.com",
            StudentProfile = new StudentProfile { Phone = "+79991112233", DateOfBirth = new DateTime(2002, 5, 14) }
        };

        var student2 = new Student
        {
            Name = "Анна Сидорова",
            Email = "sidorova@example.com",
            StudentProfile = new StudentProfile { Phone = "+79992223344", DateOfBirth = new DateTime(2003, 8, 22) }
        };

        var student3 = new Student
        {
            Name = "Дмитрий Васильев",
            Email = "vasilyev@example.com",
            StudentProfile = new StudentProfile { Phone = "+79993334455", DateOfBirth = new DateTime(2001, 12, 3) }
        };

        context.Students.AddRange(student1, student2, student3);
        context.SaveChanges();

        var course1 = new Course { Name = "C# для начинающих", Description = "Основы языка C# и ООП", Price = 15000, TeacherId = teacher1.Id };
        var course2 = new Course { Name = "Продвинутый C# и EF Core", Description = "Работа с базами данных", Price = 25000, TeacherId = teacher1.Id };
        var course3 = new Course { Name = "Веб-разработка на HTML/CSS", Description = "Создание сайтов с нуля", Price = 12000, TeacherId = teacher2.Id };
        var course4 = new Course { Name = "JavaScript Basics", Description = "Основы клиентского скриптинга", Price = 18000, TeacherId = teacher2.Id };

        context.Courses.AddRange(course1, course2, course3, course4);
        context.SaveChanges();

        var lessons = new List<Lesson>
        {
            new Lesson { Title = "Введение в C#", Duration = 90, CourseId = course1.Id },
            new Lesson { Title = "Переменные и типы данных", Duration = 90, CourseId = course1.Id },
            new Lesson { Title = "ООП: Классы и объекты", Duration = 120, CourseId = course1.Id },

            new Lesson { Title = "Знакомство с EF Core", Duration = 120, CourseId = course2.Id },
            new Lesson { Title = "Миграции и DbContext", Duration = 90, CourseId = course2.Id },

            new Lesson { Title = "Основы HTML", Duration = 60, CourseId = course3.Id },
            new Lesson { Title = "Стилизация с помощью CSS", Duration = 90, CourseId = course3.Id },

            new Lesson { Title = "Введение в JavaScript", Duration = 90, CourseId = course4.Id },
            new Lesson { Title = "Функции и массивы", Duration = 90, CourseId = course4.Id }
        };

        context.Lessons.AddRange(lessons);
        context.SaveChanges();

        var studentCourses = new List<StudentCourse>
        {
            new StudentCourse { StudentId = student1.Id, CourseId = course1.Id, EnrollmentDate = DateTime.Now.AddDays(-10) },
            new StudentCourse { StudentId = student1.Id, CourseId = course2.Id, EnrollmentDate = DateTime.Now.AddDays(-5) },
            new StudentCourse { StudentId = student2.Id, CourseId = course3.Id, EnrollmentDate = DateTime.Now.AddDays(-7) },
            new StudentCourse { StudentId = student3.Id, CourseId = course1.Id, EnrollmentDate = DateTime.Now.AddDays(-3) },
            new StudentCourse { StudentId = student3.Id, CourseId = course4.Id, EnrollmentDate = DateTime.Now.AddDays(-1) }
        };

        context.StudentCourse.AddRange(studentCourses);
        context.SaveChanges();
    }

    

}

    

//1

//void ShowAllStudentsWithTheirProfile()
//{
//    var context = new AppDbContext();

//    var studentsWithProfiles = context.Students
//        .Include(s => s.StudentProfile)
//        .ToList();

//    foreach (var student in studentsWithProfiles)
//    {
//        Console.WriteLine($"Student: {student.Name}, Email: {student.Email}, Phone: {student.StudentProfile.Phone}, Date of Birth: {student.StudentProfile.DateOfBirth}");
//    }
//}

//ShowAllStudentsWithTheirProfile();



//2

//void ShowAllCoursesWithTheirTeachers()
//{
//    var context = new AppDbContext();
//    var coursesWithTeachers = context.Courses.Include(c => c.Teacher).ToList(); 
//    foreach (var course in coursesWithTeachers)
//    {
//        Console.WriteLine($"Course: {course.Name}, Description: {course.Description}, Price: {course.Price}, Teacher: {course.Teacher.Name}");
//    }
//}


//ShowAllCoursesWithTheirTeachers();


//3

//void ShowAllLessonsWithTheirCourses()
//{
//   var context = new AppDbContext();
//    var lessonsWithCourses = context.Lessons.Include(l => l.Course).ToList();
//    foreach (var lesson in lessonsWithCourses)
//    {
//        Console.WriteLine($"Lesson: {lesson.Title}, Duration: {lesson.Duration} minutes, Course: {lesson.Course.Name}");
//    }
//}

//ShowAllLessonsWithTheirCourses();

//4

//void ShowAllTeachersandLessonsAndCourses()
//{
//    var context = new AppDbContext();
//    var teachersWithCoursesAndLessons = context.Teachers
//        .Include(t => t.Courses)
//            .ThenInclude(c => c.Lessons)
//        .ToList();
//    foreach (var item in teachersWithCoursesAndLessons)
//    {
//        Console.WriteLine($"Teacher: {item.Name}");
//        foreach (var course in item.Courses)
//        {
//            Console.WriteLine($"  Course: {course.Name}");
//            foreach (var lesson in course.Lessons)
//            {
//                Console.WriteLine($"    Lesson: {lesson.Title}, Duration: {lesson.Duration} minutes");
//            }
//        }
//    }
//}


//ShowAllTeachersandLessonsAndCourses();


//5

//void ShowAllStudentsWithTheirCourses()
//{
//    var context = new AppDbContext();
//    var studentsWithCourses = context.Students.Include(s => s.StudentCourses)
//        .ThenInclude(sc => sc.Course)
//        .ToList();
//    foreach (var item in studentsWithCourses)
//    {
//        Console.WriteLine($"Student: {item.Name}");
//        foreach (var studentCourse in item.StudentCourses)
//        {
//            Console.WriteLine($"  Course: {studentCourse.Course.Name}, Enrollment Date: {studentCourse.EnrollmentDate}");
//        }
//    }

//}

//ShowAllStudentsWithTheirCourses();

//6

//void ShowCountStudentsInTheirCourses()
//{
//    var context = new AppDbContext();
//    var courses = context.Courses.Include(s => s.Students).ToList();
//    foreach (var course in courses)
//    {
//        Console.WriteLine($"Course: {course.Name} - Amount of Students: {course.Students.Count()}");
//    }

//}

//ShowCountStudentsInTheirCourses();