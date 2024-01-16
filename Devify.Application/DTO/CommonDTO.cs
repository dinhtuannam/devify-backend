using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            result = false;
            message = "";
            data = new object();
            code = 0;
        }

        public ApiResponse(bool result, string message, object data, int code)
        {
            this.result = result;
            this.message = message;
            this.data = data;
            this.code = code;
        }

        public bool result { get; set; } = false;
        public string message { get; set; } = "";
        public object data { get; set; } = new object();
        public int code { get; set; } = 0;
    }

    public class CommonDTO
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }

    public class DataList<T>
    {
        public List<T> datas { get; set; } = new List<T>();
        public int totalItem { get; set; } = 0;
        public int totalPage { get; set; } = 0;
        public int page { get; set; } = 0;
    }
}
