using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class RestContext : DbContext
    {
        public RestContext(DbContextOptions<RestContext> options)
            : base(options)
        {
        }

        public DbSet<RestItem> RestItems { get; set; }
    }
}