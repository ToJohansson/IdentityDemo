using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MyVehicles
{
    abstract class Vehicle
    {
        public int Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }

        public Vehicle(int plate, string brand, string model, int year, string color, string fuelType)
        {
            Plate = plate;
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            FuelType = fuelType;
        }
        public Vehicle()
        {

        }

        // Abstract method to be overridden in derived classes
        public abstract void Drive();

        // Virtual method to be optionally overridden in derived classes
        public virtual void Refuel()
        {
            Console.WriteLine("Refueling...");
        }
        public virtual void Fuel()
        {
            Console.WriteLine($"{FuelType} is needed for this vehicle.");
        }
        public abstract void Stop();

    }
}
