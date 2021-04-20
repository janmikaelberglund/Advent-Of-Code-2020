using System;
using System.IO;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Answers.txt");

            using StreamReader sr = new StreamReader(path);
            {
                string input = sr.ReadLine();
                int count = 0;
                while (input != null)
                {
                    inputs.Add(input);
                    input = sr.ReadLine();
                    count++;
                }
            }
            long treesCount = 0;

            int tree1 = Tobagon(inputs, 1, 3);
            int tree2 = Tobagon(inputs, 1, 1);
            int tree3 = Tobagon(inputs, 1, 5);
            int tree4 = Tobagon(inputs, 1, 7);
            int tree5 = Tobagon(inputs, 2, 1);

            treesCount = (long)tree1 * (long)tree2 * (long)tree3 * (long)tree4 * (long)tree5;


            Console.WriteLine(tree1);
            Console.WriteLine(tree2);
            Console.WriteLine(tree3);
            Console.WriteLine(tree4);
            Console.WriteLine(tree5);
            Console.WriteLine(treesCount);
        }

        private static int Tobagon(List<string> inputs, int drop, int right)
        {
            int i = 0;
            int j = 0;
            int lenght = inputs[0].Length;
            int treeCount = 0;
            while (i < inputs.Count)
            {
                if (j >= lenght)
                {
                    j -= lenght;
                }
                if (inputs[i][j] == '#')
                {
                    treeCount++;
                }
                j += right;
                i += drop;
            }

            return treeCount;
        }
    }
}
