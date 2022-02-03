using SahaBT.Shared.Model.ViewModel;
using System.Collections.Generic;

namespace SahaBT.Shared.Model.ResultModel
{
    public class StudentsByLessonCodeResponseModel : ResponseModel
    {
        public List<StudentsByLessonCodeModel> Data { get; set; }
    }

}
