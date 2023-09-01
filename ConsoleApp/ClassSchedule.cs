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
            
            //DateTime classStartDate = new DateTime(2023, 09, 01);
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(11, 0, 0);

            Console.WriteLine("Enter class Start Date (ex. 2023-09-01): ");
            var classStart = Console.ReadLine();
            if (DateTime.TryParseExact(classStart, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime classStartDate))
            {
                //Console.WriteLine($"You entered the date: {classStartDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy.");
            }
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
