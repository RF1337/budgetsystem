using budgetsystem.Shared.Data;
using budgetsystem.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace budgetsystem.Shared.Services
{
    public class CategoryService
    {
        private readonly MyDbContext _db;

        public CategoryService(MyDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
