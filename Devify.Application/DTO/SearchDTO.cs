using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class CourseSearchParams
    {
        private int _page = 1;
        private int _pageSize = 12;

        public string? query { get; set; }

        public int page
        {
            get { return _page; }
            set { _page = (value != 0) ? value : 1; }
        }

        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value != 0) ? value : 12; }
        }
        public List<string>? cat { get; set; }
        public List<string>? lang { get; set; }
        public List<string>? lvl { get; set; }
    }
}
