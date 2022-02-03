using SahaBT.Core.Repositories.Abstract;
using System;
using System.Threading.Tasks;

namespace SahaBT.Core.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ILessonRepository LessonRepository { get; }
        IStudentLessonRepository StudentLessonRepository { get; }
        Task<int> Complete();
    }
}
