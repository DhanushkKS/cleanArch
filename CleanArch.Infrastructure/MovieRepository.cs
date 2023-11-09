using CleanArch.Application;
using CleanArch.Domain;

namespace CleanArch.Infrastructure;

public class MovieRepository : IMovieRepository
{
    public static List<Movie> Movies = new List<Movie>()
    {
        new Movie{Id = 1,Name = "Main Hoon Na",Cost = 2},
        new Movie{Id = 2,Name = "Kal Hoo Na",Cost = 12},
        new Movie{Id = 3,Name = "Lucy",Cost = 2},

    };
    public List<Movie> GetAllMovies()
    {
        return Movies;
    }
}