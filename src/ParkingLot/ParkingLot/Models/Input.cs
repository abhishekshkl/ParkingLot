namespace ParkingLot.Models
{
    public class Input
    {
        public List<In> ParkingSpaceDetails { get; set; }
        public List<ParkingDetail> ParkingDetails { get; set; }

        public ParkingSpaceType SpaceType { get; set; }

        public static Input GetInput()
        {
            return new Input()
            {
                ParkingSpaceDetails = new List<In>()
            {
                new In(VehicleType.Car, 80),
                new In(VehicleType.MotorCycle, 100),
                new In(VehicleType.Truck, 10)
            },
                SpaceType = ParkingSpaceType.Mall,
                ParkingDetails = new List<ParkingDetail>()
            {
                new ParkingDetail(VehicleType.MotorCycle, 3, 30),
                new ParkingDetail(VehicleType.Car, 6, 1),
                new ParkingDetail(VehicleType.Truck, 1, 59),

            }

            };

        }

        internal static Input GetInput3()
        {
            return new Input()
            {
                ParkingSpaceDetails = new List<In>()
            {
                new In(VehicleType.Car, 1500),
                new In(VehicleType.MotorCycle, 1000),
            },
                SpaceType = ParkingSpaceType.Stadium,
                ParkingDetails = new List<ParkingDetail>()
            {
                new ParkingDetail(VehicleType.MotorCycle, 3, 40),
                new ParkingDetail(VehicleType.MotorCycle, 14, 59),
                new ParkingDetail(VehicleType.Car, 11, 30),
                new ParkingDetail(VehicleType.Car, 13, 5),
            }
            };
        }

        internal static Input GetInput4()
        {
            return new Input()
            {
                ParkingSpaceDetails = new List<In>()
            {
                new In(VehicleType.Car, 500),
                new In(VehicleType.MotorCycle, 200),
                new In(VehicleType.Truck, 100),

            },
                SpaceType = ParkingSpaceType.Airport,
                ParkingDetails = new List<ParkingDetail>()
            {
                new ParkingDetail(VehicleType.MotorCycle, 0, 55),
                new ParkingDetail(VehicleType.MotorCycle, 14, 59),
                new ParkingDetail(VehicleType.MotorCycle, 36, 0),
                new ParkingDetail(VehicleType.Car, 0, 50),
                new ParkingDetail(VehicleType.Car, 23, 59),
                new ParkingDetail(VehicleType.Car, 73, 0),

            }
            };
        }

    }

    public class In
    {

        public VehicleType VehicleType { get; set; }
        public int Spots { get; set; }

        public In(VehicleType vehicleType11, int Spot)
        {

            this.VehicleType = vehicleType11;
            this.Spots = Spot;
        }
    }

    public class ParkingDetail
    {
        public ParkingDetail(VehicleType vehicleType, int hours, int minutes)
        {
            VehicleType = vehicleType;
            Hours = hours;
            Minutes = minutes;
        }

        public VehicleType VehicleType { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

    }

}
