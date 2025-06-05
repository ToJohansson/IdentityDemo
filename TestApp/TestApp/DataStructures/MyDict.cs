using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.MyVehicles;

namespace TestApp.DataStructures
{
    // Key value pair, key is unique and value can be duplicated
    // searching by key is faster than searching by value
    class MyDict
    {

        public void DictRun()
        {
            Dictionary<int, Vehicle> vehicles = new Dictionary<int, Vehicle>()
            {
                { 12345, new Car(12345, "Citroen", "Picasso c3", 2009, "Blue", "Gasoline", true) },
                { 22346, new Car(22346, "Volvo", "740", 1988, "Brown", "Gasoline", true) },
                { 32347, new Car(32347, "Ford", "Focus", 2016, "Red", "Gasoline", true) },
                { 42348, new Car(42348, "Toyota", "Corolla", 2004, "Green", "Gasoline", true) },
                { 52349, new Car(52349, "Nissan", "Micra", 2003, "Yellow", "Gasoline", true) },
                { 62350, new Car(62350, "Volkswagen", "Golf", 2018, "Black", "Diesel", true) },
                { 72351, new Car(72351, "Audi", "A3", 2007, "White", "Diesel", true) },
                { 82352, new Car(82352, "BMW", "M3", 2022, "Silver", "Diesel", true) },
                { 92353, new Car(92353, "Mercedes", "C-Class", 1997, "Gold", "Diesel", true) },
                { 102354, new Car(102354, "Renault", "Clio", 2001, "Purple", "Gasoline", true) },
                { 112345, new Car(112345, "Citroen", "Picasso c3", 2009, "Blue", "Diesel", true) },
                { 122346, new Car(122346, "Volvo", "740", 1988, "Black", "Gasoline", true) },
                { 132347, new Car(132347, "Ford", "Focus", 2016, "Red", "Diesel", true) },
                { 142348, new Car(142348, "Toyota", "Corolla", 2004, "Green", "Diesel", true) },
                { 152349, new Car(152349, "Nissan", "Micra", 2003, "Yellow", "Diesel", true) },
                { 162350, new Car(162350, "Volkswagen", "Golf", 2018, "Blue", "Gasoline", true) },
                { 172351, new Car(172351, "Audi", "A3", 2007, "White", "Gasoline", true) },
                { 182352, new Car(182352, "BMW", "M3", 2022, "Silver", "Electric", true) },
                { 192353, new Car(192353, "Mercedes", "C-Class", 1997, "Gold", "Electric", true) },
                { 202354, new Car(202354, "Renault", "Clio", 2001, "Purple", "Diesel", true) },
                { 212345, new Car(212345, "Citroen", "Picasso c3", 2009, "Red", "Gasoline", true) },
                { 222346, new Car(222346, "Volvo", "740", 1988, "Brown", "Electric", true) },
                { 232347, new Car(232347, "Ford", "Focus", 2016, "White", "Gasoline", true) },
                { 242348, new Car(242348, "Toyota", "Corolla", 2004, "Silver", "Gasoline", true) },
                { 252349, new Car(252349, "Nissan", "Micra", 2003, "Black", "Gasoline", true) },
                { 262350, new Car(262350, "Volkswagen", "Golf", 2018, "Grey", "Diesel", true) },
                { 272351, new Car(272351, "Audi", "A3", 2007, "Black", "Diesel", true) },
                { 282352, new Car(282352, "BMW", "M3", 2022, "Silver", "Hybrid", true) },
                { 292353, new Car(292353, "Mercedes", "C-Class", 1997, "Blue", "Gasoline", true) },
                { 302354, new Car(302354, "Renault", "Clio", 2001, "Pink", "Gasoline", true) }
            };


            // Mål: Hitta alla bilar där färgen är "Blue".
            // Sortera bilarna efter årsmodell i stigande ordning.
            Console.WriteLine("### Problem 1 ###");
            var query1 = vehicles.Where(v => v.Value.Color == "Blue").OrderBy(v => v.Value.Year);
            foreach (var car in query1)
            {
                Console.WriteLine($"-> {car.Value.ToString()}");
            }

            // Mål: Skapa en lista med bilar sorterade efter år i stigande ordning.
            // Hitta alla bilar som är av bränsletypen "Gasoline" och har årsmodell efter 2005.
            Console.WriteLine("### Problem 2 ###");
            //var query2 = vehicles.OrderBy(v => v.Value.Year);
            var query2 = vehicles.Where(v => v.Value.FuelType == "Gasoline" && v.Value.Year > 2005);
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Value.Year} {item.Value.Model}");
            }

            // Beräkna medelvärdet av årsmodellerna för alla bilar.
            Console.WriteLine("### Problem 3 ###");
            var query3 = vehicles.Average(v => v.Value.Year);
            int averageYear = (int)query3;
            Console.WriteLine($"Average year: {averageYear}");

            // Lista alla bilar som är av märket "Volkswagen" eller "BMW".
            Console.WriteLine("### Problem 4 ###");
            var query4 = vehicles.Where(v => v.Value.Brand == "Volkswagen" || v.Value.Brand == "BMW");
            foreach (var item in query4)
            {
                Console.WriteLine($"{item.Value.Brand} {item.Value.Model} {item.Value.Plate}");
            }

            // Hitta bilen med högsta årsmodell.
            Console.WriteLine("### Problem 5 ###");
            var query5 = vehicles.Select(v => v.Value.Year).Max();
            Console.WriteLine($"Max year: {query5}");

            // Räkna hur många bilar som kör på Diesel.
            Console.WriteLine("### Problem 6 ###");
            var query6 = vehicles.Where(v => v.Value.FuelType == "Diesel").Count();
            Console.WriteLine($"Diesel cars: {query6}");

            //  Hitta alla bilar som är äldre än 10 år (från 2025 räknat).
            Console.WriteLine("### Problem 7 ###");
            int fromYear = 2025;
            var query7 = vehicles.Where(v => v.Value.Year < fromYear);
            foreach (var item in query7)
            {
                Console.WriteLine($"{item.Value.Brand} {item.Value.Model} {item.Value.Plate}");
            }

            // Hämta alla bilar som är av färgen "Black" och har bränsletypen "Diesel".
            Console.WriteLine("### Problem 8 ###");
            var query8 = vehicles.Where(v => v.Value.Color == "Black" && v.Value.FuelType == "Diesel");
            foreach (var item in query8)
            {
                Console.WriteLine($"{item.Value.Brand} {item.Value.Model} {item.Value.Plate}");
            }

            // Lista alla bilar och visa deras modell och årsmodell, men bara för bilar som är yngre än 2010.
            Console.WriteLine("### Problem 9 ###");
            var query9 = vehicles.Where(v => v.Value.Year > 2010).Select(v => new { v.Value.Model, v.Value.Year }).OrderByDescending(v => v.Year);
            foreach (var item in query9)
            {
                Console.WriteLine($"{item.Model} {item.Year}");
            }





        }
    }
}
