namespace WebApplication_NET_CORE.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int RoleId { get; set; }
        //NAVIGATION PROPERTY
        public Role? Role { get; set; }
    }
}
