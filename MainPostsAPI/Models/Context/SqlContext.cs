using Microsoft.EntityFrameworkCore;

namespace MainPostsAPI.Models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostItem> PostItems { get; set; }
    }
}
