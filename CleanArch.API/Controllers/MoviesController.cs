using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application;
using CleanArch.Application.Commands;
using CleanArch.Application.Queries;
using CleanArch.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMediator _mediator;
        public MoviesController(IMovieService movieService, IMediator mediator)
        {
            _movieService = movieService;
            _mediator = mediator;
        }
        // GET: api/Movies
        [HttpGet]
        // public ActionResult<List<Movie>> Get()
        // {
        //     var movies = _movieService.GetAllMovies();
        //     return Ok(movies);
        // }
        public async Task<List<Movie>> Get()
        {
            return await _mediator.Send(new GetMovieListQuery());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Movie> GetById([FromRoute] int id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(id));                  
        }

        [HttpPost]
        // public ActionResult<Movie> Create(Movie movie)
        // {
        //     _movieService.CreateMovie(movie);
        //     return Ok(movie);
        // }
        public async Task<Movie> CreateMovie(CreateMovieCommand command)
        {
            return await _mediator.Send(command);
        }

        // [HttpDelete]
        // public ActionResult<Movie> Delete(int id)
        // {
        //     
        // }
        
    }
}
