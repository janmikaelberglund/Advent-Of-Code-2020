using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputInformation = new List<int>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Answers.txt");
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    inputInformation.Add(int.Parse(input));
                    input = sr.ReadLine();
                }
            }

            //Day1part1(inputInformation, savepath);

            Day1part2(inputInformation, savepath);


        }

        private static void Day1part1(List<int> inputInformation, string savepath)
        {
            int save1 = 0;
            int save2 = 0;
            for (int i = 0; i < inputInformation.Count; i++)
            {
                for (int j = 0; j < inputInformation.Count; j++)
                {
                    if (i != j && inputInformation[i] + inputInformation[j] == 2020)
                    {
                        save1 = inputInformation[i];
                        save2 = inputInformation[j];
                    }
                }
            }

            Console.WriteLine($"{save1} + {save2} = {save1 + save2}");
            Console.WriteLine($"{save1} * {save2} = {save1 * save2}");

            using (StreamWriter sw = new StreamWriter(savepath, true))
            {
                sw.WriteLine();
                sw.WriteLine(save1 * save2);
            }
        }
        private static void Day1part2(List<int> inputInformation, string savepath)
        {
            int save1 = 0;
            int save2 = 0;
            int save3 = 0;
            for (int i = 0; i < inputInformation.Count; i++)
            {
                for (int j = 0; j < inputInformation.Count; j++)
                {
                    for (int k = 0; k < inputInformation.Count; k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            if (inputInformation[i] + inputInformation[j] + inputInformation[k] == 2020)
                            {
                                save1 = inputInformation[i];
                                save2 = inputInformation[j];
                                save3 = inputInformation[k];
                            }
                        }
                        
                    }
                }
            }

            Console.WriteLine($"{save1} + {save2} + {save3} = {save1 + save2 + save3}");
            Console.WriteLine($"{save1} * {save2} * {save3} = {save1 * save2 * save3}");

            using (StreamWriter sw = new StreamWriter(savepath, true))
            {
                sw.WriteLine();
                sw.WriteLine(save1 * save2 * save3);
            }
        }
    }
}
