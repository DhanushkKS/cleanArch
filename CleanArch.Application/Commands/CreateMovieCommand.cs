using CleanArch.Domain;
using MediatR;

namespace CleanArch.Application.Commands;

public record CreateMovieCommand(Movie Movie):IRequest<Movie>;

public class CreateMoviecommandHandler : IRequestHandler<CreateMovieCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public CreateMoviecommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = _movieRepository.CreateMovie(request.Movie);
        return Task.FromResult(movie);
    }
}