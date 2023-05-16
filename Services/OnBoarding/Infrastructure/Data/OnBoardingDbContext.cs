using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class OnBoardingDbContext:DbContext
{
    public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options):base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(ConfigureEmployees);
        modelBuilder.Entity<EmployeeStatusLookUp>(ConfigureEmployeeStatusLookUps);
    }

    private void ConfigureEmployees(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.EmployeeIdentityId).IsUnique();
        builder.HasOne(e => e.EmployeeStatusLookUp)
            .WithMany()
            .HasForeignKey(e => e.EmployeeStatusId);
    }
    
    private void ConfigureEmployeeStatusLookUps(EntityTypeBuilder<EmployeeStatusLookUp> builder)
    {
        builder.HasKey(e => e.Id);
    }

}