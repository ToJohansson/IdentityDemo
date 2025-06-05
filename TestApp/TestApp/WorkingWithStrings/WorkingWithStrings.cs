using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WorkingWithStrings
{
    class WorkingWithStrings
    {
        public static void Run()
        {

            string message1 = "My \"so-called \" life"; // escape character
            string message2 = "C:\\Windows\\..."; // double backslah to 
            string message3 = @"C:\Windows\..."; // @ to ignore backslashes
            string message4 = string.Format("{0:C}", 123.45); // currency format
            string message5 = string.Format("{0:N}", 1234567890); // number format
            string message6 = string.Format("Percentage: {0:P}", .123); // percentage format
            string message7 = string.Format("Phone Number: {0:(+##) ###-###-###}", 46768358899); // phone number format

            string[] messageArray = [message1, message2, message3, message4, message5, message6, message7];

            foreach (string message in messageArray)
            {
                Console.WriteLine(message);
            }

            string str = "  This is a string ";
            str = string.Format("string length before: {0} -- string length after {1} -- string length trim whitespaces {2}",
                str.Length,
                str.Trim().Length,
                str.Replace(" ", "").Length);


            Console.WriteLine("STARTING TEST");
            int iterations = 100_000;

            // bevisa att StringBuilder är snabbare än att använda strängkonkatenering
            Stopwatch sw1 = Stopwatch.StartNew();
            str = "";
            for (int i = 0; i < iterations; i++)
            {
                str += "--" + i; // kommer skapa en ny sträng varje gång
            }
            sw1.Stop();
            Console.WriteLine($"String concatenation took: {sw1.ElapsedMilliseconds} ms");

            Stopwatch sw2 = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("--").Append(i); // bygger på samma sträng
            }
            sw2.Stop();
            Console.WriteLine($"StringBuilder took: {sw2.ElapsedMilliseconds} ms");
        }
    }
}
