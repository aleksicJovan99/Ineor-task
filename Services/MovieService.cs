using AutoMapper;
using Contracts;
using Entities;

namespace Services;
public class MovieService : IMovieService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public MovieService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MovieDto> CreateMovie(MovieForCreationDto movie)
    {
        var movieEntity = _mapper.Map<Movie>(movie);

        _repository.Movie.CreateMovie(movieEntity);
        await _repository.SaveAsync(); 

        var movieDto = _mapper.Map<MovieDto>(movieEntity);   

        return movieDto;    
    }

    public async Task<IEnumerable<MovieDto>> CreateMovieCollection(IEnumerable<MovieForCreationDto> movieCollection)
    {
        var movies = _mapper.Map<IEnumerable<Movie>>(movieCollection);
        foreach (var movie in movies) 
        {
            _repository.Movie.CreateMovie(movie);
        }

        await _repository.SaveAsync(); 

        var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);

        return movieDtos;
    }

    public async Task DeleteMovie(int id)
    {
        var movie = await _repository.Movie.GetMovieAsync(id);
        if (movie == null) return;
        
        _repository.Movie.DeleteMovie(movie);
        await _repository.SaveAsync();
    }

    public async Task<MovieDto> GetMovie(int id)
    {
        var movie = await _repository.Movie.GetMovieAsync(id);
        if (movie == null) return null;        
        var director = await _repository.Director.GetDirectorAsync(movie.DirectorId);
        var movieDto = _mapper.Map<MovieDto>(movie);
        movieDto.DirectorName = director.Name;
        
        return movieDto;
        
    }

    public async Task<IEnumerable<MovieDto>> GetMovies() 
    {
        var movies = await _repository.Movie.GetMoviesAsync();
        if (movies == null) return null;

        var directors = await _repository.Director.GetDirectorsAsync();
        var moviesDto = movies.Join(
            directors,
            m => m.DirectorId,
            d => d.Id,
            (m, d) => new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate,
                DirectorName = d.Name
            }
        ).OrderBy(m => m.Id);

        return moviesDto;
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesPaging(MovieParameters movieParameters)
    {
        var movies = await _repository.Movie.GetMoviesPagingAsync(movieParameters);
        if (movies == null) return null;

        var directors = await _repository.Director.GetDirectorsAsync();
        var moviesDto = movies.Join(        
            directors,
            m => m.DirectorId,
            d => d.Id,
            (m, d) => new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                Rating = m.Rating,
                ReleaseDate = m.ReleaseDate,
                DirectorName = d.Name
            }
        ).OrderBy(m => m.Id);

        return moviesDto;     
    }

    public async Task UpdateMovie(int id, MovieForUpdateDto movie)
    {
        var movieEntity =  await _repository.Movie.GetMovieAsync(id);
        if (movieEntity == null) return;

        _mapper.Map(movie, movieEntity);
        await _repository.SaveAsync();
    }
}
