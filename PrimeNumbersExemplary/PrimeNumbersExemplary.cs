using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace PrimeNumbersExemplary
{
    class PrimeNumbersExemplary
    {
        private static readonly int Iter = 10;
        private static ulong Counter;
        private static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }
        private static bool IsPrimeInstr(BigInteger Num)
        {
            Counter = 0;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) { Counter++; return false; }
            else
            {
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    Counter++;
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }
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
            Console.WriteLine("PrimeNumber;Exemplary;Time;IsPrime");
            for(int i = 0; i < primeNumbers.Length; i++)
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
            }
        }
    }
}
