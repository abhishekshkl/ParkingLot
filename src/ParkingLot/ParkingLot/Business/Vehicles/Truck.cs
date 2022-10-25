using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Business.Vehicles
{
    public class Truck : ICalculator
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
            return 0;
        }

        private decimal CalculateFeesForStadium(int hrs, int mins)
        {
            return 0;
        }

        private decimal CalculateFeesForMall(int hrs, int mins)
        {
            if (hrs== 0)
                return 50;

            decimal total = 50 * hrs;
            if (mins > 0)
                total += 50;

            return total;
        }
    }
}
