using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto.Request;
using MusicStore.Services.Interface;

namespace MusicStore.Api.Controllers;
[ApiController]
[Route("api/genres")]

public class GenresController : ControllerBase
{
    private readonly IGenreService service;

    public GenresController(IGenreService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await service.GetAsync();
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpGet("{id:int}")]
    public async Task <IActionResult> GetById(int id)
    {
        var response = await service.GetAsync(id);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GenreRequestDto genreReqDto)
    {
        var response = await service.AddAsync(genreReqDto);
        return response.Success ? Ok(response): BadRequest(response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, GenreRequestDto genreReqDto)
    {
        var response = await service.UpdateAsync(id, genreReqDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.Success ? Ok(response) : NotFound(response);
    }
}

