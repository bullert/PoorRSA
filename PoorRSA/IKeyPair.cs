namespace PoorRSA
{
    public interface IKeyPair
    {
        PrivateKey PrivateKey { get; }

        PublicKey PublicKey { get; }
    }
}