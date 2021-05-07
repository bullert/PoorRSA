using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PoorRSA
{
    public class PublicKey : CryptoKey, ICryptoKey
    {
        public PublicKey(BigInteger exponent, BigInteger modulus) : base(exponent, modulus)
        {
        }
    }
}
