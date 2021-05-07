using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public static class StandardMessages
    {
        public static string Header(int keySize)
        {
            return $"\n ### Poor implementation of {keySize}-bit RSA Algorithm. ### \n";
        }

        public static string Info()
        {
            return $"Available parameters:\n" +
                string.Format(
                        "{0, 1} {1, -32} {2}\n",
                        " ", "-g", "Generates a pair of RSA keys."
                    ) +
                string.Format(
                        "{0, 1} {1, -32} {2}\n",
                        " ", "-e <message> <PUBLIC_KEY>", "Encrypts a ASCII message with a public key."
                    ) + 
                string.Format(
                        "{0, 1} {1, -32} {2}\n",
                        " ", "-d <encryption> <PRIVATE_KEY>", "Decrypts an encrypted message with a private key."
                    );
        }

        public static string InvalidArgumentError()
        {
            return "Error: Invalid argument.";
        }

        public static string GeneratingPrimesInit()
        {
            return "Generating prime number sequence...";
        }

        public static string GeneratingPrimesFinish(int n, double t)
        {
            return $"Generated {n} primes in {t} sec.";
        }

        public static string GeneratingKeys()
        {
            return "Generating keys...";
        }

        public static string DisplayKeys(string publicKey, string privateKey)
        {
            return $"\nKeys:\n" +
                string.Format(
                        "{0, 1} {1, -16} {2}\n",
                        " ", "PUBLIC_KEY", publicKey
                    ) +
                string.Format(
                        "{0, 1} {1, -16} {2}\n",
                        " ", "PRIVATE_KEY", privateKey
                    );
        }

        public static string DisplayEncryptedMessage(string message)
        {
            return $"Encrypted message:\n\n{message}\n";
        }

        public static string DisplayDecryptedMessage(string message)
        {
            return $"Decrypted message:\n\n{message}\n";
        }
    }
}
