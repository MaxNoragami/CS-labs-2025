using lab4.Utils;
using System.Text;

namespace lab4.Entities;

public class KeyPlus
{
    public string Value { get; private set; } = string.Empty;


    public KeyPlus Obtain(KeyBin binKey)
    {
        var keyPlusBuilder = new StringBuilder();

        for (int i = 0; i < PC1.Table.GetLength(0); i++)
            for (int j = 0; j < PC1.Table.GetLength(1); j++)
                keyPlusBuilder.Append(binKey.Value[PC1.Table[i, j] - 1]);

        Value = keyPlusBuilder.ToString();

        return this;
    }

    public string View()
    {
        var viewBuilder = new StringBuilder();

        for (int i = 0; i < Value.Length; i++)
        {
            if (i % 7 == 0)
                viewBuilder.Append(" ");
            viewBuilder.Append(Value[i]);
        }

        return viewBuilder.ToString().Trim();
    }
}
