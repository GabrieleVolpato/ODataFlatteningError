using Microsoft.EntityFrameworkCore;
using ODataFlattening.Models;

namespace ODataFlattening
{
    public class FlatteningContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }

        public DbSet<Child> Children { get; set; }

        public FlatteningContext(DbContextOptions<FlatteningContext> options) : base(options)
        { }
    }
}
