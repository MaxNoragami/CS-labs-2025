using lab4.Entities;

namespace lab4.Utils;

public static class Input
{
    public static Key GetKey()
    {
        Console.WriteLine("Key must be of 8 ASCII chars in length.");

        var key = new Key("");
        var isInputKeyValid = false;
        do
        {
            Console.Write("> Key: ");
            var inputKey = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputKey))
            {
                Console.WriteLine("! Key must be a non empty string");
                continue;
            }

            key = new Key(inputKey);

            if (!key.IsValid())
            {
                Console.WriteLine("! Key must be of 8 ASCII chars in length.");
                continue;
            }

            isInputKeyValid = true;

        } while (!isInputKeyValid);

        return key;
    }
}
