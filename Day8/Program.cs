using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Code> codes = new List<Code>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] rawInput = File.ReadAllLines(filePath);
            List<int> savedIndexList = new List<int>();
            foreach (var codeLine in rawInput)
            {
                string[] splitCodeLine = codeLine.Split(" ");
                codes.Add(new Code(splitCodeLine[0], splitCodeLine[1]));
            }

            string changeType = "nop";
            string typeToChangeTo = "jmp";
            int testedIndex = 0;

            while (!RunCode(codes, savedIndexList))
            {
                codes = new List<Code>();
                rawInput = File.ReadAllLines(filePath);
                savedIndexList = new List<int>();
                foreach (var codeLine in rawInput)
                {
                    string[] splitCodeLine = codeLine.Split(" ");
                    codes.Add(new Code(splitCodeLine[0], splitCodeLine[1]));
                }
                int indexToChange = codes.FindIndex(testedIndex, c => c.CodeType == changeType);
                codes[indexToChange].CodeType = typeToChangeTo;
                testedIndex = indexToChange + 1;
                Console.WriteLine(testedIndex);
            }
            
        }

        private static bool RunCode(List<Code> codes, List<int> savedIndexList)
        {
            int acc = 0;
            int index = 0;
            while (!savedIndexList.Contains(index))
            {
                savedIndexList.Add(index);
                if (codes[index].CodeType == "acc")
                {
                    if (codes[index].CodeNumber[0] == '+')
                    {
                        acc += int.Parse(codes[index].CodeNumber[1..]);
                    }
                    else
                    {
                        acc -= int.Parse(codes[index].CodeNumber[1..]);
                    }
                    index++;
                }
                if (codes[index].CodeType == "nop")
                {
                    index++;
                }
                if (codes[index].CodeType == "jmp")
                {
                    if (codes[index].CodeNumber[0] == '+')
                    {
                        index += int.Parse(codes[index].CodeNumber[1..]);
                    }
                    else
                    {
                        index -= int.Parse(codes[index].CodeNumber[1..]);
                    }
                }
                if (index == 647)
                {
                    Console.WriteLine(acc);
                    return true;
                }
            }
            return false;
        }
    }
}
