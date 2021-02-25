using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscPracticeApp.Models;
using MiscPracticeApp.Models2;

namespace MiscPracticeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // models 1
            
            Attached a1 = new Attached(4, 1800, 3,CounterTypesEnum.Quartz, true,"Del Mar");
            a1.HouseFit();

            RanchStyle r1 = new RanchStyle(1, 800, 5, CounterTypesEnum.ButcherBlock , false, "Logan Heights");
            r1.HouseFit();

            TwoStory t1 = new TwoStory(2, 1200, 5, CounterTypesEnum.Marble, false, "Clairemont");
            t1.HouseFit();
            Console.WriteLine($"The {t1.CommunityName} house has {t1.CounterType} counters");

            // models 2
            MaDegree UCSD_ANALYTICS = new MaDegree(54000, 24, DegreeConcentrationEnum.Analytics, false, "UCSD", false);
            MsDegree UCSD_DATASC = new MsDegree(17000, 36, DegreeConcentrationEnum.DataScience, true, "UCSD", null);
            MsDegree GTECH = new MsDegree(34000, 36, DegreeConcentrationEnum.Analytics, true, "Georgia Tech",true);

            Console.WriteLine($"{UCSD_ANALYTICS.UniversityName} teaches {UCSD_ANALYTICS.DegreeConcentration} for {UCSD_ANALYTICS.DegreeDuration} months");
            
            Console.ReadLine();
        }
    }
}
