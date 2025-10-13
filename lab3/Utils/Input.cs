using lab3.Enums;

namespace lab3.Utils;

public static class Input
{
    public static Key GetKey()
    {
        Console.WriteLine("\nKey must be >= 7 and only contain chars from the Romanian alphabet.");

        Key key = new Key("");
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
                Console.WriteLine("! Key must be >= 7 and only contain chars from the Romanian alphabet");
                continue;
            }

            isInputKeyValid = true;

        } while (!isInputKeyValid);

        return key;
    }

    public static Text GetText()
    {
        Console.WriteLine("\nText must contain chars from the Romanian alphabet (A-Za-z).");

        Text text = new Text("");
        var isInputTextValid = false;
        do
        {
            Console.Write("> Text: ");
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

    public static OperationChoice GetOperationChoice()
    {
        Console.WriteLine("Operation choice must be either:\n0 - Encryption;\n1 - Decryption.");

        var choice = -1;
        var isInputChoiceValid = false;
        do
        {
            Console.Write("> Choice: ");
            var inputChoice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputChoice))
            {
                Console.WriteLine("! Choice must be a non empty string");
                continue;
            }

            var isChoiceInt = int.TryParse(inputChoice, out choice);

            if (!isChoiceInt || !(choice == 0 || choice == 1))
            {
                Console.WriteLine("! Choice must be a numeric value, either 0 - Encryption OR 1 - Decryption");
                continue;
            }

            isInputChoiceValid = true;

        } while (!isInputChoiceValid);

        return (OperationChoice) choice;
    }
}
