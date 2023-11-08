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

    [HttpGet]
    public IActionResult GetMovies() 
    {
        var movies = _repository.Movie.GetMovies();
        var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies); 

        return Ok(moviesDto);     
    }
}
