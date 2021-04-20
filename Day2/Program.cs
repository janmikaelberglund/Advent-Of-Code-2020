using System;
using System.IO;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Input> inputs = new List<Input>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Answers.txt");

            using StreamReader sr = new StreamReader(path);
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] temp = input.Split(" ");
                    string[] tempRange = temp[0].Split("-");
                    inputs.Add(new Input(int.Parse(tempRange[0]), int.Parse(tempRange[1]), temp[1], temp[2]));
                    input = sr.ReadLine();
                }
            }


            int correctPasswordCount = 0;

            //correctPasswordCount = Day1Part1(inputs, correctPasswordCount);


            correctPasswordCount = Day1Part2(inputs, correctPasswordCount);

            Console.WriteLine();
            Console.WriteLine(correctPasswordCount);
        }

        private static int Day1Part2(List<Input> inputs, int correctPasswordCount)
        {
            foreach (var row in inputs)
            {
                if ((row.Password[row.MinValue - 1] == row.Wildcard[0] && row.Password[row.MaxValue - 1] != row.Wildcard[0]) 
                    || (row.Password[row.MinValue - 1] != row.Wildcard[0] && row.Password[row.MaxValue - 1] == row.Wildcard[0]))
                {
                    correctPasswordCount++;
                }
            }


            return correctPasswordCount;
        }
        private static int Day1Part1(List<Input> inputs, int correctPasswordCount)
        {
            foreach (var row in inputs)
            {
                int count = 0;
                foreach (var letter in row.Password)
                {
                    if (letter == row.Wildcard[0])
                    {
                        count++;
                    }
                }
                if (count >= row.MinValue && count <= row.MaxValue)
                {
                    correctPasswordCount++;
                    Console.WriteLine($"{row.MinValue} - {row.MaxValue} {row.Wildcard} {row.Password}");
                    Console.Write($" - {count} {row.Wildcard[0]}");
                }
            }

            return correctPasswordCount;
        }
    }
}
