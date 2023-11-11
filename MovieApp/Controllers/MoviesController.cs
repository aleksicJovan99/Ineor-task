using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet(Name = "Get Movies")]
    public async Task<IActionResult> GetMovies() 
    {
        var movies = await _repository.Movie.GetMoviesAsync();
        var directors = await _repository.Director.GetDirectorsAsync();
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

    // returns movies from database in page format
    [HttpGet("paging")]
    public async Task<IActionResult> GetMoviesPaging([FromQuery]MovieParameters movieParameters) 
    {
        var movies = await _repository.Movie.GetMoviesPagingAsync(movieParameters);
        var directors = await _repository.Director.GetDirectorsAsync();
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
    public async Task<IActionResult> GetMovie(int id)
    {
        var movie = await _repository.Movie.GetMovieAsync(id);
        var director = await _repository.Director.GetDirectorAsync(movie.DirectorId);
        if(movie == null) 
        {
            return NotFound();
        }
        else
        {
            var movieDto = _mapper.Map<MovieDto>(movie);
            movieDto.DirectorName = director.Name;
            
            return Ok(movieDto);
        }
    }

    // stores the movie entity in the database and returns the stored properties of the entity
    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody]MovieForCreationDto movie) 
    {
        if(movie == null) return BadRequest("MovieForCreationDto object is null");

        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        var movieEntity = _mapper.Map<Movie>(movie);

        _repository.Movie.CreateMovie(movieEntity);
        await _repository.SaveAsync(); 

        var toReturn = _mapper.Map<MovieDto>(movieEntity);

        return CreatedAtRoute("Get Movies", toReturn);
    }

    // stores the movie list entity in the database and returns the stored properties of the entity
    [HttpPost("collection")]
    public async Task<IActionResult> CreateMovieCollection([FromBody]
    IEnumerable<MovieForCreationDto> movieCollection) 
    {
        if(movieCollection == null) return BadRequest("Movie collection object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }


        var movies = _mapper.Map<IEnumerable<Movie>>(movieCollection);
        foreach (var movie in movies) 
        {
            _repository.Movie.CreateMovie(movie);
        }

        await _repository.SaveAsync(); 

        var toReturn = _mapper.Map<IEnumerable<MovieDto>>(movies);

        return CreatedAtRoute("Get Movies" ,toReturn);
    }

    // deletes the movie entity from the database
    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMovie(int id) 
    {
        var movie = await _repository.Movie.GetMovieAsync(id);

        if(movie == null) return NotFound();

        _repository.Movie.DeleteMovie(movie);
        await _repository.SaveAsync();

        return NoContent();
    }

    // updates the movie entity from the database
    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieForUpdateDto movie) 
    {
        if(movie == null) return BadRequest("MovieForUpdateDto object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }


        var movieEntity = await _repository.Movie.GetMovieAsync(id);
        if(movieEntity == null) return NotFound();

        _mapper.Map(movie, movieEntity);
        await _repository.SaveAsync();

        return NoContent();
    }
}
