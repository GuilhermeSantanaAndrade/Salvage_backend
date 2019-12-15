using System;
using Salvage.Domain.Entities;
using Salvage.Infra.EnvioEmail.Interfaces;
using System.Net.Mail;
using System.Net.Mime;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Threading.Tasks;

namespace Salvage.Infra.EnvioEmail
{
    public class EmailSendGrid : IEnvioEmail
    {
        public string ApiKey { get; set; } = "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";
        public async Task<dynamic> EnviarPelaAPI(string destinatario, string assunto, string html)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("naoresponda@salvage.com.br", "Sistema Salvage - Não Responda");
            var to = new EmailAddress(destinatario);
            var msg = MailHelper.CreateSingleEmail(from, to, assunto, null, html);
            var response = await client.SendEmailAsync(msg);
            return new { header = response.Headers, body = response.Body, statusCode = response.StatusCode };
        }
        public async Task<(string,string, int)> Envia(string destinatario, string assunto, string html)
        {          
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("naoresponda@salvage.com.br", "Sistema Salvage - Não Responda"); 
            var to = new EmailAddress(destinatario);  
            var msg = MailHelper.CreateSingleEmail(from, to, assunto, null, html);
            var response = await client.SendEmailAsync(msg);
            return (response.Headers.ToString(), response.Body.ToString(), Convert.ToInt16(response.StatusCode));
        }

        public static string LayoutProximaAcao()
        {
           return @"
              <div class='container'  style='padding: 0; text-align: center;'>
                <div class='header' style='background-color: #ffd495; text-align: left;'>
                  <img
                    width='50'
                    height='50'
                    src=''
                    alt='Logo'>
                </div>
                <div class='body'>
                  <h2>Olá, {{nome}}</h2>
                  <p>Houve uma atualização de status e precisamos que você dê continuidade. <br>
                    <strong>Ação: </strong>{{texto}}.
                  </p> <br>
                  <a style='padding: 10px 20px; background-color:#1f497d; margin-top:20px; color: white; text-decoration: none;' href='{{link}}'>Concluir Tarefa</a>
                </div>
              </div> ";
        }
        public static string LayoutProcessoFinalizado(Salvado salvado)
        {
            return $@"
              <div class='container'  style='padding: 0; text-align: center;'>
                <div class='header' style='background-color: #ffd495; text-align: left;'>
                  <img
                    width='50'
                    height='50'
                    src=''
                    alt='Logo'>
                </div>
                <div class='body'>
                  <h1>Parabéns!!!</h1>
                  <h3>Esse Salvado teve o processo finalizado.</h3>
                  <p> 
                    <strong>Nome do Segurado: </strong> {salvado.NomeSegurado}<br />
                    <strong>Apólice: </strong> {salvado.Apolice}<br />
                    <strong>Sinistro: </strong> {salvado.Sinistro} <br />
                    <strong>Placa: </strong> {salvado.Placa}<br />
                    <strong>Modelo: </strong> {salvado.Modelo}<br />
                    <strong>Marca: </strong> {salvado.Marca}<br />
                    <strong>Cor: </strong> {salvado.Cor}<br />
                    <strong>Ano: </strong> {salvado.Ano.ToString()}<br />
                    Acompanhe todos os seus processos pelo nosso Dashboard
                  </p> <br>
                  <a style='padding: 10px 20px; background-color:#1f497d; margin-top:20px; color: white; text-decoration: none;' href='https://engsalvage.azurewebsites.net/#/'>Acessar Sistema</a>
                </div>
              </div> ";
        }
    }
}
