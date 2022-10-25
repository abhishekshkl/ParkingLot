namespace ParkingLot.Models
{
    public class ParkingReceipt
    {
        public string ReceiptNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public decimal Fees { get; set; }
    }
}
