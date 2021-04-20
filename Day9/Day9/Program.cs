using System;
using System.IO;
using System.Collections.Generic;

namespace Day9
{
    class Program
    {
        public static int svarI;
        public static int svarJ;
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] raw = File.ReadAllLines(filePath);
            long[] rawInput = new long[raw.Length];
            for (int i = 0; i < raw.Length; i++)
            {
                rawInput[i] = long.Parse(raw[i]);
            }

            //int indexOfNumberToCheck = 25;
            //while (CheckValidNumber(indexOfNumberToCheck, rawInput))
            //{
            //    indexOfNumberToCheck++;
            //    CheckValidNumber(indexOfNumberToCheck, rawInput);
            //}
            //Console.WriteLine(rawInput[indexOfNumberToCheck]);

            long previousAnswer = 14360655;

            CheckValidNumberPart2(previousAnswer, rawInput);

            long lowest = rawInput[svarI];
            long highest = 0;


            Console.WriteLine($"I: {svarI} - J: {svarJ}");

            for (int i = svarI; i <= svarJ - 1; i++)
            {
                Console.WriteLine(lowest);
                if (highest < rawInput[i])
                {
                    highest = rawInput[i];
                }
                if (lowest > rawInput[i])
                {
                    lowest = rawInput[i];
                }
            }

            Console.WriteLine($"Lowest {lowest} - Highest {highest}");

            Console.WriteLine($"Lowest + Highest; {lowest + highest}");

        }

        private static void CheckValidNumberPart2(long previousAnswer, long[] rawInput)
        {
            for (int i = 0; i < rawInput.Length; i++)
            {
                long checkAnswer = previousAnswer;
                checkAnswer -= rawInput[i];
                for (int j = i + 1; j < rawInput.Length; j++)
                {
                    checkAnswer -= rawInput[j];
                    if (checkAnswer < 0)
                    {
                        break;
                    }
                    if (checkAnswer == 0)
                    {
                        svarI = i;
                        svarJ = j;
                    }
                }
            }
        }

        private static bool CheckValidNumber(int indexOfNumberToCheck, long[] rawInput)
        {
            for (int i = indexOfNumberToCheck - 25; i < indexOfNumberToCheck; i++)
            {
                for (int j = indexOfNumberToCheck - 25; j < indexOfNumberToCheck; j++)
                {
                    if ((rawInput[i] + rawInput[j]) == rawInput[indexOfNumberToCheck])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
