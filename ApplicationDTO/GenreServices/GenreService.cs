
using Application.AuthorServices.Dtos;
using Application.Base;
using Application.GenreServices.Dtos;
using Domain.Data;
using Domain.Main;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> _genreRepository;
        public GenreService(IGenericRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<RequestResultDTO> AddGenre(CreateGenreDTO model)
        {
            try
            {
                Genre genre = new Genre
                {
                    Name = model.Name,
                    Description = model.Description,
                };
                _genreRepository.Create(genre);
                await _genreRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Genre added successfully",
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

        public async Task<RequestResultDTO> DisableGenre(int id)
        {
            try
            {
                await _genreRepository.Disable(id);
                await _genreRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Genre disabled successfully",
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

        public async Task<List<GenreDTO>> GetAllGenres()
        {
            return await _genreRepository.GetAll<Genre>()
                .Select(x => new GenreDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();
        }

        public async Task<GenreDTO> GetGenreById(int id)
        {
            var genre = await _genreRepository.GetById(id);

            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };
        }

        public async Task<RequestResultDTO> UpdateGenre(GenreDTO model)
        {
            try
            {
                var genre = await _genreRepository.GetById(model.Id);
                genre.Name = model.Name;
                genre.Description = model.Description;



                _genreRepository.Update(model.Id, genre);

                await _genreRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Genre" +
                    " UPDATED successfully",
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
