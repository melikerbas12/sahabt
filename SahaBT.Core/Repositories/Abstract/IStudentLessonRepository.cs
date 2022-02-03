using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;

namespace SahaBT.Core.Repositories.Abstract
{
    public interface IStudentLessonRepository : IGenericRepository<StudentLesson>
    {
        bool IsThereCodeOfStudent(int studentId);
        bool IsThereStudentOfCode(string lessonCode);

    }
}
