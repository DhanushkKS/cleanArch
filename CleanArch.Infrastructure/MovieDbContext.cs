using CleanArch.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure;

public class MovieDbContext : DbContext,IMovieDbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1 to *
        modelBuilder.Entity<Member>()
            .HasOne<Rental>(s => s.Rental)
            .WithMany(r => r.Members)
            .HasForeignKey(s => s.RentalId);
        
        //Many to many
        modelBuilder.Entity<MovieRental>()
            .HasKey(g => new { g.RentalId, g.MovieId });
        //handle decimals to avoid 
        modelBuilder.Entity<Rental>()
            .Property(p => p.RentalCost)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Movie>()
            .Property(p => p.RentalCost)
            .HasColumnType("decimal(18,2)");
    }


    public DbSet<Movie> Movies { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<MovieRental> MovieRentals { get; set; }
}