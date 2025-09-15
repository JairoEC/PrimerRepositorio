namespace WebApplication_NET_CORE.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        //NAVIGATION PROPERTY
        public Role? Role { get; set; }
        //NAVIGATION PROPERTY INVERSO
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
