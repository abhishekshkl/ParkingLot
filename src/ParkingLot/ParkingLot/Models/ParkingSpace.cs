using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ParkingLot.Models
{
    public class ParkingSpace
    {
        public string Name { get; set; }

        public ParkingSpaceType SpaceType { get; set; }

        public List<Vehicles> Vehicles { get; set; }

        public int TicketNumber { get; set; }

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ParkingSpaceType
    {
        [EnumMember(Value = "Mall")]
        Mall,
        [EnumMember(Value = "Stadium")]

        Stadium,
        [EnumMember(Value = "Airport")]

        Airport
    }


    [JsonConverter(typeof(StringEnumConverter))]

    public enum VehicleType
    {
        [EnumMember(Value = "Car")]

        Car,
        [EnumMember(Value = "MotorCycle")]

        MotorCycle,
        [EnumMember(Value = "Truck")]

        Truck
    }

    public class Vehicles
    {
        public VehicleType VehicleType { get; set; }
        public int NoOfSpots { get; set; }

        public List<bool> Spots { get; set; }
    }
}
