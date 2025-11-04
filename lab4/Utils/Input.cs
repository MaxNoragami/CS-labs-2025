using lab4.Entities;
using lab4.Enums;

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

    public static OperationChoice GetOperationChoice()
    {
        Console.WriteLine("Operation choice must be either:\n0 - KEYBOARD\n1 - GENERATE");

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
                Console.WriteLine("! Choice must be a numeric value, either 0 - KEYBOARD OR 1 - GENERATE");
                continue;
            }

            isInputChoiceValid = true;

        } while (!isInputChoiceValid);

        Console.WriteLine();

        return (OperationChoice)choice;
    }
}
