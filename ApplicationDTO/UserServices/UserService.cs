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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RequestResultDTO> Create(CreateUserDTO model)
        {
            try
            {
                User user = new User
                {
                    Name = model.Name,
                    Birthdate = model.Birthdate,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,

                };
                _userRepository.Create(user);
                await _userRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "User created successfully",
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

        public async Task<RequestResultDTO> Disable(int id)
        {
            try
            {
                await _userRepository.Disable(id);
                await _userRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "User disabled successfully",
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

        public async Task<List<UserDTO>> GetAll()
        {
            return await _userRepository.GetAll<User>()
                .Select(user => new UserDTO
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
                        UserId = r.UserId,
                        DateRequestClosed = r.DateRequestClosed,
                        DateRequestOpen = r.DateRequestOpen,
                        RequestStatus = r.RequestStatus,
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<UserDTO> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            return new UserDTO
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
                        UserId = r.UserId,
                        DateRequestClosed = r.DateRequestClosed,
                        DateRequestOpen = r.DateRequestOpen,
                        RequestStatus = r.RequestStatus,
                    }).ToList(),
            };
        }

        public async Task<RequestResultDTO> Update(UserDTO model)
        {
            try
            {
                var user = await _userRepository.GetById(model.Id);
                user.Name = model.Name;
                user.Birthdate = model.Birthdate;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;

                _userRepository.Update(model.Id, user);

                await _userRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "User UPDATED successfully",
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
