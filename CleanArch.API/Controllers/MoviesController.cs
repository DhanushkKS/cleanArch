using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application;
using CleanArch.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: api/Movies
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        
    }
}
