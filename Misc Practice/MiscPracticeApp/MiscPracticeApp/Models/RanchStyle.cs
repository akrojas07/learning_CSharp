using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscPracticeApp.Models
{
    public class RanchStyle : MillionDollarHouse
    {
        public RanchStyle(int numberOfRooms, int squareFootage, int numberOfBathrooms, CounterTypesEnum counterType, bool gatedCommunity, string communityName)
            : base(numberOfRooms, squareFootage, numberOfBathrooms, counterType, gatedCommunity, communityName, "Ranch Style")
        {
            base.HouseType = "Ranch Style";
        }
    }
}
