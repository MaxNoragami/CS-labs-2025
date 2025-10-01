using lab1.Enums;
using lab1.Utils;

do
{
    Console.WriteLine("---- Lab 1 ----");
    Console.WriteLine("Ctrl+C to exit");

    Console.Write("\nShift Key (1 to 25 inclusive): ");
    Key key = Input.GetKey();

    PermutationsKey? permutationsKey = null;

    Console.WriteLine("\nCipher Algorithms:\n0. Caesar Cipher\n1. Caesar Cipher + permutations");
    Console.Write("Algo Choice (0 OR 1): ");
    var algoChoice = Input.GetBinaryChoice<AlgoChoice>();

    if (algoChoice == AlgoChoice.CAESAR_2KEY)
    {
        Console.Write("\nPermutations Key (length >= 7): ");
        permutationsKey = Input.GetPermutationsKey();
    }
        
    Console.WriteLine("\nOperation Types:\n0. Encryption\n1. Decryption");
    Console.Write("Operation Choice (0 OR 1): ");
    var operationChoice = Input.GetBinaryChoice<OperationChoice>();

    switch (operationChoice)
    {
        case OperationChoice.ENCRYPT:
            Console.Write("\nMessage (A-Za-z): ");
            var message = Input.GetText();
            Console.WriteLine("Encrypted: {0}", 
                CaesarCipher.Encrypt(message, key, permutationsKey).Value);
            break;
        case OperationChoice.DECRYPT:
            Console.Write("\nCipher (A-Za-z): ");
            var cipher = Input.GetText();
            Console.WriteLine("Decrypted: {0}", 
                CaesarCipher.Decrypt(cipher, key, permutationsKey).Value);
            break;
        default:
            Console.WriteLine("! Wrong OperationChoice");
            break;
    }

    Console.ReadLine();
    
} while (true);
