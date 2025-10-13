using lab3.Extensions;

namespace lab3.Utils;

public class Key(string value)
{
    public string Value => value.ToUpper().Trim().RemoveSpaces();

    public bool IsValid()
    {
        if (Value.Length < 7)
            return false;

        foreach (var letter in Value)
            if (!Alphabet.Value.Contains(letter))
                return false;

        return true;
    }
}
