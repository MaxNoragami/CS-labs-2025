using System.Text;

namespace lab3.PlayfairCipher;

public class Matrix(string newAlphabet)
{
    private readonly string _newAlphabet = newAlphabet;
    private readonly char[,] _value = new char[Rows, Columns];

    public static int Rows => 5;
    public static int Columns => 6;

    public char[,] Get()
    {
        var i = 0;
        for (int j = 0; j < Rows; j++)
        {
            for (int k = 0; k < Columns; k++)
            {
                if (i >= _newAlphabet.Length)
                    break;

                _value[j, k] = _newAlphabet[i];
                i += 1;
            }
            if (i >= _newAlphabet.Length)
                break;
        }

        return _value;
    }

    public override string ToString()
    {
        var matrix = new StringBuilder();

        for (int i = 0; i < _value.GetLength(0); i++)
        {
            for (int j = 0; j < _value.GetLength(1); j++)
                matrix.Append(_value[i, j] + " ");

            matrix.Append("\n");
        }

        return matrix.ToString();
    }
}
