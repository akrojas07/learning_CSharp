using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscPracticeApp.Models
{
    public class MillionDollarHouse
    {
        public MillionDollarHouse(int numberOfRooms, int squareFootage, int numberOfBathrooms, CounterTypesEnum counterType, bool gatedCommunity, string communityName, string houseType) 
        {
            NumberOfRooms = numberOfRooms;
            SquareFootage = squareFootage;
            NumberOfBathrooms = numberOfBathrooms;
            CounterType = counterType;
            GatedCommunity = gatedCommunity;
            CommunityName = communityName;
            HouseType = houseType;
        }
        
        public int NumberOfRooms { get; set; }
        public int SquareFootage { get; set; }
        public int NumberOfBathrooms { get; set; }
        public CounterTypesEnum CounterType { get; set; }
        public bool GatedCommunity { get; set; }
        public string CommunityName { get; set; }
        public string HouseType { get; set; }

        //method
        public virtual void HouseFit()
        {
            if (NumberOfRooms >= 4)
            {
                Console.WriteLine("This house has enough rooms");
            }
            else
            { 
                Console.WriteLine("Not enough rooms - keep looking");
            }
        }
    }
}
