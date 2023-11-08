using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp;
[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public MoviesController(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // returns all movies from the database
    [HttpGet]
    public IActionResult GetMovies() 
    {
        var movies = _repository.Movie.GetMovies();
        var directors = _repository.Director.GetDirectors();
        var moviesDto = movies.Join(
            directors,
            m => m.DirectorId,
            d => d.Id,
            (m, d) => new 
            {
                Id = m.Id,
                Name = m.Name,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate,
                Director = d.Name
            }
        ).ToList();

        return Ok(moviesDto);     
    }

    // returns one movie with the corresponding ID from the database
    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        var movie = _repository.Movie.GetMovie(id);
        if(movie == null) 
        {
            return NotFound();
        }
        else
        {
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }
    }

    // stores the movie entity in the database and returns the stored properties of the entity
    [HttpPost]
    public IActionResult CreateMovie([FromBody]MovieForCreationDto movie) 
    {
        if(movie == null) return BadRequest("MovieForCreationDto object is null");

        var movieEntity = _mapper.Map<Movie>(movie);

        _repository.Movie.CreateMovie(movieEntity);
        _repository.Save(); 

        var toReturn = _mapper.Map<MovieDto>(movieEntity);

        return Ok(toReturn);
    }
}
