namespace lab3.Utils;

public static class Alphabet
{
    public static string Value => "AÂĂBCDEFGHIÎJKLMNOPQRSȘTȚUVWXYZ";

    public static string FormNewAlphabet(Key key)
    {
        var newAlphabet = new List<char>();
        var keyAndAlphabet = key.Value + Value;

        for (int i = 0; i < key.Value.Length + Value.Length; i++)
            if (!newAlphabet.Contains(keyAndAlphabet[i]))
                newAlphabet.Add(keyAndAlphabet[i]);

        return string.Join("", newAlphabet);
    }
}
