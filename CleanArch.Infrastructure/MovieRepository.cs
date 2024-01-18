using CleanArch.Application;
using CleanArch.Domain;

namespace CleanArch.Infrastructure;

public class MovieRepository : IMovieRepository
{
  

    private readonly MovieDbContext _movieDbContext;
    public MovieRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    public List<Movie> GetAllMovies()
    {
     return   _movieDbContext.Movies.ToList();
    }

    public Movie GetMovieById(int Id)
    {
        Movie movie = _movieDbContext.Movies.FirstOrDefault(m => m.MovieId == Id);
        return movie;
    }

    public Movie CreateMovie(Movie movie)
    {
        _movieDbContext.Movies.Add(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }
}