using ParkingLot.Interfaces;
using ParkingLot.Models;
using System.Reflection;

namespace ParkingLot.Business
{
    public class BusinessResolver:IResolver
    {
        private readonly IServiceProvider _provider;

        public BusinessResolver(IServiceProvider provider)
        {
            this._provider = provider;
        }

        public ICalculator Resolve(VehicleType vehicletype)
        {

            switch (vehicletype)
            {
                case VehicleType.Car:
                    return _provider.GetService(Assembly.GetAssembly(typeof(BusinessResolver)).GetType("ParkingLot.Business.Vehicles.Car")) as ICalculator;
                case VehicleType.MotorCycle:
                    return _provider.GetService(Assembly.GetAssembly(typeof(BusinessResolver)).GetType("ParkingLot.Business.Vehicles.MotorCycle")) as ICalculator;
                case VehicleType.Truck:
                    return _provider.GetService(Assembly.GetAssembly(typeof(BusinessResolver)).GetType("ParkingLot.Business.Vehicles.Truck")) as ICalculator;
                default:
                    break;
            }
            return null;
        }
    }



}
