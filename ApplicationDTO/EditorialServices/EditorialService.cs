using Application.AuthorServices.Dtos;
using Application.Base;
using Application.EditorialServices.Dtos;
using Domain.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EditorialServices
{
    public class EditorialService : IEditorialService
    {
        private readonly IGenericRepository<Editorial> _editorialRepository;

        public EditorialService(IGenericRepository<Editorial> editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        public async Task<RequestResultDTO> AddEditorial(CreateEditorialDTO model)
        {
            try
            {
                Editorial editorial = new Editorial
                {
                    Name = model.Name
                };
                _editorialRepository.Create(editorial);
                await _editorialRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Editorial created successfully",
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

        public async Task<RequestResultDTO> DisableEditorial(int id)
        {
            try
            {
                await _editorialRepository.Disable(id);
                await _editorialRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Editorial disabled successfully",
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

        public async Task<List<EditorialDTO>> GetAllEditorials()
        {
            return await _editorialRepository.GetAll<Editorial>()
                .Select(x => new EditorialDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<EditorialDTO> GetEditorialById(int id)
        {
            var editorial = await _editorialRepository.GetById(id);

            return new EditorialDTO
            {
                Id = editorial.Id,
                Name = editorial.Name,
            };
        }

        public async Task<RequestResultDTO> UpdateEditorial(EditorialDTO model)
        {
            try
            {
                var editorial = await _editorialRepository.GetById(model.Id);
                editorial.Name = model.Name;


                _editorialRepository.Update(model.Id, editorial);

                await _editorialRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Editorial UPDATED successfully",
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
