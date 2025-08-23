using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moderador.API.Models;
using Moderador.Lib.interfaces;
using Moderador.Lib.Models;
using System.Text.Json;

namespace Moderador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeradorController : ControllerBase
    {
        private readonly ILogger<ModeradorController> _logger;
        private readonly IModeradorService _moderadorService;
        private readonly OpenAIConfig _openAIConfig;

        public ModeradorController(ILogger<ModeradorController> logger,
            IModeradorService moderadorService,
            IOptions<OpenAIConfig> openAIConfig)
        {
            _logger = logger;
            _moderadorService = moderadorService;
            _openAIConfig = openAIConfig.Value;
        }

        [HttpGet(Name = "GetModeracaoTexto")]
        public async Task<IActionResult> GetModeracaoTexto(string text)
        {
            try
            {
                _logger.LogInformation("Texto a ser moderado: {Text}", text);

                var moderarTextoRequest = ModeradorFactory.CreateModeradorTextoRequest(text, _openAIConfig.ApiKey);

                var result = await _moderadorService.ModerarTexto(moderarTextoRequest);

                _logger.LogInformation("Resultado: {Result}", JsonSerializer.Serialize(result));

                return Ok(new { Problematico = result.Value.Flagged });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao moderar texto: {Message}", e.Message);
                return StatusCode(500, "Erro interno do servidor ao processar a solicitação de moderação.");
            }
        }
    }
}
