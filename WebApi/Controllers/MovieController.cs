using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperation.Commands.CreateMovies;
using WebApi.Application.MovieOperation.Commands.DeleteMovies;
using WebApi.Application.MovieOperation.Commands.UpdateMovies;
using WebApi.Application.MovieOperation.GetMovies.GetMoviesDetail;
using WebApi.Application.MovieOperation.Queries.GetMovies;
using WebApi.DBOperations;
using static WebApi.Application.MovieOperation.Commands.CreateMovies.CreateMoviesCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : Controller
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMoviesModel newMovie)
        {
            CreateMoviesCommand command = new CreateMoviesCommand(_dbContext, _mapper);
            command.Model = newMovie;
            CreateMoviesCommandValidator validator = new CreateMoviesCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMoviesCommand command = new DeleteMoviesCommand(_dbContext,_mapper);
            command.MoviesId = id;
            DeleteMoviesCommandValidator validator = new DeleteMoviesCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updatedMovie)
        {
            UpdateMoviesCommand command = new UpdateMoviesCommand(_dbContext,_mapper);
            command.MovieId = id;
            command.Model = updatedMovie;
            UpdateMoviesCommandValidator validator = new UpdateMoviesCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetMoviesDetailQuery query = new GetMoviesDetailQuery(_dbContext, _mapper);
            MoviesDetailViewModel result;

            query.MovieID = id;
            GetMoviesDetailQueryValidator validator = new GetMoviesDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


    }
}