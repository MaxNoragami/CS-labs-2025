namespace lab1.Utils;

public static class Input
{
    public static Key GetKey()
    {
        Key key;

        var isInputKeyValid = false;
        do
        {
            int.TryParse(Console.ReadLine()?.Trim(), out int inputKey);

            key = new Key(inputKey);
            isInputKeyValid = key.IsValid();
            if (!isInputKeyValid)
                Console.WriteLine("! Key must be an int from 1 to 25 inclusive");
        } while (!isInputKeyValid);

        return key;
    }

    public static PermutationsKey GetPermutationsKey()
    {
        PermutationsKey permutationsKey = new PermutationsKey("");
        string? inputPermutationsKey;

        var isInputPermutationKeyValid = false;
        do
        {
            inputPermutationsKey = Console.ReadLine();
            if (inputPermutationsKey == null)
                Console.WriteLine("! Permutations key must be a non empty string");
            else
            {
                permutationsKey = new PermutationsKey(inputPermutationsKey);
                isInputPermutationKeyValid = permutationsKey.IsValid();
                if (!isInputPermutationKeyValid)
                    Console.WriteLine("! Permutations key must be a string with a length greater or equal to 7");
            }
        } while (!isInputPermutationKeyValid);

        return permutationsKey;
    }

    public static Text GetText()
    {
        Text text = new Text("");
        string? inputText;

        var isInputTextValid = false;
        do
        {
            inputText = Console.ReadLine();
            if (inputText == null)
                Console.WriteLine("! Input text must be a non empty string");
            else
            {
                text = new Text(inputText);
                isInputTextValid = text.IsValid();
                if (!isInputTextValid)
                    Console.WriteLine("! Input text must contain the characters only from the defined English alphabet");
            }
              
        } while (!isInputTextValid);

        return text;
    }

    public static T GetBinaryChoice<T>() where T : Enum
    {
        int choice = -1;

        var isInputChoiceValid = false;
        do
        {
            isInputChoiceValid = int.TryParse(Console.ReadLine()?.Trim(), out int inputChoice);

            if (!isInputChoiceValid)
                Console.WriteLine("! Choice must be an int");
            else
            {
                choice = inputChoice;

                isInputChoiceValid = inputChoice == 0 || inputChoice == 1;
                if (!isInputChoiceValid)
                    Console.WriteLine("! Choice must be either 0 OR 1");
            } 
        } while (!isInputChoiceValid);

        return (T) (object) choice;
    }
}
