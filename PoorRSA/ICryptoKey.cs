using System.Numerics;

namespace PoorRSA
{
    public interface ICryptoKey
    {
        BigInteger Exponent { get; }

        BigInteger Modulus { get; }
    }
}