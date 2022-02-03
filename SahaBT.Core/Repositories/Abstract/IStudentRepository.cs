using SahaBT.Core.Repositories.Generic;
using SahaBT.Shared;
using SahaBT.Shared.Model.ResultModel;
using SahaBT.Shared.Model.ViewModel;
using SahaBT.Shared.Pagination;
using System.Collections.Generic;

namespace SahaBT.Core.Repositories.Abstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        List<StudentsByLessonCodeModel> GetStudentsByLessonCode(int lessonId);
        StudentsPageModel GetStudents(PagingParameters model);
        TotalStudentCountModel GetStudentCount();
    }
}
