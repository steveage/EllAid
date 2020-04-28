using EllAid.DataSource.Adapters.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace EllAid.DataSource.DataAccess.Context
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("People");
            modelBuilder.Entity<InstructorDto>().HasPartitionKey(i => i.Email);
            modelBuilder.Entity<InstructorDto>().HasDiscriminator(i => i.Type);
            modelBuilder.Entity<InstructorDto>().HasKey(instructor => instructor.Id);
            modelBuilder.Entity<InstructorDto>().Property(i => i.Id).ToJsonProperty<string>("id");
            modelBuilder.Entity<InstructorDto>().OwnsMany(instructor => instructor.Assistants, assistant => assistant.Property<string>("Id").ToJsonProperty("id"));
            modelBuilder.Entity<InstructorDto>().OwnsOne(instructor => instructor.EllCoach, coach => coach.Property<string>("Id").ToJsonProperty("id"));
            modelBuilder.Entity<EllCoachDto>().HasPartitionKey(c => c.Email);
            modelBuilder.Entity<EllCoachDto>().HasDiscriminator(i => i.Type);
            modelBuilder.Entity<EllCoachDto>().HasKey(instructor => instructor.Id);
            modelBuilder.Entity<EllCoachDto>().Property(i => i.Id).ToJsonProperty<string>("id");
            modelBuilder.Entity<EllCoachDto>().OwnsMany(coach => coach.Instructors, instructor => instructor.Property<string>("Id").ToJsonProperty("id"));
            modelBuilder.Entity<AssistantDto>().HasPartitionKey(a => a.Email);
            modelBuilder.Entity<AssistantDto>().HasDiscriminator(a => a.Type);
            modelBuilder.Entity<AssistantDto>().HasKey(a => a.Id);
            modelBuilder.Entity<AssistantDto>().Property(a => a.Id).ToJsonProperty<string>("id");
            modelBuilder.Entity<AssistantDto>().OwnsOne(a => a.Instructor, instructor => instructor.Property<string>("Id").ToJsonProperty("id"));
        }
    }
}