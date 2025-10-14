namespace lab3.Extensions;

public static class TwoDimensionalArrayExtensions
{
    public static Tuple<int, int>? GetCharIndexOrDefault(this char[,] matrix, char target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (matrix[r, c] == target)
                    return Tuple.Create(r, c);

        return null;
    }
}
