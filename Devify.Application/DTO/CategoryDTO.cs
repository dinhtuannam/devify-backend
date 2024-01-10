using Devify.Entity;

namespace Devify.Application.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Courses = new List<SqlCourse>(); // Initialize the property in the constructor
        }
        public string CategoryId { get; set; }
        public ICollection<SqlCourse> Courses { get; set; }
    }
}
