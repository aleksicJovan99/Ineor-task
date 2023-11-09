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

    // returns all directors from the database
    [HttpGet]
    public IActionResult GetDirectors() 
    {
        var directors = _repository.Director.GetDirectors()
            .OrderBy(d => d.Id);
        var directorDto = _mapper.Map<IEnumerable<DirectorDto>>(directors); 

        return Ok(directorDto);     
    }

    // returns one director with the corresponding ID from the database
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

    // stores the director entity in the database and returns the saved entity properties 
    [HttpPost]
    public IActionResult CreateDirector([FromBody] DirectorForCreationDto director) 
    {
        if(director == null) return BadRequest("DirectorForCreationDto object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        var directorEntity = _mapper.Map<Director>(director);

        _repository.Director.CreateDirector(directorEntity);
        _repository.Save(); 

        var toReturn = _mapper.Map<DirectorDto>(directorEntity);

        return Ok(toReturn);
    }

    [HttpDelete]
    public IActionResult DeleteDirector(int id) 
    {
        var director = _repository.Director.GetDirector(id);

        if(director == null) return NotFound();

        _repository.Director.DeleteDirector(director);
        _repository.Save();

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector(int id, [FromBody] DirectorForUpdateDto director) 
    {
        if(director == null) return BadRequest("DirectorForUpdateDto object is null");
        if(!ModelState.IsValid) { return UnprocessableEntity(ModelState); }

        
        var directorEntity = _repository.Director.GetDirector(id);
        if(directorEntity == null) return NotFound();

        _mapper.Map(director, directorEntity);
        _repository.Save();

        return NoContent();
    }

}
