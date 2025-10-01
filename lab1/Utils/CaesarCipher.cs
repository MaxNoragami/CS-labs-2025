namespace lab1.Utils;

public static class CaesarCipher
{
    public static Text Encrypt(Text message, Key key)
    {
        var decodedMessage = Alphabet.Decode(message);

        var encryptedDecodedCipher = new List<int>();

        foreach (var value in decodedMessage)
            encryptedDecodedCipher.Add(Mod(value + key.Value, Alphabet.Value.Length));

        return Alphabet.Encode(encryptedDecodedCipher);
    }

    public static Text Decrypt(Text cipher, Key key)
    {
        var decodedCipher = Alphabet.Decode(cipher);

        var decryptedDecodedMessage = new List<int>();

        foreach (var value in decodedCipher)
            decryptedDecodedMessage.Add(Mod(value - key.Value, Alphabet.Value.Length));

        return Alphabet.Encode(decryptedDecodedMessage);
    }

    private static int Mod(int dividend, int modulus)
        => (dividend % modulus + modulus) % modulus;
}
