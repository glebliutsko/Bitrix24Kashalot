using System.Security.Cryptography;
using System.Text;

namespace Bitrix24Kashalot.TelegramBot.Utils;

public class RandomizedUrl
{
    public const string TAG = "{SECRET}";
    
    private readonly RandomizedString _randomizedString;
    private readonly string _template;

    public RandomizedUrl(string template, RandomizedString randomizedString)
    {
        _template = template;
        _randomizedString = randomizedString;
    }
    
    public Uri Generate()
    {
        if (!_template.Contains(TAG))
            return new Uri(_template);

        return new Uri(_template.Replace(TAG, _randomizedString.Generate()));
    }
}