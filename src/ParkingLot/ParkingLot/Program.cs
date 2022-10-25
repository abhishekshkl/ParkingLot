
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ParkingLot.Business;
using ParkingLot.Business.Vehicles;
using ParkingLot.Interfaces;
using ParkingLot.Models;

var serviceProvider = new ServiceCollection()
            .AddSingleton<IParking, Parking>()
            .AddSingleton<MotorCycle>()
            .AddSingleton<Car>()
            .AddSingleton<Truck>()
           .AddTransient<IResolver, BusinessResolver>()
            .BuildServiceProvider();

var input = JsonConvert.DeserializeObject<Input>(File.ReadAllText("InputFiles/Input1.json"));
var input3 = JsonConvert.DeserializeObject<Input>(File.ReadAllText("InputFiles/Input2.json"));
var input4 = JsonConvert.DeserializeObject<Input>(File.ReadAllText("InputFiles/Input3.json"));


List<FinalOutputWithInputs> final = new()
{
    new()
{
    Input = input,
    Outputs = GetOutput(serviceProvider, input)
},
    new()
{
    Input = input3,
    Outputs = GetOutput(serviceProvider, input3)
},
    new()
{
    Input = input4,
    Outputs = GetOutput(serviceProvider, input4)
}

};


File.WriteAllText("OutputFiles/Output.json", JsonConvert.SerializeObject(final, Formatting.Indented));





static List<Output> GetOutput(ServiceProvider serviceProvider, Input input)
{
    ParkingSpace parkingSpace = new();

    parkingSpace.SpaceType = input.SpaceType;
    parkingSpace.TicketNumber = 0;
    parkingSpace.Vehicles = new List<Vehicles>();

    foreach (var item in input.ParkingSpaceDetails)
    {
        parkingSpace.Vehicles.Add(new Vehicles()
        {
            VehicleType = item.VehicleType,
            NoOfSpots = item.Spots,
            Spots = Enumerable.Repeat(true, item.Spots).ToList()
        });
    }

    List<Output> output = new();

    foreach (var item in input.ParkingDetails)
    {
        Output result = new();

        var parkingService = serviceProvider.GetService<IParking>();

        result.ParkingTicket = parkingService.ParkVehicle(parkingSpace, item.VehicleType, DateTime.Now);


        result.ParkingReceipt = parkingService.UnParkVehicle(parkingSpace, item.VehicleType, result.ParkingTicket, item.Hours,item.Minutes);

        output.Add(result);
    }

    return output;
}

