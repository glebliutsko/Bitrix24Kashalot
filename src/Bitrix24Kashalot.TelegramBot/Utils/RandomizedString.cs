using System.Security.Cryptography;
using System.Text;

namespace Bitrix24Kashalot.TelegramBot.Utils;

public class RandomizedString
{
    private readonly IList<char> _chars;
    private readonly int _length;

    public RandomizedString(IList<char> chars, int length)
    {
        _chars = chars;
        _length = length;
    }

    public RandomizedString(string chars, int length) : this(chars.ToArray(), length)
    { }

    public string Generate()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < _length; i++)
        {
            var randomChar = RandomNumberGenerator.GetInt32(0, _chars.Count);
            stringBuilder.Append(_chars[randomChar]);
        }

        return stringBuilder.ToString();
    }
}