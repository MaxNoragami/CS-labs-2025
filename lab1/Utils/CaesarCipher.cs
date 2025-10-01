namespace lab1.Utils;

public static class CaesarCipher
{
    public static Text Encrypt(Text message, Key key, PermutationsKey? permutationsKey = null)
    {
        var decodedMessage = Alphabet.Decode(message, permutationsKey);

        var encryptedDecodedCipher = new List<int>();

        foreach (var value in decodedMessage)
            encryptedDecodedCipher.Add(Mod(value + key.Value, Alphabet.Value.Length));

        return Alphabet.Encode(encryptedDecodedCipher, permutationsKey);
    }

    public static Text Decrypt(Text cipher, Key key, PermutationsKey? permutationsKey = null)
    {
        var decodedCipher = Alphabet.Decode(cipher, permutationsKey);

        var decryptedDecodedMessage = new List<int>();

        foreach (var value in decodedCipher)
            decryptedDecodedMessage.Add(Mod(value - key.Value, Alphabet.Value.Length));

        return Alphabet.Encode(decryptedDecodedMessage, permutationsKey);
    }

    private static int Mod(int dividend, int modulus)
        => (dividend % modulus + modulus) % modulus;
}
