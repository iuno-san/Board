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

                eb.HasMany(w => w.comments)
                .WithOne(c => c.WorkItem)
                .HasForeignKey(c => c.WorkItemId);

                eb.HasOne(w => w.Author)
                .WithMany(u => u.WorkItems)
                .HasForeignKey(w => w.AuthorId);

                eb.HasMany(w => w.Tags)
                .WithMany(t => t.WorkItems)
                .UsingEntity<WorkItemTag>(
                    w => w.HasOne(wit => wit.Tag)
                    .WithMany()
                    .HasForeignKey(wit => wit.TagId),

                    w => w.HasOne(wit => wit.workItem)
                    .WithMany()
                    .HasForeignKey(wit => wit.workItemId),

                    wit => 
                    {
                        wit.HasOne(x => new { x.TagId, x.workItemId });
                        wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                    });
               

            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(wi => wi.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(wi => wi.UpdatedDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);
        }

    }
}
