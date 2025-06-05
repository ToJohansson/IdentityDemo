using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataStructures
{
    // List is a Dynamic array, can grow and shrink in size
    class MyList
    {

        public void ListRun()
        {
            List<int> intList = new List<int>();
            Random random = new Random();

            // setup
            for (int i = 0; i < 5; i++)
            {
                int randomInt = random.Next(1, 100);
                intList.Add(randomInt);
            }


            Console.WriteLine("Original List");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.Sort();
            Console.WriteLine("Sorted List");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.Reverse();
            Console.WriteLine("Reversed List");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.AddRange(new int[] { 777, 666, 555 });
            Console.WriteLine("Adding elements from another collection");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.Insert(2, 888);
            Console.WriteLine("insert value at index 2");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");


            intList.InsertRange(4, new int[] { 999, 999, 999 });
            Console.WriteLine("insert a range of values at index 4");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.Remove(999);
            Console.WriteLine("remove first aperence of 999");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.RemoveAt(5);
            Console.WriteLine("remove at index 5");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            intList.RemoveAll(x => x > 80);
            Console.WriteLine("remove all where x is bigger than 80");
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            Console.WriteLine("sorting list and adding two int values {999, 999}");
            intList.Sort();
            intList.Add(999);
            intList.Add(999);

            Console.WriteLine("check if contains value 999 and return a boolean");
            bool exists = intList.Contains(999);
            Console.WriteLine(exists);
            Console.WriteLine("");
            Console.WriteLine("returns index of the first appearnce of element 999");
            int firstIndex = intList.IndexOf(999);
            Console.WriteLine(firstIndex);
            Console.WriteLine("");
            Console.WriteLine("returns index of the first appearnce of element 999");
            int lastIndex = intList.LastIndexOf(999);
            Console.WriteLine(lastIndex);
            Console.WriteLine("");


            intList.Clear();
            Console.WriteLine("clear list = empty list");
            if (intList.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                Console.WriteLine("List is not empty");
            }
            Console.WriteLine("");
        }
    }
}
