using SahaBT.Entities.Shared.ResultModel;
using SahaBT.Shared.Model;
using SahaBT.Shared.Model.ResultModel;
using SahaBT.Shared.Model.ViewModel;
using SahaBT.Shared.Pagination;
using System.Threading.Tasks;

namespace SahaBT.Service.Abstract
{
    public interface IStudentService
    {
        Task<ResponseModel> Create(StudentLessonAddModel model);
        Task<ResponseModel> Update(StudentLessonUpdateModel model);
        Task<ResponseModel> Delete(int studentId);
        StudentsResponseModel GetStudents(PagingParameters model);
        StudentsByLessonCodeResponseModel GetStudentsByLessonCode(string lessonCode);
        TotalStudentCountResponseModel GetStudentCount();
    }
}
