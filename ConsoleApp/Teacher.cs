using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Course> TeacherCourses { get; set; }

        /*TrainingDbContext context = new TrainingDbContext();*/

        public void TeacherDashboard(int teacherId)
        {

            Console.WriteLine("Opening Teacher Dashboard...");
            User user = new User();
            while (true)
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. View Attendance Report");
                //Console.WriteLine("2. create a new student");
                
                Console.WriteLine("0. Exit\n");

                string adminCommand = Console.ReadLine();
                if (int.TryParse(adminCommand, out int number))
                {
                    switch (number)
                    {
                        case 1:

                            using (var context = new TrainingDbContext())
                            {
                                var courseList = context.Courses
                                    .Where(t => t.TeacherId == teacherId)
                                    .ToList();
                                Console.WriteLine("Courst List:\n\nName\tCourse ID Teacher ID");
                                foreach (var courses in courseList)
                                {

                                    Console.WriteLine($"{courses.CourseName,-10}{courses.Id,-10}{courses.TeacherId}");
                                }
                            }
                            Console.WriteLine("Enter Course ID to view Report: ");
                            string coursesId = Console.ReadLine();
                            int.TryParse(coursesId, out int courseId);
                            ViewAttendanceReport(courseId);
                            break;
                        case 2:
                            break;

                        case 0:
                            Console.WriteLine("Exiting Teacher Dashboard.");
                            return;

                        default:
                            Console.WriteLine("Unknown Teacher command. Please try again.");
                            break;
                    }
                }

            }
        }
    

        public void CreateTeacher()
        {
            using (var context = new TrainingDbContext())
            {
                Console.WriteLine("Enter Name of Teacher: ");
                string name = Console.ReadLine();
                User user = new User();
                int Id = user.CreateUser("teacher");
                var teacher = new Teacher { Name = name, UserId = Id };

                context.Teachers.Add(teacher);
                context.SaveChanges();

                Console.WriteLine("Teacher Created Successfully, Name: "+name);

            }
                
        }

        public void ViewAttendanceReport(int courseId)
        {

            using (var dbContext = new TrainingDbContext())
            {
                
                var classDates = dbContext.ClassSchedules
                    .Where(cs => cs.CourseId == courseId)
                    .Select(cs => cs.ClassDate)
                    .Distinct()
                    .OrderBy(cs => cs)
                    .ToList();

                var students = dbContext.Students
                    .Join(dbContext.CourseStudents,
                        student => student.Id,
                        courseStudent => courseStudent.StudentId,
                        (student, courseStudent) => new { Student = student, CourseId = courseStudent.CourseId })
                    .Where(joinResult => joinResult.CourseId == courseId)
                    .Select(joinResult => joinResult.Student)
                    .ToList();

                var attendanceReport = new Dictionary<DateTime, Dictionary<string, bool>>();

                foreach (var classDate in classDates)
                {
                    var attendanceData = new Dictionary<string, bool>();

                    foreach (var student in students)
                    {
                        var attended = dbContext.Attendances
                            .Any(a => a.StudentId == student.Id && a.CourseId == courseId && a.DateTime == classDate);

                        attendanceData.Add(student.Name, attended);
                    }

                    attendanceReport.Add(classDate, attendanceData);
                }

                // Display the attendance report
                Console.WriteLine("Attendance Report for Course ID: " + courseId);
                Console.WriteLine();

                // Header row
                Console.Write("Class Date\t");
                foreach (var student in students)
                {
                    Console.Write(student.Name + "\t");
                }
                Console.WriteLine();

                foreach (var classDate in classDates)
                {
                    Console.Write(classDate.ToShortDateString() + "\t");
                    foreach (var student in students)
                    {
                        var attended = attendanceReport[classDate][student.Name];
                        Console.Write(attended ? "P\t" : "A\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }




}
