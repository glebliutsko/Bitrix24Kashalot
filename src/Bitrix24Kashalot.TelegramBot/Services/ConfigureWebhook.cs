using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace Bitrix24Kashalot.TelegramBot.Services;

public class ConfigureWebhook : IHostedService
{
    private readonly ILogger<ConfigureWebhook> _logger;
    private readonly TelegramApiConfiguration _configuration;
    private readonly ITelegramBotClient _telegramBotClient;

    public ConfigureWebhook(ILogger<ConfigureWebhook> logger,
                            IOptions<TelegramApiConfiguration> options,
                            ITelegramBotClient telegramBotClient)
    {
        _logger = logger;
        _configuration = options.Value;
        _telegramBotClient = telegramBotClient;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Setting webhook URL: {_configuration.UrlWebhook}");
        await _telegramBotClient.SetWebhookAsync(
            url: _configuration.UrlWebhook.ToString(),
            cancellationToken: cancellationToken
        );
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting webhook");
        await _telegramBotClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}