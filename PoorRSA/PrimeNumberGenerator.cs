using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public class PrimeNumberGenerator
    {
        public PrimeNumberGenerator(int keySize)
        {
            KeySize = keySize;
            Primes = GeneratePrimes();
        }

        public List<BigInteger> Primes { get; private set; }

        public int KeySize { get; private set; }

        private List<BigInteger> GeneratePrimes()
        {
            var primes = new List<BigInteger>() { 2, 3 };
            BigInteger n = BigInteger.Pow(2, KeySize) - 1;

            for (BigInteger i = 5; i <= n; i += 2)
            {
                bool isPrime = true;
                BigInteger sqrt = (primes.Last()).Sqrt();

                for (int j = 1; primes[j] <= sqrt; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToList();
        }
    }
}
