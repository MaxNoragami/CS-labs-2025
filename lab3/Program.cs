using lab3.Enums;
using lab3.PlayfairCipher;
using lab3.Utils;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

do
{
    Console.WriteLine("---- Lab 3 - Playfair Cipher----");
    Console.WriteLine("Ctrl+C to exit\n");

    var operation = Input.GetOperationChoice();
    var key = Input.GetKey();
    var text = Input.GetText(operation);

    Console.WriteLine($"\n- Key: {key.Value}\n- Text: {text.Value}");

    switch (operation)
    {
        case OperationChoice.ENCRYPT:
            Console.WriteLine("+ Encrypted: {0}\n", 
                Playfair.Encrypt(text, key).Value);
            break;
        case OperationChoice.DECRYPT:
            Console.WriteLine("+ Decrypted: {0}\n", 
                Playfair.Decrypt(text, key).Value);
            break;
        default:
            Console.WriteLine("! Unknown choice");
            break;
    }

    Console.ReadLine();

} while (true);
