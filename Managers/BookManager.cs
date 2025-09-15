using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_NET_CORE.Context;
using WebApplication_NET_CORE.Entities;
using WebApplication_NET_CORE.ViewModels.Book;

namespace WebApplication_NET_CORE.Managers
{
    public class BookManager(AppDbContext _dbContext)
    {
        public async Task<List<BookVM>> GetAllAsync()
        {
            var list = await _dbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Select(b => new BookVM()
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    SubTitle = b.Subtitle,
                    Price = b.Price,
                    CategoryName = b.Category.CategoryName,
                    AuthorName = b.Author.AuthorName
                })
                .ToListAsync();
            return list;
        }
        public async Task<int> CreateAsync(BookCreateVM model)
        {
            var book = new Book
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Price = model.Price,
                CategoryId = model.CategoryId,
                AuthorId = model.AuthorId,
            };
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book.BookId;
        }
        public async Task<BookVM> GetByIdAsync(int id)
        {
            var book = await _dbContext.Books
                .Include (b => b.Category)
                .Include (b => b.Author)
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null) return null;

            return new BookVM
            {
                BookId = book.BookId,
                Title = book.Title,
                SubTitle = book.Subtitle,
                Price = book.Price,
                CategoryName= book.Category.CategoryName,
                AuthorName = book.Author.AuthorName
            };
        }
    }
}
