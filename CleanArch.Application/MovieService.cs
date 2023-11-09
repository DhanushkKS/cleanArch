using CleanArch.Domain;

namespace CleanArch.Application;

public class MovieService :IMovieService
{
    private readonly IMovieRepository _movieRepository;

    //Constructor dependency injection
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public List<Movie> GetAllMovies()
    {
        var movies = _movieRepository.GetAllMovies();
        return movies;
    }
}