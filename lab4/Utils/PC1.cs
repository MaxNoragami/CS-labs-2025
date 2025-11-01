using System.Text;

namespace lab4.Utils;

public static class PC1
{
    public static int[,] Table => new int[8, 7]
    {
        { 57, 49, 41, 33, 25, 17, 9 },
        { 1, 58, 50, 42, 34, 26, 18 },
        { 10, 2, 59, 51, 43, 35, 27 },
        { 19, 11, 3, 60, 52, 44, 36 },
        { 63, 55, 47, 39, 31, 23, 15 },
        { 7, 62, 54, 46, 38, 30, 22 },
        { 14, 6, 61, 53, 45, 37, 29 },
        { 21, 13, 5, 28, 20, 12, 4 }
    };

    public static string View()
    {
        var matrix = new StringBuilder();

        for (int i = 0; i < Table.GetLength(0); i++)
        {
            for (int j = 0; j < Table.GetLength(1); j++)
                matrix.Append(Table[i, j] + " ");

            matrix.Append("\n");
        }

        return matrix.ToString();
    }
}
