using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Core.Repositories.Abstract;
using SahaBT.Core.UnitOfWork.Abstract;
using System;
using System.Threading.Tasks;

namespace SahaBT.Core.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SahaBTContext _context;
        public IStudentRepository StudentRepository { get; }

        public ILessonRepository LessonRepository { get; }

        public IStudentLessonRepository StudentLessonRepository { get; }

        public UnitOfWork(SahaBTContext context,
            IStudentRepository studentRepository,
            ILessonRepository lessonRespository,
            IStudentLessonRepository studentLessonRepository)
        {
            this._context = context;
            this.StudentRepository = studentRepository;
            this.LessonRepository = lessonRespository;
            this.StudentLessonRepository = studentLessonRepository;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
