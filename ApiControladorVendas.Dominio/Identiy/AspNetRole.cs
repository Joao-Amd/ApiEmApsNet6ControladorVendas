namespace ApiControladorVendas.Dominio.Identiys
{
    public class AspNetRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public ICollection<AspNetUserRole> UserRoles { get; set; }
    }

}
