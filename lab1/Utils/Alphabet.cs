using System.Text;

namespace lab1.Utils;

public static class Alphabet
{
    public static string Value => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static Text Encode(List<int> ints, PermutationsKey? permutationsKey)
    {
        var alphabet = permutationsKey != null ? FormNewAlphabet(permutationsKey) : Value; 

        var encodedText = new StringBuilder();

        foreach (var value in ints)
            encodedText.Append(alphabet[value]);

        return new Text(encodedText.ToString());
    }

    public static List<int> Decode(Text text, PermutationsKey? permutationsKey)
    {
        var alphabet = permutationsKey != null ? FormNewAlphabet(permutationsKey) : Value;

        var decodedValues = new List<int>();

        foreach (var letter in text.Value)
            decodedValues.Add(alphabet.IndexOf(letter));

        return decodedValues;
    }

    private static string FormNewAlphabet(PermutationsKey permutationsKey)
    {
        var newAlphabet = new List<char>();
        var keyAndAlphabet = permutationsKey.Value + Value;

        for (int i = 0; i < permutationsKey.Value.Length + Value.Length; i++)
            if (!newAlphabet.Contains(keyAndAlphabet[i]))
                newAlphabet.Add(keyAndAlphabet[i]);

        return string.Join("", newAlphabet);
    }
}