using System;

namespace aoc5
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] binary = new char[10];
            binary= "FBFBBFFRLR".ToCharArray();
            int row = GetRow(binary);
            
            Console.WriteLine($"binary: {binary.ToString()} row: {row.ToString()}");

            

        


        }
        public static int GetRow(char[] binary)
        {
            int min = 0;
            int max = 127;

            for (int i = 0; i < 7; i++)
            {
                if (binary[i] == 'F') max -= (max - min + 1) / 2;
                if (binary[i] == 'B') min += (max - min + 1) / 2;
                Console.WriteLine($"min: {min} max: {max}");
            }
            return min;
        }
    }
}
