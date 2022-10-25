using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IParking
    {


        bool FreeParkingSlot(ParkingTicket parkingTicket, ParkingSpace space, VehicleType vehicleType);
        ParkingTicket ParkVehicle(ParkingSpace space, VehicleType vehicleType, DateTime entryTime);
        ParkingReceipt UnParkVehicle(ParkingSpace space, VehicleType vehicleType, ParkingTicket ticket, int hrs,int mins);




    }
}
