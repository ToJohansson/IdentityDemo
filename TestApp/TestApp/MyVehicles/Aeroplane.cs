using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MyVehicles
{
    class Aeroplane : Vehicle
    {
        public bool IsFlying { get; set; }
        public Aeroplane()
        {
        }

        public Aeroplane(int plate, string brand, string model, int year, string color, string fuelType, bool IsFlying) : base(plate, brand, model, year, color, fuelType)
        {
            this.IsFlying = IsFlying;
        }



        public override void Drive()
        {
            if (IsFlying)
            {
                Console.WriteLine("Aeroplane is flying.");
            }
            else
            {
                Console.WriteLine("Aeroplane is on the ground.");
            }
        }
        public override void Fuel()
        {
            Console.WriteLine($"{FuelType} is needed for this aeroplane.");
        }

        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} has landed");
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
                $"IsFlying: {IsFlying}";
        }
    }
}
