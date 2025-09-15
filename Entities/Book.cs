namespace WebApplication_NET_CORE.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        //NAVIGATION PROPERTY
        public Author Author { get; set; } = new Author();
        public Category Category { get; set; } = new Category();
        //NAVIGATION PROPERTY INVERSO
        public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();

    }
}
