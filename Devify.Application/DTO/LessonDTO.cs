using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class DetailLessonDTO
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;
        public string image { get; set; } = "";
        public string video { get; set; } = "";
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
    }
}
