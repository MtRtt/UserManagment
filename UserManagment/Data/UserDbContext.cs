using Microsoft.EntityFrameworkCore;
using UserManagment.Models;

namespace UserManagment.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
    }
}
