namespace ParkingLot.Models
{
    public class ParkingTicket
    {
        public long TicketNumber { get; set; }
        public int SpotNumber { get; set; }
        public DateTime EntryDate { get; set; }

        public TicketType TicketType { get; set; }
    }

    public enum TicketType
    {
        Booked,
        NoSpaceAvailable
    }
}
