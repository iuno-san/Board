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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.Property(wi => wi.State).IsRequired();
                eb.Property(wi => wi.Area).HasColumnType("varchar200");
                eb.Property(wi => wi.IterationPath).HasColumnName("Iteration_Path");
                eb.Property(wi => wi.Efford).HasColumnType("decimal(5,2)");
                eb.Property(wi => wi.EndDate).HasPrecision(3);
                eb.Property(wi => wi.Activity).HasMaxLength(100);
                eb.Property(wi => wi.RemainingWork).HasPrecision(13,3);

            });
        }

    }
}
