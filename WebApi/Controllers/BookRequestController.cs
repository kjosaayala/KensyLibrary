using Application.BookRequestServices;
using Application.BookRequestServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private readonly IBookRequestService _bookRequestService;
        public BookRequestController(IBookRequestService bookRequestService)
        {
            _bookRequestService = bookRequestService;
        }

        [HttpGet]
        public async Task<BookRequestDTO> GetById(int id)
        {
            return await _bookRequestService.GetBookRequestById(id);
        }

        [HttpGet]
        public async Task<List<BookRequestDTO>> GetAll()
        {
            return await _bookRequestService.GetAllBookRequests();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDTO model)
        {
            var response = await _bookRequestService.GenerateBookRequest(model);
            return Ok(response);
        }
    }
}
