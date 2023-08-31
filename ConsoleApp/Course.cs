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
                int fees = Console.Read();
                Console.WriteLine("Enter Course Week Day1: ");
                string weekDay1 = Console.ReadLine();
                Console.WriteLine("Enter Course Week Day2: ");
                string weekDay2 = Console.ReadLine();
/*                Console.WriteLine("Enter Course Week Start Time day1: ");
                var StartTime1 = Console.ReadLine();
                Console.WriteLine("Enter Course Week End Time day1: ");
                var EndTime1 = Console.ReadLine();
                Console.WriteLine("Enter Course Week Start Time day2: ");
                var StartTime2 = Console.ReadLine();
                Console.WriteLine("Enter Course Week End Time day2: ");
                var EndTime2 = Console.ReadLine();*/
                Console.WriteLine("Enter Course Total Class: ");
                int TotalClass = Console.Read();


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
        
    }
}
