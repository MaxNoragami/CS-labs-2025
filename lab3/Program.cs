// - Romanian Language based
// - In case of a text with values that don't match the alphabet the correct set of values are shown
// - Key length no shorter than 7
// - Has option of choosing either the encryption or decryption operations
// - Input: Operation + Key + Message/Cipher
// * Make input generic if I feel like it

using lab3.Utils;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var key = Input.GetKey();
var text = Input.GetText();

Console.WriteLine($"Key: {key.Value}\nText: {text.Value}");