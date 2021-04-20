using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string raw = File.ReadAllText(path);
            string[] groups = raw.Split("\n\n");

            //int count = 0;
            //foreach (var group in groups)
            //{
            //    string tempRow = "";
            //    string temp = "";
            //    foreach (var row in group)
            //    {
            //        tempRow += row;
            //    }
            //    for (int i = 0; i < tempRow.Length; i++)
            //    {
            //        if (!temp.Contains(tempRow[i]) && tempRow[i] != '\n')
            //        {
            //            temp += tempRow[i];
            //        }
            //    }
            //    Console.WriteLine(temp);
            //    Console.WriteLine(temp.Length);
            //    count += temp.Length;
            //}
            //Console.WriteLine(count);

            int count = 0;
            foreach (var group in groups)
            {
                string[] individuals = group.Split('\n');
                int longestAnswer = 0;
                if (individuals.Count() == 1)
                {
                    count += individuals[0].Count();
                    continue;
                }
                for (int i = 0; i < individuals.Count() - 1; i++)
                {
                    if (individuals[i].Length < individuals[i + 1].Length)
                    {
                        longestAnswer = i + 1;
                    }
                }

                for (int i = 0; i < individuals[longestAnswer].Length; i++)
                {
                    int equalAnswers = 1;
                    for (int j = 0; j < individuals.Count(); j++)
                    {
                        if (j != longestAnswer && individuals[j].Contains(individuals[longestAnswer][i]))
                        {
                            equalAnswers++;
                        }
                    }
                    if (equalAnswers == individuals.Count())
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }
}
