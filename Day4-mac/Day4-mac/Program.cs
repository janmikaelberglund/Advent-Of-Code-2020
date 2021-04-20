using System;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace Day4_mac
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string[]> passports = new List<string[]>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string raw = File.ReadAllText(path);

            int validPassports = 0;
            string[] rawModified = raw.Split("\n\n");
            //foreach (var item in rawModified)
            //{
            //    if (item.Contains("ecl") && item.Contains("eyr") && item.Contains("hcl") && item.Contains("byr")
            //        && item.Contains("iyr") && item.Contains("hgt") && item.Contains("pid"))
            //    {
            //        validPassports++;
            //    }
            //}
            //Console.WriteLine(validPassports);

            string[] keys = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            //foreach (var passport in rawModified)
            //{
            //    char[] delimterChars = new char[] { ' ', '\n' };
            //    string[] splitPassport = passport.Split(delimterChars);
            //    int numberOfValidValues = 0;
            //
            //    foreach (var value in splitPassport)
            //    {
            //        string[] temp = value.Split(":");
            //        if (CheckKeys(keys, temp[0]))
            //        {
            //            numberOfValidValues++;
            //        }
            //    }
            //    if (numberOfValidValues == 7)
            //    {
            //        validPassports++;
            //    }
            //}

            foreach (var passport in rawModified)
            {
                char[] delimterChars = new char[] { ' ', '\n' };
                string[] splitPassport = passport.Split(delimterChars);
                int numberOfValidValues = 0;

                foreach (var value in splitPassport)
                {
                    string[] temp = value.Split(":");
                    if (CheckValidKeys(temp[0], temp[1]))
                    {
                        numberOfValidValues++;
                    }
                }
                if (numberOfValidValues == 7)
                {
                    validPassports++;
                }
            }


            Console.WriteLine(validPassports);
        }

        private static bool CheckKeys(string[] keys, string temp)
        {
            foreach (var key in keys)
            {
                if (key == temp)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckValidKeys(string type, string value)
        {
            if (type == "byr")
            {
                if (int.Parse(value) > 1919 && int.Parse(value) < 2002)
                {
                    return true;
                }
            }
            else if (type == "iyr")
            {
                if (int.Parse(value) > 2009 && int.Parse(value) < 2021)
                {
                    return true;
                }
            }
            else if (type == "eyr")
            {
                if (int.Parse(value) > 2019 && int.Parse(value) < 2031)
                {
                    return true;
                }
            }
            else if (type == "hgt")
            {
                if (value.Contains("in"))
                {
                    value = value.Remove(value.Length - 2);
                    if (int.Parse(value) > 58 && int.Parse(value) < 77)
                    {
                        return true;
                    }
                }
                if (value.Contains("cm"))
                {
                    value = value.Remove(value.Length - 2);
                    if (int.Parse(value) > 149 && int.Parse(value) < 194)
                    {
                        return true;
                    }
                }
            }
            else if (type == "hcl")
            {
                if (CheckColor(value))
                {
                    return true;
                }
            }
            else if (type == "ecl")
            {
                string[] validColors = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                foreach (var color in validColors)
                {
                    if (value == color)
                    {
                        return true;
                    }
                }
            }
            else if (type == "pid")
            {
                if (value.Length == 9 && int.TryParse(value, out int result))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckColor(string value)
        {
            if (value[0] == '#' && value.Length == 7)
            {
                for (int i = 1; i < value.Length -1; i++)
                {
                    if (((char)value[i] > 47 && (char)value[i] < 58) || ((char)value[i] > 96 && (char)value[i] < 103))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
