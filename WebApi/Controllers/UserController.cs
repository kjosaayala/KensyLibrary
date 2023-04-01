using Application.UserServices;
using Application.UserServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILectorService _lectorService;

        public UserController(ILectorService lectorService)
        {
            _lectorService = lectorService;
        }

        [HttpGet]
        public async Task<LectorDTO> GetById(int id)
        {
            return await _lectorService.GetLectorById(id);
        }

        [HttpGet]
        public async Task<List<LectorDTO>> GetAll()
        {
            return await _lectorService.GetAllLectors();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLectorDTO model)
        {
            var response = await _lectorService.AddLector(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LectorDTO model)
        {
            var response = await _lectorService.UpdateLector(model);
            return Ok(response);
        }
    }
}
