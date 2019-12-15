using System;
using System.Threading.Tasks;
using Salvage.Domain.Entities; 

namespace Salvage.Infra.EnvioEmail.Interfaces
{
    public interface IEnvioEmail
    {
        Task<(string, string, int)> Envia(string destinatario, string assunto, string html);
        Task<dynamic> EnviarPelaAPI(string destinatario, string assunto, string html);
    }
}
