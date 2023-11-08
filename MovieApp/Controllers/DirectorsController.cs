using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp;

[Route("api/directors")]
[ApiController]
public class DirectorsController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public DirectorsController(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // controller returns all directors from the database
    [HttpGet]
    public IActionResult GetMovies() 
    {
        var directors = _repository.Director.GetDirectors();
        var directorDto = _mapper.Map<IEnumerable<DirectorDto>>(directors); 

        return Ok(directorDto);     
    }

    // controller returns one director with the corresponding ID from the database
    [HttpGet("{id}")]
    public IActionResult GetDirector(int id)
    {
        var director = _repository.Director.GetDirector(id);
        if(director == null) 
        {
            return NotFound();
        }
        else
        {
            var directorDto = _mapper.Map<DirectorDto>(director);
            return Ok(directorDto);
        }
    }

}
