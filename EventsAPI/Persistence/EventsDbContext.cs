using EventsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Persistence
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext( DbContextOptions<EventsDbContext> options): base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>(e =>
            {
                e.HasKey(ev => ev.Id);

                e.Property(ev => ev.Title).IsRequired(false);
                e.Property(ev => ev.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(ev => ev.StartDate)
                    .HasColumnName("Start_Date");
                e.Property(ev => ev.EndDate)
                    .HasColumnName("End_Date");

                //evento tem varios palestrates
                e.HasMany(ev => ev.Speakers)
                     //Caso queria adicionar uma referencia do palestrando para o evento
                     //so cirar um na entidade palestrando e setar ele como um aqui, setaria o objeto e a chave estrangeira
                    .WithOne()
                    .HasForeignKey(s => s.EventId);
            });

            builder.Entity<Speaker>(e =>
            {
                e.HasKey(s => s.Id);
            });
        }


    }
}
