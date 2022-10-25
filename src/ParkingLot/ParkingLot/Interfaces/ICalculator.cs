using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface ICalculator
    {

        Dictionary<ParkingSpaceType, Func<int, int, decimal>> GetFeesCalculatorFuncs();

    }
}
