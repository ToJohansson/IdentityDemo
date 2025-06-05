using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataStructures
{
    // LIFO - Last in first out
    class MyStack
    {
        public void StackRun()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("LIFO");
            foreach (var item in stack)
            {
                Console.WriteLine($"Stack: {item}");
            }
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Peek: {stack.Peek()}");

        }
    }
}
