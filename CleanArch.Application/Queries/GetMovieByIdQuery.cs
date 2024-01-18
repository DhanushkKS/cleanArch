using CleanArch.Domain;
using MediatR;

namespace CleanArch.Application.Queries;

public record GetMovieByIdQuery(int Id):IRequest<Movie>;

public class GetMovieByIdQueryhandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieByIdQueryhandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        Movie movie = _movieRepository.GetMovieById(request.Id);
        return Task.FromResult(movie);
    }
}