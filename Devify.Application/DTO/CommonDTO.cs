using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class ApiResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public object Data { get; set; } = new object();
        public string ErrCode { get; set; } = "";
    }

    public class CommonDTO
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }
}
