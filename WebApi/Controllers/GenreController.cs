using Application.GenreServices;
using Application.GenreServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<GenreDTO> GetById(int id)
        {
            return await _genreService.GetById(id);
        }

        [HttpGet]
        public async Task<List<GenreDTO>> GetAll()
        {
            return await _genreService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDTO model)
        {
            var response = await _genreService.Create(model);
            return Ok(response);
        }
    }
}
