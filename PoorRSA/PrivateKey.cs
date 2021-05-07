using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public class PrivateKey : CryptoKey, ICryptoKey
    {
        public PrivateKey(BigInteger exponent, BigInteger modulus) : base(exponent, modulus)
        {
        }
    }
}
