using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Attendance
    {
        public int Id { get; set; }
        /*public virtual Student Student { get; set; }*/
        public DateTime DateTime { get; set;}
        public bool IsPresent { get; set;}

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }


        public void GenerateAttendanceReport(int studentId, int courseId)
        {
            using (var context = new TrainingDbContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Id == studentId);

                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                //int courseId = 3;
                var attendedDates = context.Attendances
                    .Where(a => a.StudentId == studentId && a.CourseId == courseId)
                    .Select(a => a.DateTime)
                    .ToList();

                var classSchedules = context.ClassSchedules
                    .Where(a=> a.CourseId == courseId)
                    .ToList();
                var report = $"Attendance Report for {student.Name} && for Course {courseId}\n\n";
                report += $"Class No   ClassDate IsAttended\n\n";

                foreach (var classSchedule in classSchedules)
                {
                    if (attendedDates.Contains(classSchedule.ClassDate.Date))
                    {
                        report += $"{classSchedule.ClassNo}   {classSchedule.ClassDate.ToShortDateString()}: Attended\n";
                    }
                    else
                    {
                        report += $"{classSchedule.ClassNo}   {classSchedule.ClassDate.ToShortDateString()}: Absent\n";
                    }
                }

                /*File.WriteAllText($"{student.Name}_Attendance_Report.txt", report);*/
                Console.WriteLine(report);
            }
        }

    }
}
