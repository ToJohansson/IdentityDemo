using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MyVehicles
{
    class MyVehicles
    {
        public static void Run()
        {
            Vehicle car = new Car(12345, "Citroen", "Picasso c3", 2009, "Blue", "Gasoline", true);

            Vehicle boat = new Boat(54321, "Yamaha", "WaveRunner", 2015, "Yellow", "Diesel", true);

            Vehicle aeroplane = new Aeroplane(67890, "Boeing", "747", 2010, "White", "Kerosene", true);

            List<Vehicle> vehicles = new List<Vehicle> { car, boat, aeroplane };
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
                vehicle.Drive();
                vehicle.Fuel();
                vehicle.Refuel();
                vehicle.Stop();
                Console.WriteLine("");
            }
        }
    }
}
