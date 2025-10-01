using lab1.Extensions;

namespace lab1.Utils;

public class PermutationsKey(string value)
{
	public string Value { get; private set; } = value.ToUpper().Trim().RemoveSpaces();


	public bool IsValid()
	{
		if (Value.Length < 7)
			return false;

		foreach (var letter in Value)
			if (!Alphabet.Value.Contains(letter))
				return false;

		return true;
	}
}