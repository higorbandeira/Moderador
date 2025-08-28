using Moderador.Lib.Models;
using OpenAI.Moderations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ClientModel;
using Moderador.Lib.interfaces;
using Moderador.Lib.Models;
using OpenAI.Moderations;

namespace Moderador.Lib.interfaces
{
    public interface IModeradorService
    {
        Task<ClientResult<ModerationResult>> ModerarTexto(ModerarTextoRequest request);
    }
}
