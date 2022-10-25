using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Business.Vehicles
{
    public class MotorCycle : ICalculator
    {
        public Dictionary<ParkingSpaceType, Func<int,int, decimal>> GetFeesCalculatorFuncs()
        {
            return FillDictvalues();

        }

        private Dictionary<ParkingSpaceType, Func<int,int, decimal>> FillDictvalues()
        {
            return new Dictionary<ParkingSpaceType, Func<int,int, decimal>>()
            {
                {ParkingSpaceType.Mall, CalculateFeesForMall},
                {ParkingSpaceType.Stadium, CalculateFeesForStadium},
                {ParkingSpaceType.Airport, CalculateFeesForAirport}

            };
        }

        private decimal CalculateFeesForAirport(int hrs, int mins)
        {
            if (hrs <= 1)
                return 0;
            if (hrs > 1 && hrs < 8)
                return 40;

            if ((hrs == 8 && mins > 0) || (hrs > 8 && hrs < 24))
                return 60;

            var total = 0;
            while (hrs > 0)
            {
                total += 80;
                hrs -= 24;
            }

            return total;

        }

        private decimal CalculateFeesForStadium(int hrs, int mins)
        {
            var total = 0;

            total += 30;
            hrs -= 4;

            if (hrs > 0)
                total += 60;
            else
                return total;


            hrs -= 8;

            if (hrs < 0)
                return total;


            while (hrs > 0)
            {
                total += 100;
                hrs--;
            }
            if (mins > 0)
                total += 100;


            return total;
        }

        private decimal CalculateFeesForMall(int hrs, int mins)
        {
            if (hrs == 0)
                return 0;

            decimal total = 10 * hrs;
            if (mins> 0)
                total += 10;

            return total;
        }
    }
}
