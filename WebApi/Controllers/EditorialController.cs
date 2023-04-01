using Application.EditorialServices;
using Application.EditorialServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        [HttpGet]
        public async Task<EditorialDTO> GetById(int id)
        {
            return await _editorialService.GetById(id);
        }

        [HttpGet]
        public async Task<List<EditorialDTO>> GetAll()
        {
            return await _editorialService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEditorialDTO model)
        {
            var response = await _editorialService.Create(model);
            return Ok(response);
        }
    }
}
