using lab4.Utils;
using System.Text;

namespace lab4.Entities;

public class KeyBin
{
    public string Value { get; private set; } = string.Empty;


    public KeyBin Obtain(KeyHex hexKey)
    {
        var keyBinaryBuilder = new StringBuilder();

        foreach (var letter in hexKey.Value)
            keyBinaryBuilder.Append(Format.HexToBin(letter));

        Value = keyBinaryBuilder.ToString();

        return this;
    }

    public string View()
    {
        var viewBuilder = new StringBuilder();

        for (int i = 0; i < Value.Length; i++)
        {
            if (i % 8 == 0)
                viewBuilder.Append(" ");
            viewBuilder.Append(Value[i]);
        }

        return viewBuilder.ToString().Trim();
    }
}
