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
            return await _bookService.GetBookById(id);
        }

        [HttpGet]
        public async Task<List<BookDTO>> GetAll()
        {
            return await _bookService .GetAllBooks();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDTO model)
        {
            var response = await _bookService.AddBook(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookDTO model)
        {
            var response = await _bookService.UpdateBook(model);
            return Ok(response);
        }
    }
}
