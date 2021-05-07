using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using ExtensionMethods;

namespace PoorRSA
{
    public class PoorRSACryptoServiceProvider
    {
        public PoorRSACryptoServiceProvider(int keySize)
        {
            KeySize = keySize;
            PrimeNumberGenerator = new PrimeNumberGenerator(KeySize / 2);
        }

        public int KeySize { get; private set; }

        public PrimeNumberGenerator PrimeNumberGenerator { get; private set; }

        public KeyPair GenerateKeyPair(BigInteger p, BigInteger q, BigInteger e)
        {
            BigInteger n = p * q,
                       phi = (p - 1) * (q - 1),
                       d = BigIntegerExtensions.ModInverse(e, phi);

            return new KeyPair(
                    new PublicKey(e, n), 
                    new PrivateKey(d, n)
                );
        }

        public KeyPair GenerateKeyPair(PrimeNumberGenerator primeNumberGenerator)
        {
            var randomNumberGenerator = new RandomNumberGenerator(primeNumberGenerator.Primes);
            
            BigInteger p = randomNumberGenerator.Random(),
                       q = randomNumberGenerator.Random(),
                       phi = (p - 1) * (q - 1),
                       e = GetDefaultPublicExponent(primeNumberGenerator.Primes, phi);

            return GenerateKeyPair(p, q, e);
        }

        public BigInteger GetDefaultPublicExponent(IList<BigInteger> primes, BigInteger t)
        {
            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] >= t)
                {
                    break;
                }

                if (primes[i].IsCoprime(t))
                {
                    return primes[i];
                }
            }

            throw new Exception("Can't find any coprime.");
        }

        public string Encrypt(string message, PublicKey publicKey)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < message.Length - 1; i++)
            {
                sb.Append(Encrypt(message[i], publicKey))
                  .Append('.');
            }
            sb.Append(Encrypt(message[message.Length - 1], publicKey));
            return sb.ToString();
        }

        private BigInteger Encrypt(char sign, PublicKey publicKey)
        {
            return BigInteger.ModPow((int)sign, publicKey.Exponent, publicKey.Modulus);
        }

        public string Decrypt(string encryption, PrivateKey privateKey)
        {
            var sb = new StringBuilder();
            var parts = encryption.Split('.');
            for (int i = 0; i < parts.Length; i++)
            {
                sb.Append((char)Decrypt(BigInteger.Parse(parts[i]), privateKey));
            }
            return sb.ToString();
        }

        private BigInteger Decrypt(BigInteger value, PrivateKey privateKey)
        {
            return BigInteger.ModPow(value, privateKey.Exponent, privateKey.Modulus);
        }
    }
}
