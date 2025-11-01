using lab4.Extensions;

namespace lab4.Entities;

public class Key(string value)
{
    public string Value => value.Trim().RemoveSpaces();

    public bool IsValid()
        => Value.Length == 8;
}
