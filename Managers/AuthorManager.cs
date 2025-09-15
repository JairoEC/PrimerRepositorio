using Microsoft.EntityFrameworkCore;
using WebApplication_NET_CORE.Context;
using WebApplication_NET_CORE.Entities;
using WebApplication_NET_CORE.ViewModels.Author;

namespace WebApplication_NET_CORE.Managers
{
    public class AuthorManager(AppDbContext _dbContext)
    {
        public async Task<List<AuthorVM>> GetAllAsync()
        {
            var list = await _dbContext.Authors
                .Select(a => new AuthorVM
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                })
                .ToListAsync();
            return list;
        }
        public async Task<int> CreateAsync(AuthorCreateVM authorVM)
        {
            var author = new Author
            {
                AuthorName = authorVM.AuthorName,
            };
            _dbContext.Add(author);
            await _dbContext.SaveChangesAsync();
            return author.AuthorId;
        }
        public async Task<AuthorVM> GetByIdAsync(int id)
        {
            var author = await _dbContext.Authors
                .Where(a => a.AuthorId == id)
                .FirstOrDefaultAsync();
            return new AuthorVM
            {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName,
            };
        }
        public async Task<AuthorVM> EditAsync(AuthorVM model)
        {
            var author = new Author
            {
                AuthorId = model.AuthorId,
                AuthorName = model.AuthorName,
            };
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
            return model;

        }
    }
}
