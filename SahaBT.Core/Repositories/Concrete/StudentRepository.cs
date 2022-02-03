using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Core.Repositories.Abstract;
using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;
using SahaBT.Shared.Model.ResultModel;
using SahaBT.Shared.Model.ViewModel;
using SahaBT.Shared.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahaBT.Core.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SahaBTContext context) : base(context)
        {

        }

        public TotalStudentCountModel GetStudentCount()
        {
            return new TotalStudentCountModel
            {
                TotalStudentCount = _context.Students.Count()
            };
        }

        public StudentsPageModel GetStudents(PagingParameters model)
        {
            //var query = await GetAll();

            //var students = query
            //.Select(x => new StudentsModel
            //{
            //    StudentId = x.Id,
            //    LessonCode = _context.StudentLessons.Where(sl => sl.StudentId == x.Id)
            //                 .Join(_context.Lessons,
            //                      sl => sl.LessonId,
            //                      l => l.Id,
            //                      (sl, l) => new { sl, l })
            //                 .Select(s => s.l.LessonCode).ToList(),
            //    StudentAge = x.Age,
            //    StudentName = x.Name
            //}).ToList();
            ////return students;

            var students = _context.Students.OrderBy(x => x.Id).AsQueryable();
            return new StudentsPageModel
            {
                Students = Task.FromResult(PagedList<Student>.GetPagedList(students, model.PageNumber, model.PageSize)).Result
                .Select(x => new StudentsModel
                {
                    StudentId = x.Id,
                    LessonCode = _context.StudentLessons.Where(sl => sl.StudentId == x.Id)
                     .Join(_context.Lessons,
                          sl => sl.LessonId,
                          l => l.Id,
                          (sl, l) => new { sl, l })
                     .Select(s => s.l.LessonCode).ToList(),
                    StudentAge = x.Age,
                    StudentName = x.Name
                }).ToList()
            };
        }
            

        public List<StudentsByLessonCodeModel> GetStudentsByLessonCode(int lessonId)
        {
            var students = _context.StudentLessons.Where(sl => sl.LessonId == lessonId)
                    .Join(_context.Students,
                       sl => sl.StudentId,
                       s => s.Id,
                       (sl, s) => new { sl, s }).ToList()
                  .Select(x => new StudentsByLessonCodeModel
                  {
                      StudentId = x.s.Id,
                      LessonCode = _context.StudentLessons.Where(sl => sl.StudentId == x.s.Id)
                             .Join(_context.Lessons,
                                  sl => sl.LessonId,
                                  l => l.Id,
                                  (sl, l) => new { sl, l })
                             .Select(s => s.l.LessonCode).ToList(),
                      StudentName = x.s.Name

                  }).ToList();
            return students;
        }

    }
}