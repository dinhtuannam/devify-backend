using Devify.Application.DTO;
using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Interfaces
{
    public interface ILessonRepository : IGenericRepository<SqlLesson>
    {
        public List<DetailLessonDTO> getAllLesson();
    }
}
