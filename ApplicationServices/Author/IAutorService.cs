using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Author
{
    public interface IAutorService
    {
        Task Create();
        Task CreateRange();
        Task Update();
        Task GetById();
        Task GetAll();
        Task Delete();
    }
}
