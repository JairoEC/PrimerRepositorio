namespace WebApplication_NET_CORE.Entities
{
    public class SaleDetail
    {
        public int SaleId { get; set; }
        public int BookId { get; set; }
        public Decimal Price { get; set; }
        public Decimal SubTotal { get; set; }
        public int Quantity { get; set; }
        //NAVIGATION PROPERTY
        public Sale Sale { get; set; } = new Sale();
        public Book Book { get; set; } = new Book();
    }
}
