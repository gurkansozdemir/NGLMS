using Microsoft.EntityFrameworkCore;
using NGLMS.Core.Models;

namespace NGLMS.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                        .HasOne(m => m.CreatedUser)
                        .WithMany(t => t.CreatedChats)
                        .HasForeignKey(m => m.CreatedUserId);

            modelBuilder.Entity<Chat>()
                        .HasOne(m => m.Receiver)
                        .WithMany(t => t.ReceiverChats)
                        .HasForeignKey(m => m.ReceiverId);

            modelBuilder.Entity<Message>()
                        .HasOne(m => m.Sender)
                        .WithMany(t => t.SendMessages)
                        .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<Message>()
                        .HasOne(m => m.Receiver)
                        .WithMany(t => t.ReceiveMessages)
                        .HasForeignKey(m => m.ReceiverId);
        }
    }
}
