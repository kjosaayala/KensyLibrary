using Application.LanguageServices;
using Application.LanguageServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<LanguageDTO> GetById(int id)
        {
            return await _languageService.GetById(id);
        }

        [HttpGet]
        public async Task<List<LanguageDTO>> GetAll()
        {
            return await _languageService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLanguageDTO model)
        {
            var response = await _languageService.Create(model);
            return Ok(response);
        }
    }
}
