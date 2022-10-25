namespace ParkingLot.Models
{
    public class Output
    {
        public ParkingTicket ParkingTicket { get; set; }
        public ParkingReceipt ParkingReceipt { get; set; }


    }
    public class FinalOutputWithInputs
    {
        public Input Input { get; set; }
        public List<Output> Outputs { get; set; }
    }
}
