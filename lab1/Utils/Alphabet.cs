using System.Text;

namespace lab1.Utils;

public static class Alphabet
{
    public static string Value => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static Text Encode(List<int> ints)
    {
        var encodedText = new StringBuilder();

        foreach (var value in ints)
            encodedText.Append(Value[value]);

        return new Text(encodedText.ToString());
    }

    public static List<int> Decode(Text text)
    {
        var decodedValues = new List<int>();

        foreach (var letter in text.Value)
            decodedValues.Add(Value.IndexOf(letter));

        return decodedValues;
    }
}