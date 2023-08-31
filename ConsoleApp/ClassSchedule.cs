using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int ClassNo { get; set; }
        public DateTime ClassDate { get; set; }  
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public void CreateClassSchedule(int CourseId)
        {
            //DayOfWeek firstClassDay, DayOfWeek secondClassDay,
            
            DateTime classStartDate = new DateTime(2023, 09, 01);
            TimeSpan startTime = new TimeSpan(10, 0, 0);
            TimeSpan endTime = new TimeSpan(12, 0, 0);
            
            Console.WriteLine("Enter a day 1 of the week (ex. Sunday, Monday): ");
            var classDay1 = Console.ReadLine();
            //Console.WriteLine(CourseId);
            Enum.TryParse(classDay1, out DayOfWeek firstClassDay);
            Console.WriteLine("Enter a day 2 of the week (ex. Sunday, Monday): ");
            var classDay2 = Console.ReadLine();
            
            Enum.TryParse(classDay2, out DayOfWeek secondClassDay);

            using (var context = new TrainingDbContext())
            {

                Course courseToUpdate = FindCourseById(context, CourseId);
                Course Course = context.Courses.FirstOrDefault(Course => Course.Id == CourseId);

                if (courseToUpdate != null)
                {
                    DateTime currentDate = classStartDate;
                    int classNo = 0;

                    while(classNo!= Course.TotalClass)
                    {
                        if (currentDate.DayOfWeek == firstClassDay || currentDate.DayOfWeek == secondClassDay)
                        {
                            var classForSchedule = new ClassSchedule
                            {
                                ClassDate = currentDate,
                                StartTime = new TimeSpan(20, 00, 0),
                                EndTime = new TimeSpan(22, 00, 0),
                                CourseId = Course.Id,
                                ClassNo = classNo+1,
                            };
                                classNo++;
                            context.ClassSchedules.Add(classForSchedule);
                        }

                        currentDate = currentDate.AddDays(1);
                    }
                    Console.WriteLine("Course Schedule Added Successfully");

                }
                else
                {
                    Console.WriteLine("Failed to schedule class");
                }
                    /*Console.WriteLine("Enter Course Name: ");
                var CourseName = Console.ReadLine();
                Console.WriteLine("Enter Fees: ");
                int fees = Console.Read();
                Console.WriteLine("Enter Course Week Day1: ");
                string weekDay1 = Console.ReadLine();
                Console.WriteLine("Enter Course Week Day2: ");
                string weekDay2 = Console.ReadLine();*/
                /*                Console.WriteLine("Enter Course Week Start Time day1: ");
                                var StartTime1 = Console.ReadLine();
                                Console.WriteLine("Enter Course Week End Time day1: ");
                                var EndTime1 = Console.ReadLine();
                                Console.WriteLine("Enter Course Week Start Time day2: ");
                                var StartTime2 = Console.ReadLine();
                                Console.WriteLine("Enter Course Week End Time day2: ");
                                var EndTime2 = Console.ReadLine();*/
                /*Console.WriteLine("Enter Course Total Class: ");
                int TotalClass = Console.Read();*/

                
                context.SaveChanges();

                
            }

        }
        static Course FindCourseById(TrainingDbContext context, int courseId)
        {
            return context.Courses.FirstOrDefault(course => course.Id == courseId);
        }
        static void ReplaceCourseTeacher(TrainingDbContext context, Course course, int TeacherId)
        {
            course.TeacherId = TeacherId;
            //context.SaveChanges();
        }
    }
}
