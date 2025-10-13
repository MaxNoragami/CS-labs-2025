using lab3.Utils;

namespace lab3.PlayfairCipher;

public static class Playfair
{
    private static readonly string _romanianFreq = "eiarntulocsdpmăfvîgbșțzhâjxkywq";

    public static Text Encrypt(Text message, Key key)
    {
        // TODO

        Console.WriteLine(string.Join(' ', ObtainPairs(MaskDoubles(message))));

        return message;
    }

    public static Text Decrypt(Text cipher, Key key)
    {
        //TODO

        return cipher;
    }

    private static List<string> ObtainPairs(Text text)
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
}
