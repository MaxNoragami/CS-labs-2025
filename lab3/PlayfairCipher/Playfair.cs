using lab3.Utils;
using lab3.Enums;
using lab3.Extensions;

namespace lab3.PlayfairCipher;

public static class Playfair
{
    private static readonly string _romanianFreq = "eiarntulocsdpmăfvîgbșțzhâjxkywq";

    public static Text Encrypt(Text message, Key key)
    {
        var newAlphabet = Alphabet.FormNewAlphabet(key);

        var matrixInstance = new Matrix(newAlphabet);
        var matrix = matrixInstance.Get();
        Console.WriteLine("\n" + matrixInstance.ToString());

        var pairs = GetPairs(MaskDoubles(message));
        Console.WriteLine($"M: {string.Join(' ', pairs)}");

        var encryptedPairs = new List<string>();
        foreach (var pair in pairs)
        {
            var indexFirst = matrix.GetCharIndexOrDefault(pair[0]);
            var indexSecond = matrix.GetCharIndexOrDefault(pair[1]);

            if (indexFirst == null || indexSecond == null)
                throw new ArgumentException("!!! One or both chars were not found in the matrix");

            if (indexFirst.Item1 == indexSecond.Item1)
                encryptedPairs.Add(SameRowsRule(indexFirst, indexSecond, matrix, OperationChoice.ENCRYPT));
            else if (indexFirst.Item2 == indexSecond.Item2)
                encryptedPairs.Add(SameColumnsRule(indexFirst, indexSecond, matrix, OperationChoice.ENCRYPT));
            else
                encryptedPairs.Add(DifferentRowsColumnsRule(indexFirst, indexSecond, matrix));
        }

        Console.WriteLine($"C: {string.Join(' ', encryptedPairs)}\n");

        return new Text(string.Join("", encryptedPairs));
    }

    public static Text Decrypt(Text cipher, Key key)
    {
        var newAlphabet = Alphabet.FormNewAlphabet(key);

        var matrixInstance = new Matrix(newAlphabet);
        var matrix = matrixInstance.Get();
        Console.WriteLine("\n" + matrixInstance.ToString());

        var pairs = GetPairs(cipher);
        Console.WriteLine($"C: {string.Join(' ', pairs)}");

        var decryptedPairs = new List<string>();
        foreach (var pair in pairs)
        {
            var indexFirst = matrix.GetCharIndexOrDefault(pair[0]);
            var indexSecond = matrix.GetCharIndexOrDefault(pair[1]);

            if (indexFirst == null || indexSecond == null)
                throw new ArgumentException("!!! One or both chars were not found in the matrix");

            if (indexFirst.Item1 == indexSecond.Item1)
                decryptedPairs.Add(SameRowsRule(indexFirst, indexSecond, matrix, OperationChoice.DECRYPT));
            else if (indexFirst.Item2 == indexSecond.Item2)
                decryptedPairs.Add(SameColumnsRule(indexFirst, indexSecond, matrix, OperationChoice.DECRYPT));
            else
                decryptedPairs.Add(DifferentRowsColumnsRule(indexFirst, indexSecond, matrix));
        }

        Console.WriteLine($"M: {string.Join(' ', decryptedPairs)}\n");

        return new Text(string.Join("", decryptedPairs));
    }

    private static string SameRowsRule(
        Tuple<int, int> indexFirst, Tuple<int, int> indexSecond, char[,] matrix, OperationChoice operation)
    {
        var columns = matrix.GetLength(1);

        if (operation == OperationChoice.ENCRYPT)
            return ""
                + matrix[indexFirst.Item1, Mod(indexFirst.Item2 + 1, columns)]
                + matrix[indexSecond.Item1, Mod(indexSecond.Item2 + 1, columns)];
        else
            return ""
                + matrix[indexFirst.Item1, Mod(indexFirst.Item2 - 1, columns)]
                + matrix[indexSecond.Item1, Mod(indexSecond.Item2 - 1, columns)];
    }

    private static string SameColumnsRule(
        Tuple<int, int> indexFirst, Tuple<int, int> indexSecond, char[,] matrix, OperationChoice operation)
    {
        var rows = matrix.GetLength(0);

        if (operation == OperationChoice.ENCRYPT)
            return ""
                + matrix[Mod(indexFirst.Item1 + 1, rows), indexFirst.Item2]
                + matrix[Mod(indexSecond.Item1 + 1, rows), indexSecond.Item2];
        else
            return ""
                + matrix[Mod(indexFirst.Item1 - 1, rows), indexFirst.Item2]
                + matrix[Mod(indexSecond.Item1 - 1, rows), indexSecond.Item2];
    }

    private static string DifferentRowsColumnsRule(
        Tuple<int, int> indexFirst, Tuple<int, int> indexSecond, char[,] matrix)
    {
        return ""
            + matrix[indexFirst.Item1, indexSecond.Item2]
            + matrix[indexSecond.Item1, indexFirst.Item2];
    }

    private static List<string> GetPairs(Text text)
    {
        var splitPairs = new List<string>();

        for (int i = 0; i < text.Value.Length; i +=2)
            splitPairs.Add("" + text.Value[i] + text.Value[i + 1]);

        return splitPairs;
    }

    private static Text MaskDoubles(Text text)
    {
        var message = text.Value;
        var maskedMsg = new List<string>();

        var rareIndex = 0;

        int i = 0;
        while (i < message.Length)
        {
            var current = message[i];
            var lastPair = maskedMsg.LastOrDefault();

            if (lastPair == null || lastPair.Length == 2)
            {
                maskedMsg.Add("" + current);
                i += 1;
                continue;
            }

            if (lastPair[0] == current)
            {
                maskedMsg[^1] += _romanianFreq[^(rareIndex % 3 + 1)];
                rareIndex += 1;
                continue;
            }

            maskedMsg[^1] += current;
            rareIndex = 0;
            i += 1;
        }

        var lastDigraph = maskedMsg.LastOrDefault();
        if (lastDigraph != null && lastDigraph.Length == 1)
            maskedMsg.Add("" + _romanianFreq[^1]);

        return new Text(string.Join("", maskedMsg));
    }

    private static int Mod(int dividend, int modulus)
        => (dividend % modulus + modulus) % modulus;
}
