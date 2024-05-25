namespace ApiControladorVendas.Api.Extencoes.Token
{
    public static class TokenVerificationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenVerification(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenVerificationMiddleware>();
        }
    }
}
