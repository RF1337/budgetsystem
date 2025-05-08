using budgetsystem.Shared.Data;
using budgetsystem.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace budgetsystem.Shared.Services
{
    public class AppUserService
    {
        private readonly MyDbContext _db;

        public AppUserService(MyDbContext db)
        {
            _db = db;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _db.AppUsers.ToListAsync();
        }

        public async Task<AppUser?> GetByIdAsync(int id)
        {
            return await _db.AppUsers.FindAsync(id);
        }

        public async Task AddAsync(AppUser user)
        {
            _db.AppUsers.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}
