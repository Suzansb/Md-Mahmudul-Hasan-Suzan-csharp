using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public List<CourseStudent> StudentCourses { get; set; }
        public List<Attendance> StudentAttendances { get; set; }

        /*Trainingcontext context = new Trainingcontext();*/

        public void CreateStudent()
        {
            using (var context = new TrainingDbContext())
            {
                Console.WriteLine("Enter Name of Student: ");
                var name = Console.ReadLine();
                User user = new User();
                int Id = user.CreateUser("student");

                /*var StudentUser = new User { Username = "student4", Password = "studentpass", UserType = "student" };*/
                var student = new Student { Name=name, UserId = Id};
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student Created Successfully, Name: "+name);

            }
               
        }

        public void OpenUserDashboard(int studentId)
        {
            Console.WriteLine("Opening Usern Dashboard...");

            while (true)
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1. Give Attendance");
                Console.WriteLine("2. Attendance Report");
                Console.WriteLine("0. Exit");

                string adminCommand = Console.ReadLine();
                if (int.TryParse(adminCommand, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            StudentAttendance(studentId);
                            break;
                        case 2:
                            List<Course> enrolledCourses = GetEnrolledCoursesWithNames(studentId);
                            Console.WriteLine($"Your are Enrolled in below courses:");
                            foreach (var course in enrolledCourses)
                            {
                                Console.WriteLine($"Course ID: {course.Id}, Name: {course.CourseName}");
                            }
                            Console.WriteLine("Enter Course Id to view attendance Report: ");
                            var selecCourseId = Console.ReadLine();
                            int.TryParse(selecCourseId, out int ScourseId);
                            Attendance attendance = new Attendance();
                            attendance.GenerateAttendanceReport(studentId, ScourseId);
                            break;


                        case 0:
                            Console.WriteLine("Exiting Student Dashboard.");
                            return;
                        default:
                            Console.WriteLine("Unknown StudentDashboard command. Please try again.");
                            break;
                    }
                }

            }
        }

        static List<Course> GetEnrolledCoursesWithNames(int studentId)
        {
            using (var context = new TrainingDbContext())
            {
                var enrolledCourses = context.CourseStudents
                .Where(cs => cs.StudentId == studentId)
                .Select(cs => cs.Course)
                .ToList();

                return enrolledCourses;
            }
                
        }

        public void StudentAttendance(int studentId)
        {
            using (var context = new TrainingDbContext())
            {
                DateTime currentTime = DateTime.Now;

                List<Course> enrolledCourses = GetEnrolledCoursesWithNames(studentId);
                Console.WriteLine($"Your are Enrolled in below courses:");
                foreach (var course in enrolledCourses)
                {
                    Console.WriteLine($"Course ID: {course.Id}, Name: {course.CourseName}");
                }
                Console.WriteLine("\nEnter Course Id to Give attendance: ");
                var selecCourseId = Console.ReadLine();
                int.TryParse(selecCourseId, out int courseId);

                // Check if the student is enrolled in the specified course
                bool isEnrolled = context.CourseStudents
                    .Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);

                if (isEnrolled)
                {
                    // Check if there's a class scheduled for the current date and time
                    bool isClassScheduled = context.ClassSchedules
                        .Any(cs => cs.CourseId == courseId &&
                                   cs.ClassDate.Date == currentTime.Date &&
                                   currentTime.TimeOfDay >= cs.StartTime &&
                                   currentTime.TimeOfDay <= cs.EndTime);

                    if (isClassScheduled)
                    {
                        // Record the attendance
                        Attendance attendance = new Attendance
                        {
                            StudentId = studentId,
                            CourseId = courseId,
                            DateTime = currentTime.Date,
                            /*AttendanceTime = currentTime*/
                            IsPresent = true,
                        };

                        context.Attendances.Add(attendance);
                        context.SaveChanges();

                        Console.WriteLine("Attendance recorded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("It's not currently your class time.");
                    }
                }
                else
                {
                    Console.WriteLine("You are not enrolled in this course.");
                }

            }

        }




            public bool IsStudentEnrolledInCourse(int studentId, int courseId)
        {
            using (var context = new TrainingDbContext())
            {
                bool isEnrolled = context.CourseStudents
                    .Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);

                return isEnrolled;
            }

            static Course FindCourseById(TrainingDbContext context, int courseId)
            {
                return context.Courses.FirstOrDefault(course => course.Id == courseId);
            }
        }

    }

    
}
