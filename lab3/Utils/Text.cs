using lab3.Extensions;

namespace lab3.Utils;

public class Text(string value)
{
    public string Value => value.ToUpper().Trim().Replace('Î', 'I').RemoveSpaces();

    public bool IsValid()
    {
        foreach (var letter in Value)
            if (!Alphabet.Value.Contains(letter))
                return false;

        return true;
    }
}
