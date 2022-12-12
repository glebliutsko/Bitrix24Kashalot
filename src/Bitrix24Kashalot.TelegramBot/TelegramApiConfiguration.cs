using Bitrix24Kashalot.TelegramBot.Utils;

namespace Bitrix24Kashalot.TelegramBot;

public class TelegramApiConfiguration
{
    public static readonly string Configuration = "TelegramApi";
    
    public string BotToken { get; set; } = default!;
    public string UrlWebhookTemplate { get; set; } = default!;

    private Uri? _urlWebhook;
    public Uri UrlWebhook
    {
        get
        {
            if (_urlWebhook != null)
                return _urlWebhook;
            
            var randomizedString = new RandomizedString(
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
                50);
            _urlWebhook = new RandomizedUrl(UrlWebhookTemplate, randomizedString).Generate();

            return _urlWebhook;
        }
    }
}