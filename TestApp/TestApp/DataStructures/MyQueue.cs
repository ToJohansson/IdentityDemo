using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataStructures
{
    // FIFO - First in first out
    class MyQueue
    {
        public void QueueRun()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Tobias");
            queue.Enqueue("Klara");
            queue.Enqueue("Barbro");
            queue.Enqueue("Viggo");

            int index = 4;
            while (queue.Count > 0)
            {
                var person = queue.Dequeue();
                Console.WriteLine($"{person} is served");
                if (queue.Count > 0)
                {
                    Console.WriteLine($"Next up: {queue.Peek()}");
                }
                foreach (var remainingPerson in queue)
                {
                    Console.WriteLine($"--> {remainingPerson}");
                }
                if (index == 1)
                {
                    queue.Enqueue("Bosse");
                    Console.WriteLine("Bosse added to the queue");
                }
                if (!queue.Contains("Klara") && index == 2)
                {
                    queue.Enqueue("Klara");
                    Console.WriteLine("Klara added to the queue");
                }
                else
                {
                    if (queue.Contains("Klara"))
                    {
                        Console.WriteLine("Klara is already in the queue");
                    }
                }

                index--;

            }
        }
    }
}
