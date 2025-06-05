using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataStructures
{
    class MyArrays
    {
        public int[] IntArray { get; set; }
        public char[] CharArray { get; set; }
        public string[] StringArray { get; set; }

        public MyArrays()
        {

        }
        public void IntergerRun()
        {
            Random random = new Random();

            IntArray = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int randomInt = random.Next(50, 100);
                IntArray[i] = randomInt;
                Console.WriteLine($"i = {i}, IntArray element = {IntArray[i]}");
            }
            Console.WriteLine($"");

            for (int i = 0; i < IntArray.Length; i++)
            {
                if (IntArray[i] % 2 == 0)
                {
                    Console.WriteLine($"IntArray element {i} is even, element = {IntArray[i]}");
                }
                else
                {
                    Console.WriteLine($"IntArray element {i} is odd, element = {IntArray[i]}");
                }

                if (IntArray[i] > 75)
                {
                    Console.WriteLine($"IntArray element {i} is greater than 75, element = {IntArray[i]}");
                }
                else
                {
                    Console.WriteLine($"IntArray element {i} is less than 75, element = {IntArray[i]}");
                }
                Console.WriteLine($"");

            }
            Array.Sort(IntArray);
            for (int i = 0; i < IntArray.Length; i++)
            {
                Console.WriteLine($"sorted = {IntArray[i]}");
            }
            Console.WriteLine($"#################");

        }
        public void CharArrayRun()
        {
            string message = "SWEDEN";
            CharArray = message.ToCharArray();

            Array.Reverse(CharArray);

            Console.WriteLine(new string(CharArray));

        }
        public void StringArrayRun()
        {
            StringArray = new string[5];
            StringArray[0] = "Umeå";
            StringArray[1] = "Varberg";
            StringArray[2] = "Öland";
            StringArray[3] = "Stockholm";
            StringArray[4] = "Gothenburg";

            for (int i = 0; i < StringArray.Length; i++)
            {
                char[] charArr = StringArray[i].ToCharArray();
                Array.Reverse(charArr);
                StringArray[i] = new string(charArr);
            }
            Console.WriteLine("########## CITY REVERSE ########");

            foreach (string s in StringArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("########## NAME REVERSE ########");
            String[] names = { "Tobias", "Klara", "Barbro", "Viggo" };

            // Detta är en Select metod som tar en string och gör om den
            // till en ny string som är reverserad
            names = names.Select(name => new string(name.Reverse().ToArray())).ToArray();

            // Detta är en for loop som gör samma sak som Select metoden ovan
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = new string(names[i].Reverse().ToArray());
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            // Ordinal sort, letters compare by their unicode values
            Console.WriteLine("-- Ordinal sort, letters compare by their unicode values --");

            Array.Sort(StringArray);
            foreach (string s in StringArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("########################");

            // Swedish culture sort, letters compare by their swedish values
            Console.WriteLine("-- Swedish culture sort, letters compare by theiral phabetical values --");
            Array.Sort(StringArray, StringComparer.Create(new CultureInfo("sv-SE"), false));

            foreach (string s in StringArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("########################");



        }

    }

}
