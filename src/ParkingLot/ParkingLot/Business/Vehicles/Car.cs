using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Business.Vehicles
{
    public class Car : ICalculator
    {
        public Dictionary<ParkingSpaceType, Func<int, int, decimal>> GetFeesCalculatorFuncs()
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

        private decimal CalculateFeesForMall(int hrs, int mins)
        {


            if (hrs== 0)
                return 20;

            decimal total = 20 * hrs;
            if (mins > 0)
                total += 20;

            return total;


        }

        private decimal CalculateFeesForStadium(int hrs, int mins)
        {

            var total = 0;

            total += 60;
            hrs -= 4;

            if (hrs > 0)
                total += 120;
            else
                return total;


            hrs -= 8;

            if (hrs < 0)
                return total;

            while (hrs > 0)
            {
                total += 200;
                hrs--;
            }
            if (mins > 0)
                total += 200;


            return total;
        }

        public decimal CalculateFeesForAirport(int hrs, int mins)
        {
            if (hrs< 12)
                return 60;

            if ((hrs == 12 && mins > 0) || (hrs > 12 && hrs <24))
                return 80;

            var total = 0;
            while (hrs > 0)
            {
                total += 100;
                hrs -= 24;
            }

            return total;
        }

    }
}
