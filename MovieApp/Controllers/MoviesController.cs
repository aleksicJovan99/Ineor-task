﻿using AutoMapper;
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

    // controller returns all movies from the database
    [HttpGet]
    public IActionResult GetMovies() 
    {
        var movies = _repository.Movie.GetMovies();
        var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies); 

        return Ok(moviesDto);     
    }

    // controller returns one movie with the corresponding ID from the database
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

    // controller stores the movie entity in the database and returns the stored properties of the entity
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
