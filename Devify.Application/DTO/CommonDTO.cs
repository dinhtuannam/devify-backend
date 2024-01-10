﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class ApiResponse
    {
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
}
