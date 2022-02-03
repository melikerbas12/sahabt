using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;
using System.Collections.Generic;

namespace SahaBT.Core.Repositories.Abstract
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        void DeleteLessonIfNoStudent(List<int> ids);
        List<int> GetLessonIds(int studentId);
        Lesson GetLessonByCode(string lessonCode);
        List<string> GetLessonCodesByStudent(int studentId);
    }
}
