using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ApiControladorVendas.Api.Extencoes.Token
{
    public class TokenVerificationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenVerificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized && !context.Response.HasStarted)
            {
                await AdicionarMensagemTokenNaoEnviado(context);
            }
        }
        private async Task AdicionarMensagemTokenNaoEnviado(HttpContext context)
        {
            var mensagem = "Token de autenticação não enviado.";

            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(mensagem);
        }
    }
}
