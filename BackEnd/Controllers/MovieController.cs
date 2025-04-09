using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers;

[ApiController]
[Route("/api/movies")]
public class MovieController: ControllerBase
{
    private readonly ILogger<MovieController> _logger;

    private readonly MovieServices Services;

    public MovieController(ILogger<MovieController> logger, AppDbContext context)
    {
        this._logger = logger;
        this.Services = new MovieServices(context);
    }

    [HttpGet("all", Name = "GetMovies")]
    public async Task<ActionResult<List<Movie>>> GetAll()
    {
        return Ok(await this.Services.GetAll());
    }

    [HttpGet("showing", Name = "GetShowingMovies")]
    public async Task<ActionResult<List<Movie>>> GetShowing()
    {
        return Ok(await this.Services.GetShowing());
    }

    [HttpGet("upcoming", Name = "GetUpcomingMovies")]
    public async Task<ActionResult<List<Movie>>> GetUpcoming()
    {
        return Ok(await this.Services.GetUpcoming());
    }

    [HttpGet("all/{id}", Name = "GetWithID")]
    public async Task<ActionResult<Movie>> GetWithID(Guid id)
    {
        var movie = await this.Services.GetWithID(id);
        return movie is null ? NotFound() : Ok(movie);
        
    }

    [HttpGet("detail/{id}", Name = "GetMovieDetail")]
    public async Task<ActionResult<Movie>> GetMovieDetail(Guid id)
    {
        var movie = await this.Services.GetMovieDetail(id);
        return movie is null ? NotFound() : Ok(movie);
    }

    [HttpPost("all", Name = "AddMovie")]
    public async Task<ActionResult<Movie>> AddMovie(Movie movie)
    {
        var newMovie = await this.Services.AddMovie(movie);
        return newMovie is not null ? Ok(newMovie) : Conflict();
    }

    [HttpDelete("all/{id}", Name = "DeleteMovie")]
    public async Task<ActionResult> DeleteMovie(Guid id)    
    {
        bool isDeleted = await this.Services.DeleteMovie(id);
        return isDeleted ? Ok() : NotFound();
    }
    
}