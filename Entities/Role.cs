namespace WebApplication_NET_CORE.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        //NAVIGATION PROPERTY INVERSO
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
