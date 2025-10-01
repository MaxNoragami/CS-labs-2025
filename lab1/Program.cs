using lab1.Utils;

// 1.1
var key = new Key(10);
var permutationsKey = new PermutationsKey("VICTOR");
var cipher = new Text("VMBGVMZQBQG");

if (!key.IsValid())
    throw new Exception("Invalid key!");
if (!permutationsKey.IsValid())
    throw new Exception("Invalid permutation key!");
if (!cipher.IsValid())
    throw new Exception("Invalid text!");

var message = CaesarCipher.Decrypt(cipher, key, permutationsKey);
Console.WriteLine(message.Value);

var newCipher = CaesarCipher.Encrypt(message, key, permutationsKey);
Console.WriteLine(newCipher.Value);
Console.WriteLine(newCipher.Value.Equals(cipher.Value, StringComparison.OrdinalIgnoreCase));
