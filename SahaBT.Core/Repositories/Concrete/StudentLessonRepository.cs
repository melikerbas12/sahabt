using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Core.Repositories.Abstract;
using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;
using System.Linq;

namespace SahaBT.Core.Repositories.Concrete
{
    public class StudentLessonRepository : GenericRepository<StudentLesson>, IStudentLessonRepository
    {

        public StudentLessonRepository(SahaBTContext context) : base(context)
        {

        }

        public bool IsThereCodeOfStudent(int studentId)
        {
            var result = _context.StudentLessons.Where(sl => sl.StudentId == studentId).ToList();
            if (result.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsThereStudentOfCode(string lessonCode)
        {
            var lesson = _context.Lessons.FirstOrDefault(l => l.LessonCode == lessonCode);
            var result = _context.StudentLessons.Where(sl => sl.LessonId == lesson.Id).ToList();
            if (result.Count() > 0)
            {
                return true;
            }
            return false;
        }

    }
}
