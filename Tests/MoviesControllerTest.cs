using Castle.Components.DictionaryAdapter.Xml;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieApp;

namespace Tests;
public class MoviesControllerTest
{
    private MoviesController _controller;
    private Mock<IMovieService> _service;

    [SetUp]
    public void SetUp() 
    {
        _service = new Mock<IMovieService>();
        _controller = new MoviesController(_service.Object);
            
    }

    [Test]
    public void GetMovies_ShouldReturnOkWithMoviesDtoList()
    {
        _service.Setup(s => s.GetMovies())
        .Returns(Task.FromResult(
            new List<MovieDto>() { new(){Id=1}, new(){Id=2} }
            .AsEnumerable()));

        var result = _controller.GetMovies().Result as ObjectResult;

        Assert.IsNotNull(result);
        Assert.That(result.StatusCode, Is.EqualTo(200));

        var movies = result.Value as IEnumerable<MovieDto>;

        Assert.IsNotNull(movies);
        Assert.That(movies.ToList().Count, Is.EqualTo(2));
    }

    [Test]
    public  void GetMovie_Id_ShouldReturnOkWithMovieDto()
    {
        int id = 1;
        _service.Setup(s => s.GetMovie(id))
        .Returns(Task.FromResult(
            new MovieDto() {Id=1} ));

        var result = _controller.GetMovie(id).Result as ObjectResult;

        Assert.IsNotNull(result);
        Assert.That(result.StatusCode, Is.EqualTo(200));

        var movie = result.Value as MovieDto;
        Assert.IsNotNull(movie);
    }



}
