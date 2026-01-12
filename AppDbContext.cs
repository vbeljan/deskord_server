using deskord_server.Models;
using Microsoft.EntityFrameworkCore;

namespace deskord_server.Data{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        private void NotifyChange() {
            ChangeTrackerStateChanged?.Invoke(this, EventArgs.Empty);
        }
        
        public async Task<int> SaveChangesAndNotifyAsync() {
            var result = await SaveChangesAsync();

            // Notify change
            NotifyChange();

            return result;
        }

        public DbSet<Desk> desks {get; set;}
        public DbSet<User> users {get; set;}
        public event EventHandler ChangeTrackerStateChanged;
    }
    
    

    
}
