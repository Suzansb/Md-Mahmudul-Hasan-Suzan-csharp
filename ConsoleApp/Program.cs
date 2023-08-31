using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using System.Linq;

class Program
{
    static void Main()
    {
        using TrainingDbContext context = new TrainingDbContext();

        /*student.StudentAttendance(9, 3);*/

        /*Attendance attendance = new Attendance();
        attendance.GenerateAttendanceReport(9);*/
        /*Course courseT = new Course();
        courseT.AssignCourseTeacher(5, 6);*/
        while (true)
        {
            Console.WriteLine("Please Login first: ");

            Console.WriteLine("Type your Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Type your Password: ");
            string password = Console.ReadLine();
            User user1 = new User();
            int userLogin = user1.UserLogin(username, password);
            var users = context.Users
                    .FirstOrDefault(u => u.Username == username); //get user id by entered username

            var userStudent = context.Students
                    .FirstOrDefault(u => u.UserId == users.Id); //get user id by entered username

            switch (userLogin)
            {
                case 1:
                    Console.WriteLine("\nLogged as an Admin, Please Select Options\n");

                    User user = new User();
                    user.OpenAdminDashboard();
                    break;
                case 2:
                    Console.WriteLine("\nLogged as an Student, Please Select Options");
                    Console.WriteLine($"UserId {users.Id}, StudentId: {userStudent.Id}"); 
                    Student student = new Student();
                    student.OpenUserDashboard(userStudent.Id);
                    break;
                case 3:
                    Console.WriteLine("\nLogged as an Teacher, Please Select Options");
                    break;
                case 4:
                    Console.WriteLine("\nNo user found, Try Again");
                    break;
                case 5:
                    return; // Exit the loop and the program
                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }



        }
        //Console.WriteLine("Working");


    }
    

    /*context.Courses.Add(new ConsoleApp.Course { CourseName = "Suzan", Fees = 10000 });
    context.SaveChanges();*/

    /*var student = new Student
    {
        Name = "Mahmudul Hasan",
    };
    var teacher= new Teacher
    {
        Name = "Suzan",
    };

    var course = new Course
    {
        CourseName = "DevOps",
        Fees = 20000,
        WeekDay1 = "Sunday",
        WeekDay2 = "Wednesday",
        StartTime1 = new TimeSpan(18, 00, 0), //set time for 8pm
        EndTime1 = new TimeSpan(20, 00, 0),
        StartTime2 = new TimeSpan(21, 00, 0),
        EndTime2 = new TimeSpan(23, 00, 0),
        TotalClass = 20,
        TeacherId = 1,
    };
    context.Students.Add(student);
    context.Teachers.Add(teacher);*/
    /*User u1 = new User
    {
        Username = "teacher3",
        Password = "teacher",
        UserType = "teacher",

    };

    User u2 = new User
    {
        Username = "student3",
        Password = "student",
        UserType = "student",

    };

    Teacher teacher = new Teacher
    {
        Name = "Anisuzzaman",
        User = u1,

        TeacherCourses = new List<Course>
    {
        new Course{
            CourseName = "PHP",
            Fees = 30000,
            WeekDay1 = "Sunday",
            WeekDay2 = "Wednesday",
            StartTime1 = new TimeSpan(18, 00, 0), //set time for 8pm
            EndTime1 = new TimeSpan(20, 00, 0),
            StartTime2 = new TimeSpan(21, 00, 0),
            EndTime2 = new TimeSpan(23, 00, 0),
            TotalClass = 30,
        *//*Teacher = teacher,*//*
        CourseStudents = new List<CourseStudent>
            {
                new CourseStudent
                {
                    Student = new Student{Name="Samrin",User=u2}, EnrollDate= DateTime.Now}
                },
            }

    },
    };

    Attendance a1 = new Attendance
    {
        DateTime = DateTime.Now,
        IsPresent = true,
        CourseId = 3,
        StudentId = 2,
    };
*/
    /*Course c1 = new Course
    {

        CourseName = "dot net2",
        Fees = 30000,
        WeekDay1 = "Sunday",
        WeekDay2 = "Wednesday",
        StartTime1 = new TimeSpan(18, 00, 0), //set time for 8pm
        EndTime1 = new TimeSpan(20, 00, 0),
        StartTime2 = new TimeSpan(21, 00, 0),
        EndTime2 = new TimeSpan(23, 00, 0),
        TotalClass = 50,
        Teacher = teacher,
        CourseStudents = new List<CourseStudent>
        {
            new CourseStudent{ Student = new Student{Name="Suza2n",User=u2}, EnrollDate= DateTime.Now}

        },

    };*/

    /*Course c1 = new Course
    {
        Name = "DevOps",
        Fees = 20000,
        IsActive = true,
        ClassStartDate = DateTime.Now,
        CourseTopics = new List<Topic>
        {
            new Topic { Title = "Docker" },
            new Topic { Title = "AWS" }
        },
        CourseStudents = new List<CourseStudent>
        {
            new CourseStudent{ Student = new Student{ Name = "Hasan", CGPA = 3.0 } },
            new CourseStudent{ Student = new Student{ Name = "Tareq", CGPA = 3.2 } }
        }
    };*/

    /*context.Users.AddRange(u1,u2);
    context.Teachers.Add(teacher);*/
    /*context.Courses.Add(c1);*/
    /*context.Attendance.Add(a1);
    context.SaveChanges();*/


    /*using (var dbContext = new TrainingDbContext())
    {
        var studentId = 2; // Example student ID

        var attendanceReports = dbContext.Attendance
            .Where(a => a.StudentId == studentId)
            .Include(a => a.Course)
            .ToList();

        foreach (var attendance in attendanceReports)
        {
            Console.WriteLine($"Class: {attendance.Course.CourseName}, Date: {attendance.DateTime}, Present: {attendance.IsPresent}");
        }
    }*/
}



