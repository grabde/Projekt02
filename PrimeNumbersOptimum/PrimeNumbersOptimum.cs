using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PrimeNumbersOptimum
{
    class PrimeNumbersOptimum
    {
        private static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num == 2) return true;
            else if (Num == 3) return true;
            else if (Num == 5) return true;
            else if (Num == 7) return true;
            else if (Num % 2 == 0 || Num % 3 == 0 || Num % 5 == 0) return false;
            else if (Num <= 30) return IsPrime2(Num);
            else
            {
                for (BigInteger u = 7; (u * u) <= Num; u += 30)
                {
                    if (Num % u == 0 || Num % (u + 4) == 0 || Num % (u + 6) == 0 || Num % (u + 10) == 0 || Num % (u + 12) == 0
                        || Num % (u + 16) == 0 || Num % (u + 22) == 0 || Num % (u + 24) == 0) return false;
                }
            }
            return true;
        }
        private static bool IsPrime2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                for (BigInteger u = 3; (u * u) <= Num; u += 2)
                {
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }
        private static bool IsPrimeInstr2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) { Counter++; return false; }
            else
            {
                for (BigInteger u = 3; (u * u) <= Num; u += 2)
                {
                    Counter++;
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }
        private static bool IsPrimeInstr(BigInteger Num)
        {
            Counter = 0;
            if (Num < 2) return false;
            else if (Num == 2) return true;
            else if (Num == 3) return true;
            else if (Num == 5) return true;
            else if (Num == 7) return true;
            else if (Num % 2 == 0 || Num % 3 == 0 || Num % 5 == 0) { Counter++; return false; }
            else if (Num <= 30) return IsPrimeInstr2(Num);
            else
            {
                for (BigInteger u = 7; (u * u) <= Num; u += 30)
                {
                    Counter++;
                    if (Num % u == 0 || Num % (u + 4) == 0 || Num % (u + 6) == 0 || Num % (u + 10) == 0 || Num % (u + 12) == 0 
                        || Num % (u + 16) == 0 || Num % (u + 22) == 0 || Num % (u + 24) == 0) return false; 
                }
            }
            return true;
        }
        private static readonly int Iter = 10;
        private static ulong Counter;
        static void Main(string[] args)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            long timeElapsed = 0;
            long iterTimeElapsed;
            long start;
            long stop;
            double elapsedSeconds;
            bool isPrimeNumber;
            string isPrimeNumberString;
            BigInteger n;
            BigInteger[] primeNumbers = new BigInteger[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };
            Console.WriteLine("PrimeNumber;Optimum;Time;IsPrime");
            for (int i = 0; i < primeNumbers.Length; i++)
            {
                n = primeNumbers[i];
                for (int j = 0; j < Iter + 2; ++j)
                {
                    start = Stopwatch.GetTimestamp(); // start time
                    IsPrime(n); // calling function IsPrime without counter
                    stop = Stopwatch.GetTimestamp();   // stop time
                    iterTimeElapsed = stop - start;
                    timeElapsed += iterTimeElapsed;
                    if (iterTimeElapsed < min) min = iterTimeElapsed;
                    if (iterTimeElapsed > max) max = iterTimeElapsed;
                }
                timeElapsed = (max - min);
                isPrimeNumber = IsPrimeInstr(n); ; // calling function IsPrime with counter
                elapsedSeconds = timeElapsed * (1.0 / (Iter * Stopwatch.Frequency));
                if (isPrimeNumber == true) isPrimeNumberString = "Prime";
                else isPrimeNumberString = "Not Prime";
                Console.WriteLine(n + ";" + Counter + ";" + (elapsedSeconds.ToString("F6")) + ";" + isPrimeNumberString); // Prime Number; Counter; Time; Is Prime
                //Sito(primeNumbers[i]);
            }
        }
    }
}
