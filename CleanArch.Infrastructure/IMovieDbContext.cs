using CleanArch.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure;

public interface IMovieDbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<MovieRental> MovieRentals { get; set; }
}