using CleanArch.Domain;

namespace CleanArch.Application;

public interface IMovieService
//this is usecase
{
    
    List<Movie> GetAllMovies();
    Movie CreateMovie(Movie movie);
}