using Microsoft.Extensions.Options;

namespace Bitrix24Kashalot.TelegramBot.Extensions;

public static class ServiceProviderExtensions
{
    public static T GetConfiguration<T>(this IServiceProvider sp) where T : class
    {
        var configurationSection = sp.GetService<IOptions<T>>();
        if (configurationSection == null)
            throw new ArgumentNullException(nameof(T));

        return configurationSection.Value;
    }
}