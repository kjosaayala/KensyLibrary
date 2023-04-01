using Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices.Dtos
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
