using lab4.Entities;
using lab4.Enums;
using lab4.Utils;
using System.Text;

Console.OutputEncoding = Encoding.ASCII;
Console.InputEncoding = Encoding.ASCII;

do
{
    Console.Clear();
    Console.WriteLine("---- Lab 4 - DES - Get K+ ----");
    Console.WriteLine("Ctrl+C to exit\n");

    var key = new Key(string.Empty);

    var inputType = Input.GetOperationChoice();

    switch (inputType)
    {
        case OperationChoice.KEYBOARD:
            key = Input.GetKey();
            break;
        case OperationChoice.GENERATE:
            key = KeyGen.Generate();
            Console.WriteLine("> Key: {0}", key.Value);
            break;
        default:
            Console.WriteLine("! Unknown input type choice");
            break;
    }

    Console.WriteLine("\n+ PC-1 Table:\n{0}\n", PC1.View());

    var keyHex = new KeyHex().Obtain(key);
    Console.WriteLine("+ Key Hex: {0}\n", keyHex.View());

    var keyBin = new KeyBin().Obtain(keyHex);
    Console.WriteLine("+ Key Binary: {0}\n", keyBin.View());

    var keyPlus = new KeyPlus().Obtain(keyBin);
    Console.WriteLine("+ Key Plus: {0}\n", keyPlus.View());

    Console.WriteLine("------------------------------");
    Console.ReadLine();

} while (true);
