using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _4A.BigArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bigArray = new int[100_000_000];
            Random random = new(DateTime.Now.Millisecond);
            Dictionary<int, int> elementCounts = [];
            List<int> duplicates = [];

            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = random.Next();
            }

            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in bigArray)
            {
                if (!elementCounts.ContainsKey(item))
                {
                    elementCounts[item] = 1;
                }
                else
                {
                    elementCounts[item]++;
                    if (elementCounts[item] == 2)
                    {
                        duplicates.Add(item);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Затраченное на обработку время: {sw.Elapsed.Seconds} секунд");
            Console.WriteLine($"Найдено повторяющихся элементов: {duplicates.Count}");
        }
    }
}
