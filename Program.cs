using System;
using System.Collections.Generic;
using System.IO;

namespace aoc5
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] binary = new char[10];
            int maxseatid = int.MinValue;
            var allseatids = new List<int>();

            foreach (string line in File.ReadLines(@"C:\Repos\aoc5\input\binaries.txt"))
            {
                binary = line.ToCharArray();   //binary = "FBFBBFFRLR".ToCharArray();
                int row = GetRow(binary);
                int column = GetColumn(binary);
                int seatid = row * 8 + column;
                Console.WriteLine($"binary: {line} row: {row.ToString()} column: {column} seatid: {seatid}");
                maxseatid = Math.Max(maxseatid, seatid);
                allseatids.Add(seatid);
            }

            Console.WriteLine($"maxseatid: {maxseatid}");

            for (int i = 1; i < maxseatid+1; i++)
            {
                if (!allseatids.Contains(i)) { Console.WriteLine($"free seatid: {i}"); }
            }

            // free seatid: 629 is het antwoord 



        }
        public static int GetRow(char[] binary)
        {
            int min = 0;
            int max = 127;

            for (int i = 0; i < 7; i++)
            {
                if (binary[i] == 'F') max -= (max - min + 1) / 2;
                if (binary[i] == 'B') min += (max - min + 1) / 2;
                //Console.WriteLine($"min: {min} max: {max}");
            }
            return min;
        }

        public static int GetColumn(char[] binary)
        {
            int min = 0;
            int max = 7;

            for (int i = 7; i < 10; i++)
            {
                if (binary[i] == 'L') max -= (max - min + 1) / 2;
                if (binary[i] == 'R') min += (max - min + 1) / 2;
                //Console.WriteLine($"min: {min} max: {max}");
            }
            return min;
        }
    }
}
