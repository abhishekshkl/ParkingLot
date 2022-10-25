using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Business
{
    public class Parking : IParking
    {
        private readonly IResolver _resolver;

        public Parking(IResolver resolver)
        {
            _resolver = resolver;
        }

        public bool FreeParkingSlot(ParkingTicket parkingTicket, ParkingSpace space, VehicleType vehicleType)
        {
            var vehicleData = space.Vehicles.FirstOrDefault(c => c.VehicleType == vehicleType);
            vehicleData.Spots[parkingTicket.SpotNumber] = true;
            vehicleData.NoOfSpots++;

            return true;
        }

        public ParkingTicket ParkVehicle(ParkingSpace space, VehicleType vehicleType, DateTime entryTime)
        {
            var vehicleData = space.Vehicles.FirstOrDefault(c => c.VehicleType == vehicleType);

            if (vehicleData.NoOfSpots == 0)
                return new ParkingTicket()
                {
                    EntryDate = DateTime.Now,
                    SpotNumber = 0,
                    TicketNumber = 0,
                    TicketType=TicketType.NoSpaceAvailable
                };

            var spotNumber = vehicleData.Spots.IndexOf(true);
            vehicleData.Spots[spotNumber] = false;
            vehicleData.NoOfSpots--;

            return new ParkingTicket()
            {
                EntryDate = DateTime.Now,
                SpotNumber = spotNumber,
                TicketNumber = space.TicketNumber++,
                TicketType= TicketType.Booked
            };
        }

        public ParkingReceipt UnParkVehicle(ParkingSpace space, VehicleType vehicleType, ParkingTicket ticket, int hrs,int mins )
        {
            var feesList = _resolver.Resolve(vehicleType).GetFeesCalculatorFuncs();

            var fees = feesList[space.SpaceType].Invoke(hrs,mins);

            FreeParkingSlot(ticket, space, vehicleType);

            return new ParkingReceipt
            {
                EntryDate = ticket.EntryDate,
                ExitDate = ticket.EntryDate.AddHours(hrs).AddMinutes(mins),
                Fees = fees,
                ReceiptNumber = "R" + ticket.TicketNumber
            };
        }
    }
}
