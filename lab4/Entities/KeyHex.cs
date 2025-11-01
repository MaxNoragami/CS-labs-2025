using lab4.Extensions;
using lab4.Utils;
using System.Text;

namespace lab4.Entities;

public class KeyHex
{
    public string Value { get; private set; } = string.Empty;

    public KeyHex Obtain(Key key)
    {
        var keyHexBuilder = new StringBuilder();

        foreach (var letter in key.Value)
            keyHexBuilder.Append(Format.AsciiToHex(letter));

        Value = keyHexBuilder.ToString();

        return this;
    }

    public string View()
    {
        var viewBuilder = new StringBuilder();
        
        for (int i = 0; i < Value.Length; i++)
        {
            if (i % 2 == 0)
                viewBuilder.Append(" ");
            viewBuilder.Append(Value[i]);
        }

        return viewBuilder.ToString().Trim();
    }
}
