using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class InterviewsDbContext:DbContext
{
    public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options):base(options)
    {
        
    }

    public DbSet<Interview> Interviews { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interview>(ConfigureInterview);
        modelBuilder.Entity<InterviewTypeLookUp>(ConfigureInterviewTypeLookUp);
        modelBuilder.Entity<Interviewer>(ConfigureInterviewer);
    }

    private void ConfigureInterview(EntityTypeBuilder<Interview> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.CandidateIdentityId).IsUnique();
    }

    private void ConfigureInterviewTypeLookUp(EntityTypeBuilder<InterviewTypeLookUp> builder)
    {
        builder.HasKey(i => i.Id);
    }

    private void ConfigureInterviewer(EntityTypeBuilder<Interviewer> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.EmployeeIdentityId).IsUnique();
    }
}