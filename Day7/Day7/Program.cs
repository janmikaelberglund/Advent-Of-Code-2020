using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        public static int count = 0;
        public static List<string> checkedBags = new List<string>();
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] raw = File.ReadAllLines(path);
            List<string> bagsToCheck = new List<string>();
            bagsToCheck.Add("1 shiny gold");

            //while (listToCheck.Count != 0)
            //{
            //    listToCheck = CheckBag(raw, listToCheck);
            //}
            //checkedBags.Sort();
            //
            //List<string> checkedBagsnew = new List<string>();
            //foreach (var item in checkedBags)
            //{
            //    if (!checkedBagsnew.Contains(item) && item != "shiny gold")
            //    {
            //        checkedBagsnew.Add(item);
            //    }
            //}
            //
            //Console.WriteLine("Antal kontrollerade strängar utan dubletter: " + checkedBagsnew.Count);
            //Console.WriteLine("Svar: " + count);

            while (bagsToCheck.Count != 0)
            {
                bagsToCheck = CheckBagContents(raw, bagsToCheck);
            }


            Console.WriteLine(count);
        }

        private static List<string> CheckBagContents(string[] raw, List<string> bagsToCheck)
        {
            List<string> tempList = new List<string>();
            foreach (var inputString in bagsToCheck)
            {
                Console.WriteLine();
                Console.WriteLine(inputString);
                foreach (var row in raw)
                {
                    string[] splitInputString = row.Split(" ");
                    string checkString = splitInputString[1] + " " + splitInputString[2];
                    Console.WriteLine(checkString);
                    if (row.StartsWith(checkString))
                    {
                        Console.WriteLine(row);
                        string[] removeStartbag = row.Split("contain ");
                        string[] splitRow = removeStartbag[1].Split(", ");
                        splitRow[(splitRow.Count() - 1)] = splitRow[(splitRow.Count() - 1)][..^1];
                        foreach (var bag in splitRow)
                        {
                            string[] checkBag1 = bag.Split(" ");
                            string checkBag = checkBag1[1] + " " + checkBag1[2];
                            if (bag[0] != 'n' && !checkedBags.Contains(checkBag))
                            {
                                count += int.Parse(splitInputString[0]) * int.Parse(checkBag1[0].ToString());
                                string temp = (int.Parse(splitInputString[0]) * int.Parse(checkBag1[0].ToString())) + " " + checkBag;
                                tempList.Add(temp);
                                checkedBags.Add(checkBag);
                            }
                        }
                    }
                }
            }
            return tempList;
        }

        private static List<string> CheckBag(string[] raw, List<string> listToCheck)
        {
            List<string> tempList = new List<string>();
            foreach (var inputString in listToCheck)
            {
                foreach (var item in raw)
                {
                    if (!item.StartsWith(inputString) && !checkedBags.Contains(inputString) && item.Contains(inputString))
                    {
                        string[] tempBag = item.Split(" bag");
                        if (!tempList.Contains(tempBag[0]) && !checkedBags.Contains(tempBag[0]))
                        {
                            count++;
                            tempList.Add(tempBag[0]);
                        }
                    }
                }
                checkedBags.Add(inputString);
            }
            return tempList;
        }
    }
}
