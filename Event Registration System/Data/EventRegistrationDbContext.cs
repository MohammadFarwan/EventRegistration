using Event_Registration_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Registration_System.Data
{
    public class EventRegistrationDbContext : DbContext
    {
        public EventRegistrationDbContext(DbContextOptions<EventRegistrationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Tech Conference 2024",
                    Date = new DateTime(2024, 11, 15),
                    Description = "A conference to explore cutting-edge technologies.",
                    Capacity = 100
                },
                new Event
                {
                    Id = 2,
                    Title = "AI Workshop",
                    Date = new DateTime(2024, 12, 5),
                    Description = "Hands-on workshop on AI and machine learning.",
                    Capacity = 50
                }
            );
        }
    }

}
