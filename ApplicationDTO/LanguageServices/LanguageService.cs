using Application.AuthorServices.Dtos;
using Application.Base;
using Application.LanguageServices.Dtos;
using Domain.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> _languagRepository;

        public LanguageService(IGenericRepository<Language> languagRepository)
        {
            _languagRepository = languagRepository;
        }

        public async Task<RequestResultDTO> AddLanguage(CreateLanguageDTO model)
        {
            try
            {
                Language author = new Language
                {
                    Name = model.Name
                };
                _languagRepository.Create(author);
                await _languagRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Language created successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {
                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }

        public async Task<RequestResultDTO> DisableLanguage(int id)
        {
            try
            {
                await _languagRepository.Disable(id);
                await _languagRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Language disabled successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {

                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }

        public async Task<List<LanguageDTO>> GetAllLanguages()
        {
            return await _languagRepository.GetAll<Language>()
                .Select(x => new LanguageDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<LanguageDTO> GetLanguageById(int id)
        {
            var language = await _languagRepository.GetById(id);

            return new LanguageDTO
            {
                Id = language.Id,
                Name = language.Name,
            };
        }

        public async Task<RequestResultDTO> UpdateLanguage(LanguageDTO model)
        {
            try
            {
                var language = await _languagRepository.GetById(model.Id);
                language.Name = model.Name;


                _languagRepository.Update(model.Id, language);

                await _languagRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Language UPDATED successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {
                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }
    }
}
