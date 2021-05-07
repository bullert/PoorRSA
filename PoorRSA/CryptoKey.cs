using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public abstract class CryptoKey : ICryptoKey
    {
        public CryptoKey(BigInteger exponent, BigInteger modulus)
        {
            Exponent = exponent;
            Modulus = modulus;
        }

        public BigInteger Modulus { get; private set; }

        public BigInteger Exponent { get; private set; }
    }
}
