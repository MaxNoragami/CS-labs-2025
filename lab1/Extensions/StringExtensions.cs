using System.Text;

namespace lab1.Extensions;

public static class StringExtensions
{
    public static string RemoveSpaces(this string text)
    {
        var stringBuilder = new StringBuilder();

        foreach (var letter in text)
            if (letter != ' ')
                stringBuilder.Append(letter);

        return stringBuilder.ToString();
    }
}
