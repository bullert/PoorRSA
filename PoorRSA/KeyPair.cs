using System;
using System.Collections.Generic;
using System.Text;

namespace PoorRSA
{
    public class KeyPair : IKeyPair
    {
        public KeyPair(PublicKey publicKey, PrivateKey privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public PublicKey PublicKey { get; private set; }

        public PrivateKey PrivateKey { get; private set; }
    }
}
