namespace WebApplication_NET_CORE.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime DateSale { get; set; }
        public int UserId { get; set; }
        //NAVIGATION PROPERTY
        public User User { get; set; } = new User();
        //NAVIGATION PROPERTY INVERSO
        public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();
    }
}
