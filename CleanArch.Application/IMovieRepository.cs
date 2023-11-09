using CleanArch.Domain;

namespace CleanArch.Application;

public interface IMovieRepository
{
    List<Movie> GetAllMovies();
}