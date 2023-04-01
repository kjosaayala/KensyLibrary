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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<UserDTO> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO model)
        {
            var response = await _userService.Create(model);
            return Ok(response);
        }
    }
}
