using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Bitrix24Kashalot.TelegramBot.Controllers;

public class WebhookController : ControllerBase
{
    private readonly ILogger<WebhookController> _logger;

    public WebhookController(ILogger<WebhookController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        _logger.LogInformation("New webhook connection");
        return Ok();
    }
}