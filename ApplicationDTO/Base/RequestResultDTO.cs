using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base
{
    public class RequestResultDTO
    {
        public string? SuccesMessage { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
    }
}
