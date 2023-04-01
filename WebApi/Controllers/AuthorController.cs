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
            return await _authorService.GetAuthorById(id);
        }

        [HttpGet]
        public async Task<List<AuthorDTO>> GetAll()
        {
            return await _authorService.GetAllAuthors();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDTO model)
        {
            var response = await _authorService.CreateAuthor(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDTO model)
        {
            var response = await _authorService.UpdateAuthor(model);
            return Ok(response);
        }
    }
}
