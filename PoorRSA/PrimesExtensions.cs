using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ExtensionMethods
{
    public static class PrimesExtensions
    {
        public static bool IsPrime(this BigInteger n)
        {
            BigInteger sqrt = n.Sqrt();

            if (n % 2 == 0)
            {
                return false;
            }

            for (BigInteger i = 3; i <= sqrt; i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsCoprime(this BigInteger a, BigInteger b)
        {
            return BigIntegerExtensions.GreatestDommonDivisor(a, b) == 1 ? true : false;
        }
    }
}
