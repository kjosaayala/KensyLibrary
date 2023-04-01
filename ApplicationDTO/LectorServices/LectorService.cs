using Application.AuthorServices.Dtos;
using Application.Base;
using Application.BookRequestServices.Dtos;
using Application.UserServices.Dtos;
using Domain.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Z.Expressions;

namespace Application.UserServices
{
    public class LectorService : ILectorService
    {
        private readonly IGenericRepository<Lector> _lectorRepository;

        public LectorService(IGenericRepository<Lector> userRepository)
        {
            _lectorRepository = userRepository;
        }

        public async Task<RequestResultDTO> AddLector(CreateLectorDTO model)
        {
            try
            {
                Lector lector = new Lector
                {
                    Name = model.Name,
                    Birthdate = model.Birthdate,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,

                };
                _lectorRepository.Create(lector);
                await _lectorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Lector added successfully",
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

        public async Task<RequestResultDTO> DisableLector(int id)
        {
            try
            {
                await _lectorRepository.Disable(id);
                await _lectorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Lector disabled successfully",
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

        public async Task<List<LectorDTO>> GetAllLectors()
        {
            return await _lectorRepository.GetAll<Lector>()
                .Select(user => new LectorDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Birthdate = user.Birthdate,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    BookRequests = user.BookRequests.Select(
                    r => new BookRequestDTO
                    {
                        Id = r.Id,
                        LectorId = r.LectorId,
                        DateRequestClosed = r.DateRequestClosed,
                        DateRequestOpen = r.DateRequestOpen,
                        RequestStatus = r.RequestStatus,
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<LectorDTO> GetLectorById(int id)
        {
            var user = await _lectorRepository.GetById(id);

            return new LectorDTO
            {
                Id = user.Id,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                BookRequests = user.BookRequests.Select(
                    r => new BookRequestDTO
                    {
                        Id = r.Id,
                        LectorId = r.LectorId,
                        DateRequestClosed = r.DateRequestClosed,
                        DateRequestOpen = r.DateRequestOpen,
                        RequestStatus = r.RequestStatus,
                    }).ToList(),
            };
        }

        public async Task<RequestResultDTO> UpdateLector(LectorDTO model)
        {
            try
            {
                var lector = await _lectorRepository.GetById(model.Id);
                lector.Name = model.Name;
                lector.Birthdate = model.Birthdate;
                lector.Email = model.Email;
                lector.PhoneNumber = model.PhoneNumber;
                lector.Address = model.Address;

                _lectorRepository.Update(model.Id, lector);

                await _lectorRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Lector updated successfully",
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
