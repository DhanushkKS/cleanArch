using CleanArch.Domain;

namespace CleanArch.Application;

public interface IMovieRepository
{
    List<Movie> GetAllMovies();
    Movie GetMovieById(int Id);
    Movie CreateMovie(Movie movie); 
}