using System;
using AlgorithmsDatastructures;

namespace Csharp
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("--------------------------------"); // --------------------------------

            LinkedList<int> lli = new LinkedList<int>();

            for (int i = 0; i < 32; i++)
                lli.append(i);
            Console.WriteLine(lli);

            lli.remove(0);
            lli.remove(1);
            Console.WriteLine(lli);

            lli.insert(8, 1);
            Console.WriteLine(lli);
            
            Console.WriteLine("--------------------------------"); // --------------------------------

            Stack<double> sd = new Stack<double>();

            for (double i = 0; i < 16; i++)
                sd.push(i);
            Console.WriteLine(sd);

            double a = sd.pop(),
                   b = sd.pop();
            Console.WriteLine(sd);

            Console.WriteLine("--------------------------------"); // --------------------------------
            Console.Read();
        }
    }
}
