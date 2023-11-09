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
                m.Id,
                m.Name,
                m.Rating,
                m.ReleaseDate,
                Director = d.Name
            }
        ).OrderBy(m => m.Id).ToList();

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

        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        var movieEntity = _mapper.Map<Movie>(movie);

        _repository.Movie.CreateMovie(movieEntity);
        _repository.Save(); 

        var toReturn = _mapper.Map<MovieDto>(movieEntity);

        return Ok(toReturn);
    }

    [HttpPost("collection")]
    public IActionResult CreateMovieCollection([FromBody]
    IEnumerable<MovieForCreationDto> movieCollection) 
    {
        if(movieCollection == null) return BadRequest("Movie collection object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }


        var movies = _mapper.Map<IEnumerable<Movie>>(movieCollection);
        foreach (var movie in movies) 
        {
            _repository.Movie.CreateMovie(movie);
        }
        _repository.Save(); 

        var toReturn = _mapper.Map<IEnumerable<MovieDto>>(movies);

        return CreatedAtRoute("MovieCollection" ,toReturn);
    }

    [HttpDelete]
    public IActionResult DeleteMovie(int id) 
    {
        var movie = _repository.Movie.GetMovie(id);

        if(movie == null) return NotFound();

        _repository.Movie.DeleteMovie(movie);
        _repository.Save();

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] MovieForUpdateDto movie) 
    {
        if(movie == null) return BadRequest("MovieForUpdateDto object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }


        var movieEntity = _repository.Movie.GetMovie(id);
        if(movieEntity == null) return NotFound();

        _mapper.Map(movie, movieEntity);
        _repository.Save();

        return NoContent();
    }
}
