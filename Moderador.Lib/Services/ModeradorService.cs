using System;
using System.ClientModel;
using Moderador.Lib.interfaces;
using Moderador.Lib.Models;
using OpenAI.Moderations;

namespace Moderador.Lib.Services
{
    public class ModeradorService : IModeradorService
    {
        public Task<ClientResult<ModerationResult>> ModerarTexto(ModerarTextoRequest moderarTextoRequest)
        {
            var client = OpenAIClientFactory.CreateModerationClientFactory(moderarTextoRequest.ApiKey);

            return client.ClassifyTextAsync(moderarTextoRequest.Texto);
        }
    }
}