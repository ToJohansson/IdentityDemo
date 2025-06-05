using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MyVehicles
{
    class Boat : Vehicle
    {
        public bool Floats { get; set; }
        public Boat()
        {
        }

        public Boat(int plate, string brand, string model, int year, string color, string fuelType, bool Floats) : base(plate, brand, model, year, color, fuelType)
        {
            this.Floats = Floats;
        }

        public override void Drive()
        {
            Console.WriteLine($"{Brand} {Model}is moving on water.");
        }

        public override void Fuel()
        {
            Console.WriteLine($"{FuelType} is needed for this boat.");
        }

        public override void Refuel()
        {
            Console.WriteLine($"Boat is refueled with {FuelType}.");
        }

        public override void Stop()
        {
            Console.WriteLine("Boat has stopped.");
        }

        public override string ToString()
        {
            return $"" +
                $"Plate: {Plate}, " +
                $"Brand: {Brand}, " +
                $"Model: {Model}, " +
                $"Year: {Year}, " +
                $"Color: {Color}, " +
                $"FuelType: {FuelType}, " +
                $"Floats: {Floats}";
        }
    }
}
