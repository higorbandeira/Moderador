using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Moderador.Lib.Models
{
    public static class ModeradorFactory
    {
        public static ModerarTextoRequest CreateModeradorTextoRequest(string text, string apiKey)
        {
            return new ModerarTextoRequest
            {
                Texto = text,
                ApiKey = apiKey
            };
        }
    }
}
