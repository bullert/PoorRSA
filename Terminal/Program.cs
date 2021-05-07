using PoorRSA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using System.Numerics;

namespace Terminal
{
    class Program
    {
        private static int keySize = 40;
        private static PoorRSACryptoServiceProvider rsa;

        static void Initialize()
        {
            rsa = new PoorRSACryptoServiceProvider(keySize);

            Console.WriteLine(StandardMessages.Header(keySize));
        }

        static void SolveArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(StandardMessages.Info());
            }
            else
            {
                switch (args[0])
                {
                    case "-g":
                        SolveKeyGeneration();
                        break;
                    case "-e":
                        SolveEncryption(args);
                        break;
                    case "-d":
                        SolveDecryption(args);
                        break;
                    default:
                        Console.WriteLine(StandardMessages.InvalidArgumentError());
                        break;
                }
            }
        }

        static void SolveKeyGeneration()
        {
            Console.WriteLine(StandardMessages.GeneratingPrimesInit());
            var sw = new Stopwatch();
            sw.Start();
            var primeNumberGenerator = new PrimeNumberGenerator(keySize / 2);
            sw.Stop();

            int n = primeNumberGenerator.Primes.Count;
            double t = sw.Elapsed.TotalSeconds;
            Console.WriteLine(StandardMessages.GeneratingPrimesFinish(n, t));

            Console.WriteLine(StandardMessages.GeneratingKeys());
            var keyPair = rsa.GenerateKeyPair(primeNumberGenerator);

            string publicKey = PublicKeyConverter.KeyToString(keyPair.PublicKey).ToHexString(),
                   privateKey = PrivateKeyConverter.KeyToString(keyPair.PrivateKey).ToHexString();
            Console.WriteLine(StandardMessages.DisplayKeys(publicKey, privateKey));
        }

        static void SolveEncryption(string[] args)
        {
            string message = args[1],
                   publicKeyString = args[2].FromHexString();

            PublicKey publicKey = (PublicKey)PublicKeyConverter.StringToKey(publicKeyString);

            string encryption = rsa.Encrypt(message, publicKey);

            Console.WriteLine(StandardMessages.DisplayEncryptedMessage(encryption));
        }

        static void SolveDecryption(string[] args)
        {
            string encryption = args[1],
                   privateKeyString = args[2].FromHexString();

            PrivateKey privateKey = (PrivateKey)PrivateKeyConverter.StringToKey(privateKeyString);

            string message = rsa.Decrypt(encryption, privateKey);

            Console.WriteLine(StandardMessages.DisplayDecryptedMessage(message));
        }

        static void Main(string[] args)
        {
            Initialize();
            SolveArgs(args);
        }
    }
}
