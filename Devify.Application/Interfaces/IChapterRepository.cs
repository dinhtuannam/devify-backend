using Devify.Application.DTO;
using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Interfaces
{
    public interface IChapterRepository : IGenericRepository<SqlChapter>
    {
        Task<SqlChapter> CreateChapter(string course,string name, string des, int step);
        Task<SqlChapter> UpdateChapter(string code, string name, string des, int step);
        ChapterItem GetChapter(string code);
        DetailChapterDTO GetDetailChapter(string code);
        List<ChapterItem> GetListChapterByCourse(string code);
        Task<bool> DeleteChapter(string code);
    }
}
