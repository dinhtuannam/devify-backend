using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application
{
    public interface ICourseRepository
    {
        Course GetCourseByName(string name);
        List<Course> GetAllCourse();
    }
}
