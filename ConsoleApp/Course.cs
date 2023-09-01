using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Fees { get; set; }


        public int TotalClass { get; set; }

        // Foreign key to link to Teacher
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        
        public List<CourseStudent> CourseStudents { get; set; }
        public List<Attendance> CourseAttendances { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }

        public void CreateCourse()
        {
            using (var context = new TrainingDbContext())
            {
                Console.WriteLine("Enter Course Name: ");
                var CourseName = Console.ReadLine();
                Console.WriteLine("Enter Fees: ");
                var feesC = Console.ReadLine();
                int.TryParse(feesC, out int fees);
                Console.WriteLine("Enter Course Total Class: ");
                var TotalClassC = Console.ReadLine();
                int.TryParse(TotalClassC, out int TotalClass);

                var course = new Course
                {
                    CourseName = CourseName,
                    Fees = fees,
                    TotalClass = TotalClass,
                };

                context.Courses.Add(course);
                context.SaveChanges();

                Console.WriteLine("Course Created Successfully, Please Assign Teachers and Students");
            }

        }
        //public DayOfWeek Weekday { get; set; }

        public static void showCourseList()
        {
            using (var context = new TrainingDbContext())
            {
                var courseList = context.Courses
                    .ToList();
                Console.WriteLine("Courst List:\n\nName\tCourse ID Teacher ID");
                foreach (var courses in courseList)
                {

                    Console.WriteLine($"{courses.CourseName,-10}{courses.Id,-10}{courses.TeacherId}");
                }
            }

        }

    }
}
