using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] rawData = File.ReadAllLines(filePath);
            int[] intData = new int[rawData.Length];

            int index = 0;
            foreach (var entry in rawData)
            {
                intData[index] = int.Parse(rawData[index]);
                index++;
            }

            Array.Sort(intData);

            int oneJolt = 1;
            int twoJolt = 0;
            int threeJolt = 1;

            index = FirstPart(intData, ref oneJolt, ref twoJolt, ref threeJolt);

            

        }

        private static int FirstPart(int[] intData, ref int oneJolt, ref int twoJolt, ref int threeJolt)
        {
            int i;
            foreach (var entry in intData)
            {
                Console.WriteLine(entry);
            }

            for (i = 0; i < intData.Length - 1; i++)
            {
                if (intData[i + 1] - intData[i] == 1)
                {
                    oneJolt++;
                }
                else if (intData[i + 1] - intData[i] == 2)
                {
                    twoJolt++;
                }
                else if (intData[i + 1] - intData[i] == 3)
                {
                    threeJolt++;
                }
            }
            Console.WriteLine(oneJolt * threeJolt);
            return i;
        }
    }
}
