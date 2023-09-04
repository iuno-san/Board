using Microsoft.EntityFrameworkCore;

namespace Board.Entities
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
            
        }

        public DbSet<WorkItem> workItems { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Address> addresses { get; set; }

    }
}
