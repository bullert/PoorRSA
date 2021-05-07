using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public class PrivateKeyConverter
    {
        public static ICryptoKey StringToKey(string key)
        {
            var parts = key.Split('/');
            return new PrivateKey(
                    BigInteger.Parse(parts[0]),
                    BigInteger.Parse(parts[1])
                );
        }

        public static string KeyToString(ICryptoKey key)
        {
            return $"{key.Exponent}/{key.Modulus}";
        }
    }
}
