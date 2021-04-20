using System;
using System.IO;
using System.Collections.Generic;

namespace Day4
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
                while (input != null)
                {

                    input = sr.ReadLine();
                }
            }
        }
    }
}
