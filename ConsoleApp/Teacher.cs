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
        public string Name { get; set;}
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Course> TeacherCourses { get; set; }

        /*TrainingDbContext context = new TrainingDbContext();*/
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

                
        }


}
