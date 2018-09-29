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
            Welcome();
            roulette.WinningBets(roulette.SpinTheWheel(WheelArray));
        }
        public static void Welcome()
        {
            Console.WriteLine("Welcome to David's Roulette game!");
            Console.WriteLine("Go ahead and place your bets. \nThe wheel will spin when you press enter.");
        }
    }
    class RouletteLogic
    {
        public int SpinTheWheel(int[] Wheel)
        {
            Random rng = new Random();
            int result = rng.Next(Wheel.Min(), Wheel.Max());
            Console.WriteLine($"\nThe wheel landed on {result}");
            return result;
        }
        /*
        DONE 1. Numbers: the number of the bin
        DONE 2. Evens/Odds: even or odd numbers
        DONE 3. Reds/Blacks: red or black colored numbers
        DONE 4. Lows/Highs: low (1 { 18) or high (19 { 38) numbers.
        DONE 5. Dozens: row thirds, 1 { 12, 13 { 24, 25 { 36
        DONE 6. Columns: rst, second, or third columns
        DONE 7. Street: rows, e.g., 1/2/3 or 22/23/24
        DONE 8. 6 Numbers: double rows, e.g., 1/2/3/4/5/6 or 22/23/24/25/26/26
        DONE 9. Split: at the edge of any two contiguous numbers, e.g., 1/2, 11/14, and 35/36
        10. Corner: at the intersection of any four contiguous numbers, e.g., 1/2/4/5, or 23/24/26/27
        TODO: Do more bets involving 0 and 00
        TODO: Clean code up. Combined console writelines.
         */
        public void WinningBets(int rollednumber)
        {
            if (rollednumber == -1 || rollednumber == 0)
            {
                if (rollednumber == 0)
                {
                    Console.WriteLine($"If you placed a bet on {rollednumber}, 35:1 payout!");
                }
                else
                {
                    Console.WriteLine("If you placed a bet on 00, 35:1 payout!");
                }
            }
            else
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
                if (new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }.Contains(rollednumber))
                {
                    Console.WriteLine("If you placed a bet on reds, you won 1:1 payout.");
                }
                else
                {
                    Console.WriteLine("If you placed a bet on blacks, you won 1:1 payout.");
                }
                if (rollednumber <= 18 && rollednumber > 0)
                {
                    Console.WriteLine("If you placed a bet on lows, you won 1:1 payout.");
                }
                else if (rollednumber > 18)
                {
                    Console.WriteLine("If you placed a bet on highs, you won 1:1 payout.");
                }
                if (rollednumber > 1 && rollednumber <= 12)
                {
                    Console.WriteLine("If you placed a bet on 1-12, you won 2:1 payout.");
                }
                else if (rollednumber > 12 && rollednumber <= 24)
                {
                    Console.WriteLine("If you placed a bet on 13-24, you won 2:1 payout.");
                }
                else if (rollednumber > 24 && rollednumber <= 36)
                {
                    Console.WriteLine("If you placed a bet on 25-36, you won 2:1 payout.");
                }
                //Array for bottom collumn
                if (new int[] { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 }.Contains(rollednumber))
                {
                    Console.WriteLine("If you placed a bet on the bottom column, you won 2:1 payout.");
                }
                else if (new int[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 }.Contains(rollednumber))
                {
                    Console.WriteLine("If you placed a bet on the middle column, you won 2:1 payout.");
                }
                else
                {
                    Console.WriteLine("If you placed a bet on the top column, you won 2:1 payout.");
                }
                if (rollednumber % 3 == 0)
                {
                    Console.WriteLine($"If you placed a bet on the {rollednumber - 2}-{rollednumber} street, you won 11:1 payout.");
                }
                else
                {
                    Console.WriteLine($"If you placed a bet on the {(rollednumber / 3) * 3 + 1}-{((rollednumber / 3) * 3) + 3} street, you won 11:1 payout.");
                }
                if (rollednumber % 3 == 0)
                {
                    if (rollednumber < 4)
                    {
                        Console.WriteLine($"If you placed a bet on the {rollednumber - 2}-{rollednumber + 3} double row, you won 11:1 payout.");
                    }
                    else
                    {
                        Console.WriteLine($"If you placed a bet on the {rollednumber - 5}-{rollednumber} double row, you won 11:1 payout.");
                        Console.WriteLine($"If you placed a bet on the {rollednumber - 2}-{rollednumber + 3} double row, you won 11:1 payout.");
                    }
                }
                else
                {
                    if (rollednumber < 4)
                    {
                        Console.WriteLine($"If you placed a bet on the {((rollednumber / 3) * 3) + 1}-{((rollednumber / 3) * 3) + 6} double row, you won 11:1 payout.");
                    }
                    else
                    {
                        Console.WriteLine($"If you placed a bet on the {((rollednumber / 3) * 3) - 2}-{((rollednumber / 3) * 3) + 3} double row, you won 11:1 payout.");
                        Console.WriteLine($"If you placed a bet on the {((rollednumber / 3) * 3) + 1}-{((rollednumber / 3) * 3) + 6} double row, you won 11:1 payout.");
                    }
                }
                if (rollednumber == 1)
                {
                    Console.WriteLine("If you placed a split bet on 1 and 2, you won 17:1 payout.");
                }
                else if (rollednumber == 36)
                {
                    Console.WriteLine("If you placed a split bet on 35 and 36, you won 17:1 payout.");
                }
                else
                {
                    Console.WriteLine($"If you placed a split bet on {rollednumber - 1} and {rollednumber}, you won 17:1 payout.");
                    Console.WriteLine($"If you placed a split bet on {rollednumber} and {rollednumber + 1}, you won 17:1 payout.");
                }
                if (rollednumber < 4)
                {
                    Console.WriteLine($"If you placed a corner bet on {rollednumber},{rollednumber},{rollednumber},{rollednumber}, you won 8:1 payout.");
                }
            }
            Console.ReadLine();
        }
    }
}