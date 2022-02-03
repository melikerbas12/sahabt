using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Core.Repositories.Abstract;
using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;
using System.Collections.Generic;
using System.Linq;

namespace SahaBT.Core.Repositories.Concrete
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        //private readonly SahaBTContext _context;
        //public LessonRepository(SahaBTContext context)
        //{
        //    _context = context;
        //}
        public LessonRepository(SahaBTContext context) : base(context)
        {

        }

        public List<int> GetLessonIds(int studentId)
        {
            return _context.StudentLessons.Where(sl => sl.StudentId == studentId)
                .Select(x => x.LessonId).ToList();
        }

        public void DeleteLessonIfNoStudent(List<int> lessonIds)
        {
            foreach (var lessonId in lessonIds)
            {
                var students = _context.StudentLessons.Where(sl => sl.LessonId == lessonId);
                if (students.Count() == 0)
                {
                    var lesson = _context.Lessons.FirstOrDefault(l => l.Id == lessonId);
                     Delete(lesson);
                    _context.SaveChanges();
                }
            }

        }

        public List<string> GetLessonCodesByStudent(int studentId)
        {
           return _context.StudentLessons.Where(sl => sl.StudentId == studentId)
                .Join(_context.Lessons,
                     sl => sl.LessonId,
                     l => l.Id,
                     (sl, l) => new { sl, l })
                .Select(s => s.l.LessonCode).ToList();
        }

        public Lesson GetLessonByCode(string lessonCode)
        {
            return _context.Lessons.FirstOrDefault(l => l.LessonCode == lessonCode);
        }
    }
}
