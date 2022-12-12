using Bitrix24Kashalot.TelegramBot;
using Bitrix24Kashalot.TelegramBot.Extensions;
using Bitrix24Kashalot.TelegramBot.Services;
using Microsoft.Extensions.Options;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder();

var botConfigSection = builder.Configuration.GetSection(TelegramApiConfiguration.Configuration);
builder.Services.Configure<TelegramApiConfiguration>(botConfigSection);

builder.Services.AddHttpClient("tgwebhook")
    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
    {
        var botConfig = sp.GetConfiguration<TelegramApiConfiguration>();
        return new TelegramBotClient(botConfig.BotToken, httpClient);
    });

builder.Services
    .AddHostedService<ConfigureWebhook>()
    .AddControllers()
    .AddNewtonsoftJson();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    var botConfig = endpoints.ServiceProvider.GetConfiguration<TelegramApiConfiguration>();
    
    endpoints.MapControllerRoute(
        name: "tgwebhook",
        pattern: botConfig.UrlWebhook.PathAndQuery,
        defaults: new { controller = "Webhook", action = "Post" }
    );
});

app.Run();