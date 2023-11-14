using Contracts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp;
[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        _service = service;
    }

    // returns all movies from the database
    [HttpGet(Name = "Get Movies")]
    public async Task<IActionResult> GetMovies() 
    {
        var result = await _service.GetMovies();  

        return Ok(result);     
    }

    // returns movies from database in page format
    [HttpGet("paging")]
    public async Task<IActionResult> GetMoviesPaging([FromQuery]MovieParameters movieParameters) 
    {
        var result = await _service.GetMoviesPaging(movieParameters);

        return Ok(result);     
    }

    // returns one movie with the corresponding ID from the database
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id)
    {
        var result = await _service.GetMovie(id);

        if(result == null) 
        {
            return NotFound();
        }
        else
        {            
            return Ok(result);
        }
    }

    // stores the movie entity in the database and returns the stored properties of the entity
    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody]MovieForCreationDto movie) 
    {
        if(movie == null) return BadRequest("MovieForCreationDto object is null");

        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        var result = await _service.CreateMovie(movie);

        return CreatedAtRoute("Get Movies", result);
    }

    // stores the movie list entity in the database and returns the stored properties of the entity
    [HttpPost("collection")]
    public async Task<IActionResult> CreateMovieCollection([FromBody]
    IEnumerable<MovieForCreationDto> movieCollection) 
    {
        if(movieCollection == null) return BadRequest("Movie collection object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        var result = await _service.CreateMovieCollection(movieCollection);

        return CreatedAtRoute("Get Movies" ,result);
    }

    // deletes the movie entity from the database
    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMovie(int id) 
    {
        await _service.DeleteMovie(id);

        return NoContent();
    }

    // updates the movie entity from the database
    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieForUpdateDto movie) 
    {
        await _service.UpdateMovie(id, movie);

        return NoContent();
    }
}
