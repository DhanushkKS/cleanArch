using CleanArch.Domain;
using MediatR;

namespace CleanArch.Application.Queries;

public record GetMovieListQuery() :IRequest<List<Movie>> ;

public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<Movie>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieListQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public Task<List<Movie>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
    {
        List<Movie> movies = _movieRepository.GetAllMovies();
        return Task.FromResult(_movieRepository.GetAllMovies());
    }
}