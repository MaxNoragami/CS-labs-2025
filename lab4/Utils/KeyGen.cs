using lab4.Entities;
using System.Text;

namespace lab4.Utils;

public static class KeyGen
{
    public static Key Generate()
    {
        var random = new Random();
        var keyValueBuilder = new StringBuilder();

        for (int i = 0; i < 8; i++)
            keyValueBuilder.Append((char)random.Next(33, 127));

        return new Key(keyValueBuilder.ToString());
    }
}
