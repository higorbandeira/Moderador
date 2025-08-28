using OpenAI.Moderations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderador.Lib.Models
{
    public static class OpenAIClientFactory
    {
        public static ModerationClient CreateModerationClientFactory(string apiKey)
        {
            return new ModerationClient(
                model: "omni-moderation-latest",
                apiKey: apiKey
            );
        }
    }
}
