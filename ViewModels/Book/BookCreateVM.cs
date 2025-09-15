namespace WebApplication_NET_CORE.ViewModels.Book
{
    public class BookCreateVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
