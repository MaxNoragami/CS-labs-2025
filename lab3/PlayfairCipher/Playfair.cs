using lab3.Utils;
using lab3.Extensions;
using lab3.Enums;

namespace lab3.PlayfairCipher;

public static class Playfair
{
    private static readonly string _romanianFreq = "eiarntulocsdpmăfvîgbșțzhâjxkywq";

    public static Text Encrypt(Text message, Key key)
    {
        // TODO
        var newAlphabet = Alphabet.FormNewAlphabet(key);
        Console.WriteLine(newAlphabet);

        var matrix = GetMatrix(newAlphabet);
        PrintMatrix(matrix);

        var pairs = GetPairs(MaskDoubles(message));
        Console.WriteLine(string.Join(' ', pairs));

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

        Console.WriteLine(string.Join(' ', encryptedPairs));

        return new Text(string.Join("", encryptedPairs));
    }

    public static Text Decrypt(Text cipher, Key key)
    {
        //TODO
        var newAlphabet = Alphabet.FormNewAlphabet(key);
        Console.WriteLine(newAlphabet);

        var matrix = GetMatrix(newAlphabet);
        PrintMatrix(matrix);

        var pairs = GetPairs(cipher);
        Console.WriteLine(string.Join(' ', pairs));

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

        Console.WriteLine(string.Join(' ', decryptedPairs));

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

            // In case we got no elements or we gotta start a new pair, we just add current as first
            if (lastPair == null || lastPair.Length == 2)
            {
                maskedMsg.Add("" + current);
                i += 1;
                continue;
            }

            // Adding second in case lastPair.Length is other than 2
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

    private static char[,] GetMatrix(string newAlphabet)
    {
        var rows = 5;
        var columns = 6;
        var matrix = new char[rows, columns];

        var i = 0;
        for (int j = 0; j < rows; j++)
        {
            for (int k = 0; k < columns; k++)
            {
                if (i >= newAlphabet.Length)
                    break;

                matrix[j, k] = newAlphabet[i];
                i += 1;
            }
            if (i >= newAlphabet.Length)
                break;
        }

        return matrix;
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");

            Console.WriteLine();
        }
    }

    private static int Mod(int dividend, int modulus)
        => (dividend % modulus + modulus) % modulus;
}
