using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using MusicStore.Services.Interface;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService service;
        private readonly ILogger<ConcertsController> logger;
        private readonly IGenreRepository genreRepository;

        public ConcertsController(IConcertService service, ILogger<ConcertsController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("title")]
        public async Task<IActionResult> Get(string? title)
        {
            var response = await service.GetAsync(title);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConcertRequestDto concertReq)
        {
            var response = await service.AddAsync(concertReq);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ConcertRequestDto concertReq)
        {
            var response = await service.UpdateAsync(id, concertReq);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.FinalizeAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Finalize(int id)
        {
            return Ok(await service.FinalizeAsync(id));
        }
    }
}