using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MyVehicles
{
    class Car : Vehicle
    {
        public bool HasWheels { get; set; }
        public Car()
        {
        }

        public Car(int plate, string brand, string model, int year, string color, string fuelType, bool HasWheels) : base(plate, brand, model, year, color, fuelType)
        {
            this.HasWheels = HasWheels;
        }

        public override void Drive()
        {
            Console.WriteLine($"{Brand} {Model} is driving.");
        }


        public override void Stop()
        {
            Console.WriteLine("Car has stopped.");
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
                $"HasWheels: {HasWheels}";

        }

    }
}
