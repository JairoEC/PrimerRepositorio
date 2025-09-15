namespace WebApplication_NET_CORE.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        //NAVIGATION PROPERTY INVERSA
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
