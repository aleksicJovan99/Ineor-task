using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp;
[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IRepositoryManager _repository;

    public MoviesController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetMovies() 
    {
        try 
        {
            var movies = _repository.Movie.GetMovies();

            var moviesDto = movies.Select(m => new MovieDto 
            {
                Id = m.Id,
                Name = m.Name,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate
            }).ToList(); 

            return Ok(moviesDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
