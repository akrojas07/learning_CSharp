using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscPracticeApp.Models2
{
    public class Masters
    {
        public Masters(string degreeType, decimal degreeCost, int degreeDuration, DegreeConcentrationEnum degreeConcentration, bool degreeOnline, string universityName, bool? additionalCosts) 
        {
            DegreeType = degreeType;
            DegreeCost = degreeCost;
            DegreeDuration = degreeDuration;
            DegreeConcentration = degreeConcentration;
            DegreeOnline = degreeOnline;
            UniversityName = universityName;
            AdditionalCosts = additionalCosts; 

        }
        // degree type MS / MA 
        public string DegreeType { get; set; }
        // degree cost 
        public decimal DegreeCost { get; set; }
        // degree duration in months 
        public int DegreeDuration { get; set; }
        // degree concentration: analytics, statistics, economics, data science - use an enum
        public DegreeConcentrationEnum DegreeConcentration { get; set; } 
       // location 
        public bool DegreeOnline { get; set; }
        public string UniversityName { get; set; }

        //nullable property indicating whether there are additional costs 
        public bool? AdditionalCosts { get; set; }

    }
}
