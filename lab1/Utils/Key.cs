namespace lab1.Utils;

public class Key(int value)
{
	public int Value => value;

	public bool IsValid()
	{
		if (Value < 1 || Value > 25)
			return false;

		return true;
	}
}