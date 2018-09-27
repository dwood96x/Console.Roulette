using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RouletteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            RouletteLogic roulette = new RouletteLogic();
            int[] WheelArray = new int[38];
            for (int i = -1; i <= 36; i++)
            {
                WheelArray[i + 1] = i;
            }
        }
    }
    class RouletteLogic
    {
        public int SpinTheWheel(int[] Wheel)
        {
            Random rng = new Random();
            int result = rng.Next(Wheel.Min(), Wheel.Max());
            return result;
        }
        /*
        DONE 1. Numbers: the number of the bin
        DONE 2. Evens/Odds: even or odd numbers
        DONE 3. Reds/Blacks: red or black colored numbers
        DONE 4. Lows/Highs: low (1 { 18) or high (19 { 38) numbers.
        5. Dozens: row thirds, 1 { 12, 13 { 24, 25 { 36
        6. Columns: rst, second, or third columns
        7. Street: rows, e.g., 1/2/3 or 22/23/24
        8. 6 Numbers: double rows, e.g., 1/2/3/4/5/6 or 22/23/24/25/26/26
        9. Split: at the edge of any two contiguous numbers, e.g., 1/2, 11/14, and 35/36
        10. Corner: at the intersection of any four contiguous numbers, e.g., 1/2/4/5, or 23/24/26/27
         */
        public void WinningBets(int rollednumber)
        {
            Console.WriteLine($"If you placed a bet on {rollednumber}, 35:1 payout!");
            // TODO : Figure out if 00 or 0 gives a odd or even
            if (rollednumber % 2 == 0)
            {
                Console.WriteLine("If you placed a bet on evens, you won 1:1 payout.");
            }
            else
            {
                Console.WriteLine("If you placed a bet on odds, you won 1:1 payout.");
            }
            // The following code is a array that only contains reds
            if (new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36}.Contains(rollednumber))
            {
                Console.WriteLine("If you placed a bet on reds, you won 1:1 payout");
            }
            else if (rollednumber == -1 || rollednumber == 0)
            {
                //Do nothing
            }
            else
            {
                Console.WriteLine("If you placed a bet on blacks, you won 1:1 payout");
            }
            if (rollednumber <= 18 && rollednumber > 0)
            {
                Console.WriteLine("If you placed a bet on lows, you won 1:1 payout");
            }
            else if (rollednumber > 18)
            {
                Console.WriteLine("If you placed a bet on highs, you won 1:1 payout");
            }
        }
    }
}
