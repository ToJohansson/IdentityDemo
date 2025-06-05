using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DatesAndTime
{
    class DateAndTime
    {
        public static void Run()
        {
            DateTime myValue = DateTime.Now;
            Console.WriteLine(myValue.ToString());
            Console.WriteLine(myValue.ToShortDateString());
            Console.WriteLine(myValue.ToShortTimeString());
            Console.WriteLine(myValue.ToLongDateString());
            Console.WriteLine(myValue.ToLongTimeString());
            Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            Console.WriteLine(myValue.AddHours(3).ToLongTimeString());
            Console.WriteLine(myValue.AddHours(-3).ToLongTimeString());
            Console.WriteLine(myValue.Month);
            DateTime myBirthday = new DateTime(1991, 7, 2);
            Console.WriteLine(myBirthday.ToShortDateString());
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine((myAge.TotalDays / 365));
        }
    }
}
