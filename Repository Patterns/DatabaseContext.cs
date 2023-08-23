using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository_Patterns.Models;
namespace Repository_Patterns
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts) { }

        public DbSet<Product> product { get; set; }
    }
}
