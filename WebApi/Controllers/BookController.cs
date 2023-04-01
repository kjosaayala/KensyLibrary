using Application.BookServices;
using Application.BookServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<BookDTO> GetById(int id)
        {
            return await _bookService.GetById(id);
        }

        [HttpGet]
        public async Task<List<BookDTO>> GetAll()
        {
            return await _bookService .GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDTO model)
        {
            var response = await _bookService.Create(model);
            return Ok(response);
        }
    }
}
