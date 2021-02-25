using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrict.Models
{
    public class Teacher
    {
        // constructor 
        public Teacher(string name, string gender, int age, string subjectTaught, decimal salary, int yearsTeaching) 
        {
            Name = name;
            Gender = gender;
            Age = age;
            SubjectTaught = subjectTaught;
            Salary = salary;
            YearsTeaching = yearsTeaching;

        }
        
        // properties 
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SubjectTaught { get; set; }
        public decimal Salary { get; set; }
        public int YearsTeaching { get; set; }


        /// <summary>
        /// Method to determine how many years until a teach can access their pension, based on their vesting period  
        /// </summary>
        /// <param name="yearsTeaching"> number of years teacher has been teaching</param>
        /// <param name="vestingPeriod"> number of years required as a teacher to access pension</param>
        /// <returns>years until pension can be accessed </returns>
        
        public virtual int CountdownToPension(int yearsTeaching, int vestingPeriod) 
        {
            int yearsRemaining = vestingPeriod - yearsTeaching;

            if(yearsTeaching >=20)
            {
                return 0;

            }
           else
            {
                return yearsRemaining;
            }
        }



    }
}
