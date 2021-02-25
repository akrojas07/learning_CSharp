using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrict.Models
{
    public class School
    {
        public School(string name, decimal totalBudget, string neighborhood) 
        {
            Name = name;
            TotalBudget = totalBudget;
            Neighborhood = neighborhood; 
        }

        public string Name;
        public decimal TotalBudget;
        public string Neighborhood;


    }
}
