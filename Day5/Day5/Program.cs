using System;
using System.IO;
using System.Collections.Generic;

namespace Day5
{
    class Program
    {
        public static int[,] airPlaneSeats = new int[128,8];
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "input.txt");
            string[] raw = File.ReadAllLines(path);
            List<int> airPlane = new List<int>();


            foreach (var line in raw)
            {
                int rowSpan = 64;
                int row = 0;
                int seatSpan = 4;
                int seat = 0;
                foreach (var letter in line)
                {
                    if (letter == 'F' || letter == 'B')
                    {
                        if (letter == 'B')
                        {
                            row += rowSpan;
                        }
                        rowSpan /= 2;
                    }
                    else
                    {
                        if (letter == 'R')
                        {
                            seat += seatSpan;
                        }
                        seatSpan /= 2;
                    }
                }
                Console.WriteLine($"{row} , {seat}");
                airPlane.Add(row * 8 + seat);

                FillAirplaneSeats(row, seat);
            }

            int answer = 0;
            foreach (var item in airPlane)
            {
                if (answer < item)
                    answer = item;
            }
            Console.WriteLine(answer);


            int mySeat = 0;
            int myRow = 0;
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i > 20 && i < 100 && airPlaneSeats[i,j] == 0)
                    {
                        myRow = i;
                        mySeat = j;
                        Console.WriteLine($"{i} {j}");
                    }
                }
            }
            Console.WriteLine(myRow * 8 + mySeat);

            string boardingPass = "";
            int mySeatSpan = 64;
            for (int i = 0; i < 7; i++)
            {
                if (mySeat > mySeatSpan)
                {
                    boardingPass += 'B';
                    mySeat -= mySeatSpan;
                }
                else
                {
                    boardingPass += 'F';
                }
                mySeatSpan /= 2;
            }

            int myRowSpan = 4;
            for (int i = 0; i < 3; i++)
            {
                if (myRow > myRowSpan)
                {
                    boardingPass += 'R';
                    myRow -= myRowSpan;
                }
                else
                {
                    boardingPass += 'L';
                }
                myRowSpan /= 2;
            }
            Console.WriteLine(boardingPass);

        }

        private static void FillAirplaneSeats(int row, int seat)
        {
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == row && j == seat)
                    {
                        airPlaneSeats[i, j] = 1;
                    }
                }
            }
        }
    }
}
