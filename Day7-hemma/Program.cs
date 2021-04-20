using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day7_hemma
{
    class Program
    {
        public static List<Bag> bags = new List<Bag>();
        public static int count = 0;
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] rawInput = File.ReadAllLines(filePath);
            bags.Add(new Bag(1, "shiny gold"));

            while (bags.Count != 0)
            {
                foreach (var item in bags)
                {
                    Console.WriteLine($"{item.NumberOfBags} - {item.BagType}");
                }
                CheckBags(rawInput);
            }

            Console.WriteLine(count);
        }

        private static void CheckBags(string[] rawInput)
        {
            List<Bag> bagsToRemove = new List<Bag>();
            List<Bag> bagsToAdd = new List<Bag>();

            foreach (var bag in bags)
            {
                if (bag.BagType.StartsWith("n"))
                {
                    bagsToRemove.Add(bag);
                    continue;
                }

                foreach (var item in rawInput)
                {
                    if (item.StartsWith(bag.BagType))
                    {
                        string[] firstSplit = item.Split(".");
                        string[] secondSplit = firstSplit[0].Split("contain ");
                        string[] thirdSplit = secondSplit[1].Split(", ");
                        foreach (var splitBag in thirdSplit)
                        {
                            if (splitBag.StartsWith("n"))
                            {
                                continue;
                            }
                            string[] bagNumberSplit = splitBag.Split(" ");
                            int bagNumber = int.Parse(bagNumberSplit[0]);
                            string bagType = bagNumberSplit[1];
                            for (int i = 2; i < bagNumberSplit.Count(); i++)
                            {
                                bagType += " " + bagNumberSplit[i];
                            }
                            bagNumber = bagNumber * bag.NumberOfBags;
                            bagsToAdd.Add(new Bag(bagNumber, bagType));
                            count += bagNumber;
                        }
                    }
                }

                bagsToRemove.Add(bag);
            }
            foreach (var bag in bagsToRemove)
            {
                bags.Remove(bag);
            }
            foreach (var bag in bagsToAdd)
            {
                bags.Add(bag);
            }
        }
    }
}
