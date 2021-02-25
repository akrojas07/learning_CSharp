using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscPracticeApp.Models
{
    public class Attached : MillionDollarHouse
    {
        public Attached(int numberOfRooms, int squareFootage, int numberOfBathrooms, CounterTypesEnum counterType, bool gatedCommunity, string communityName) 
            : base( numberOfRooms, squareFootage,numberOfBathrooms, counterType, gatedCommunity, communityName, "Attached")
        {
            base.HouseType = "Attached";
        }
    }
}
