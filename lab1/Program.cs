using lab1.Utils;

// 1.1
var key = new Key(6);
var cipher = new Text("qkwagrtotk");

if (!key.IsValid())
    throw new Exception("Invalid key!");
if (!cipher.IsValid())
    throw new Exception("Invalid text!");

var message = CaesarCipher.Decrypt(cipher, key);
Console.WriteLine(message.Value);

var newCipher = CaesarCipher.Encrypt(message, key);
Console.WriteLine(newCipher.Value);
Console.WriteLine(newCipher.Value.Equals(cipher.Value, StringComparison.OrdinalIgnoreCase));
