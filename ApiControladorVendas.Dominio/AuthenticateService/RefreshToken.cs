namespace ApiControladorVendas.Dominio.AuthenticateService
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public byte[] Token { get; set; }
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
