using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscPracticeApp.Models2
{
    public class MsDegree :Masters
    {
        public MsDegree(decimal degreeCost, int degreeDuration, DegreeConcentrationEnum degreeConcentration, bool degreeOnline, string universityName, bool? additionalCosts) 
            : base("MS", degreeCost, degreeDuration, degreeConcentration, degreeOnline, universityName, additionalCosts)
        {
            base.DegreeType = "MS";
        } 
    }
}
