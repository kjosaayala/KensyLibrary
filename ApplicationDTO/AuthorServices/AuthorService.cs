
using Application.AuthorServices.Dtos;
using Application.Base;
using Domain.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;

        public AuthorService(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<RequestResultDTO> CreateAuthor(CreateAuthorDTO model)
        {
            try
            {
                Author author = new Author
                {
                    Name = model.Name
                };
                _authorRepository.Create(author);
                await _authorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Author created successfully",
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

        public async Task<RequestResultDTO> DisableAuthor(int id)
        {
            try
            {
                await _authorRepository.Disable(id);
                await _authorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Author disabled successfully",
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

        public async Task<List<AuthorDTO>> GetAllAuthors()
        {
            return await _authorRepository.GetAll<Author>()
                .Select(x => new AuthorDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<AuthorDTO> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetById(id);

            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
            };
        }

        public async Task<RequestResultDTO> UpdateAuthor(UpdateAuthorDTO model)
        {
            try
            {
                var author = await _authorRepository.GetById(model.Id);
                author.Name = model.Name;


                _authorRepository.Update(model.Id, author);

                await _authorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Author UPDATED successfully",
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
