using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Salvage.Domain.Validations;

namespace Salvage.Service.API
{
    public class FiltroCustomizadoDeExcecao : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isChamadaAjax = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if (isChamadaAjax)
            {
                context.HttpContext.Response.ContentType = "";
                context.HttpContext.Response.StatusCode = context.Exception is ExcecaoDeDominio ? 502 : 500;
                context.Result = context.Exception is ExcecaoDeDominio dominio ?
                    new JsonResult(dominio.Mensagens) :
                    new JsonResult("Ocorreu um erro inesperado");
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
