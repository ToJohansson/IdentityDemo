using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.HelperMethods
{
    class HelperMethods
    {
        public static void Run()
        {
            Console.WriteLine("Enter your firstname");
            string firstname = Console.ReadLine();

            Console.WriteLine("Enter your lastname");
            string lastname = Console.ReadLine();

            Display((ReverseName(firstname) + " " + ReverseName(lastname)));
        }
        private static string ReverseName(string message)
        {
            char[] s = message.ToCharArray();
            Array.Reverse(s);
            return new String(s);

        }
        private static void Display(string message)
        {
            Console.WriteLine(message);
        }

    }
}
