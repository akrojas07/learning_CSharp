using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrict.Models
{
    public class Course
    {
        public Course(int numberOfStudentsEnrolled, int maxNumberOfStudents, int minNumberOfStudents, string subject, decimal duration, bool advanced, DaysOfWeekEnum occurrence)
        {
            NumberOfStudentsEnrolled = numberOfStudentsEnrolled;
            MaxNumberOfStudents = maxNumberOfStudents;
            MinNumberOfStudents = minNumberOfStudents;
            Subject = subject;
            Duration = duration;
            Advanced = advanced;
            Occurrence = occurrence; 
        }
        public int NumberOfStudentsEnrolled { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public int MinNumberOfStudents { get; set; }
        public string Subject { get; set; }
        public decimal Duration { get; set; }
        public bool Advanced { get; set; }
        public DaysOfWeekEnum Occurrence { get; set; }

    }
}
