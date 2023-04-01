using Application.Base;
using Application.LanguageServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LanguageServices
{
    public interface ILanguageService
    {
        Task<RequestResultDTO> AddLanguage(CreateLanguageDTO model);
        Task<RequestResultDTO> UpdateLanguage(LanguageDTO model);
        Task<RequestResultDTO> DisableLanguage(int id);
        Task<List<LanguageDTO>> GetAllLanguages();
        Task<LanguageDTO> GetLanguageById(int id);
    }
}
