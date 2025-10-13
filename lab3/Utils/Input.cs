namespace lab3.Utils;

public static class Input
{
    public static Key GetKey()
    {
        Console.WriteLine("Key must be >= 7 and only contain chars from the Romanian alphabet.");

        Key key = new Key("");
        var isInputKeyValid = false;
        do
        {
            Console.Write("Key:");
            var inputKey = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputKey))
            {
                Console.WriteLine("! Key must be a non empty string");
                continue;
            }

            key = new Key(inputKey);

            if (!key.IsValid())
            {
                Console.WriteLine("! Key must be >= 7 and only contain chars from the Romanian alphabet");
                continue;
            }

            isInputKeyValid = true;

        } while (!isInputKeyValid);

        return key;
    }

    public static Text GetText()
    {
        Console.WriteLine("Text must contain chars from the Romanian alphabet (A-Za-z).");

        Text text = new Text("");
        var isInputTextValid = false;
        do
        {
            Console.Write("Text:");
            var inputText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                Console.WriteLine("! Text must be a non empty string");
                continue;
            }

            text = new Text(inputText);

            if (!text.IsValid())
            {
                Console.WriteLine("! Text must contain chars from the Romanian alphabet (A-Za-z)");
                continue;
            }

            isInputTextValid = true;

        } while (!isInputTextValid);

        return text;
    }
}
