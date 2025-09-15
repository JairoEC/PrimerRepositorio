namespace WebApplication_NET_CORE.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        //NAVIGATION PROPERTY INVERSA
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
