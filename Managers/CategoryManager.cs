using Microsoft.EntityFrameworkCore;
using WebApplication_NET_CORE.Context;
using WebApplication_NET_CORE.Entities;
using WebApplication_NET_CORE.ViewModels.Category;

namespace WebApplication_NET_CORE.Managers
{
    public class CategoryManager(AppDbContext _dbContext)
    {
        public async Task<List<CategoryVM>> GetAllAsync()
        {
            var list = await _dbContext.Categories
                .Select(c => new CategoryVM
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                })
                .ToListAsync();
            return list;
        }
        public async Task<int> CreateAsync(CategoryVM model)
        {
            var category = new Category
            {
                CategoryName = model.CategoryName,
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category.CategoryId;
        }
        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            return await _dbContext.Categories
                .Where(c => c.CategoryId == id)
                .Select(c => new CategoryVM
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                })
                .FirstOrDefaultAsync();
        }
        public async Task<CategoryVM> EditById(CategoryVM model)
        {
            Category category = new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
