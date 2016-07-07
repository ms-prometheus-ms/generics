using System;
using System.Collections.Generic;

namespace Prometheus
{
    class Program1
    {
        static void Main1(string[] args)
        {
            РадіснийМетод();
        }
        static void СумнийМетод()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            // Add an integer to the list.
            list.Add(3);
            // Add a string to the list. This will compile, but may cause an error later.
            list.Add("It is raining in Redmond.");

            int t = 0;
            // This causes an InvalidCastException to be returned.
            foreach (int x in list)
            {
                t += x;
            }
        }

        static void РадіснийМетод()
        {
            // The .NET Framework 2.0 way to create a list
            List<int> list1 = new List<int>();

            // No boxing, no casting:
            list1.Add(3);

            // Compile-time error:
            // list1.Add("It is raining in Redmond.");

            Console.WriteLine("Я закінчив своє виконання без помилок :)");
        }
    }
}
