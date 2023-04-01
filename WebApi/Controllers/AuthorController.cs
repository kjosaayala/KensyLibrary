using Application.AuthorServices;
using Application.AuthorServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]    
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {

            _authorService = authorService;
        }

        [HttpGet]
        public async Task<AuthorDTO> GetById(int id)
        {
            return await _authorService.GetById(id);
        }

        [HttpGet]
        public async Task<List<AuthorDTO>> GetAll()
        {
            return await _authorService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDTO model)
        {
            var response = await _authorService.Create(model);
            return Ok(response);
        }
    }
}
