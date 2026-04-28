using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repositories;

namespace MusicStore.Api.Controllers;
[ApiController]
[Route("api/genres")]

public class GenresController : ControllerBase
{
    private readonly IGenreRepository repository;

    public GenresController(IGenreRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var genres = await repository.GetAsync();
        return Ok(genres);
    }

    [HttpGet("{id:int}")]
    public async Task <IActionResult> GetById(int id)
    {
        var genre = await repository.GetByIdAsync(id);
        if (genre is null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Genre genre)
    {
        await repository.AddAsync(genre);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, Genre genre)
    {
        await repository.UpdateAsync(id,genre);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {  
        await repository.DeleteAsync(id);
        return Ok();
    }
}

