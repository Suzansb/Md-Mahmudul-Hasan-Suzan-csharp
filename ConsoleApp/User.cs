using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        /* public List<Teacher> Teachers { get; set; }
         public List<Student> Students { get; set; }*/


        public int UserLogin(string username, string password)
        {
            using (var context = new TrainingDbContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    if (user.UserType == "admin")
                    {
                        Console.WriteLine("Logged in as Admin.");
                        return 1;
                    }
                    else if (user.UserType == "teacher")
                    {
                        Console.WriteLine("Logged in as Teacher.");
                        return 3;
                    }
                    else
                    {
                        Console.WriteLine("Logged in as Student.");
                        return 2;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return 4;
                }
            }
        }

        public void OpenAdminDashboard()
        {
            Console.WriteLine("Opening Admin Dashboard...");
            User user = new User();
            while (true)
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. create a new teacher");
                Console.WriteLine("2. create a new student");
                Console.WriteLine("3. create a Course");
                Console.WriteLine("4. Assign a Teacher in Course");
                Console.WriteLine("5. Assign a Student in Course");
                Console.WriteLine("6. Generate a Course Class Schedule");
                Console.WriteLine("0. Exit\n");

               
                string adminCommand = Console.ReadLine();
                if (int.TryParse(adminCommand, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            Teacher teacher = new Teacher();
                            teacher.CreateTeacher();
                            break;
                        case 2:
                            Student student = new Student();
                            student.CreateStudent();
                            break;

                        case 3:
                            Course course = new Course();
                            course.CreateCourse();
                            break;
                        case 4:
                            AssignCourseTeacher();
                            break;
                        case 5:
                            AssignCourseStudent();
                            break;

                        case 6:
                            ClassSchedule classSchedule = new ClassSchedule();
                            Console.WriteLine("Enter Course Id which to be shedule: ");
                            var courseSId = Console.ReadLine();
                            int.TryParse(courseSId, out int courseId);
                            classSchedule.CreateClassSchedule(courseId); // Can provide any week days
                            break;

                        case 0:
                            Console.WriteLine("Exiting Admin Dashboard.");
                            return;

                        default:
                            Console.WriteLine("Unknown admin command. Please try again.");
                            break;
                    }
                }
                    
            }
        }

        public int CreateUser(string UserType)
        {
            using (var context = new TrainingDbContext())
            {
                Console.WriteLine("Enter Username: ");
                var uname = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                var upass = Console.ReadLine();
                User user = new User
                {
                    Username = uname,
                    Password = upass,
                    UserType = UserType,

                };
                context.Users.Add(user);
                context.SaveChanges();


                Console.WriteLine("User Created Successfully for: "+UserType);
                //Console.WriteLine("New User: {user.Username} and Password" + UserType);
                return user.Id;

            }

        }

        public void AssignCourseTeacher()
        {
            Console.WriteLine("Enter Course Id to it Assign: ");
            string parsedCourseId = Console.ReadLine();
            int.TryParse(parsedCourseId, out int courseId);

            Console.WriteLine("Enter Teacher Id to Assign in this course: ");
            string parsedteacherId = Console.ReadLine();
            int.TryParse(parsedteacherId, out int teacherId);

            using (var context = new TrainingDbContext())
            {
                Course courseToUpdate = FindCourseById(context, courseId);
                Teacher TeacherCourses = context.Teachers.FirstOrDefault(Teacher => Teacher.Id == teacherId);

                if (courseToUpdate != null)
                {
                    ReplaceCourseTeacher(context, courseToUpdate, teacherId);
                    Console.WriteLine($"Teacher Assigned: {TeacherCourses.Name} in Course: {courseToUpdate.CourseName}");
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }
                //context.Courses.Add(course);
                context.SaveChanges();
            }

        }

        public void AssignCourseStudent()
        {
            Console.WriteLine("Enter Course Id to be Assign: ");
            string CourseId = Console.ReadLine();
            Console.WriteLine("Enter Student Id to Assign in this course: ");
            string StudentId = Console.ReadLine();

            using (var context = new TrainingDbContext())
            {
                int parsedCourseId;
                int.TryParse(CourseId, out parsedCourseId);
                //Console.WriteLine(parsedCourseId);

                Course courseToUpdate = context.Courses.FirstOrDefault(course => course.Id == 3);


                if (courseToUpdate != null)
                {
                    int parsedStudentId;


                    if (int.TryParse(StudentId, out parsedStudentId))
                    {
                        Student StudentCourses = context.Students.FirstOrDefault(student => student.Id == parsedStudentId);

                        if (StudentCourses != null)
                        {
                            var courseStudent = new CourseStudent
                            {
                                CourseId = parsedCourseId,
                                StudentId = parsedStudentId,
                                EnrollDate = DateTime.Now,
                            };
                            context.CourseStudents.Add(courseStudent);

                            Console.WriteLine($"Student Assigned: {StudentCourses.Name} in Course: {courseToUpdate.CourseName}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid student ID input.");
                    }
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }

                context.SaveChanges();
            }
        }


            /*using (var context = new TrainingDbContext())
            {
                Course courseToUpdate = FindCourseById(context, CourseId);

                if (courseToUpdate != null)
                {
                    Student StudentCourses = context.Students.FirstOrDefault(Student => Student.Id == StudentId);
                    var courseStudent = new CourseStudent
                    {
                        CourseId = CourseId,
                        StudentId = StudentId,
                        EnrollDate = DateTime.Now,
                    };
                    context.CourseStudents.Add(courseStudent);

                    Console.WriteLine($"Student Assigned: {StudentCourses.Name} in Course: {courseToUpdate.CourseName}");
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }

                context.SaveChanges();
            }*//*

        }*/
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
