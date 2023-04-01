using Application.Base;
using Application.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices
{
    public interface IUserService
    {
        Task<RequestResultDTO> Create(CreateUserDTO model);
        Task<RequestResultDTO> Update(UserDTO model);
        Task<RequestResultDTO> Disable(int id);
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
    }
}
