using SahaBT.Entities.Model.ViewModel;
using System.Collections.Generic;

namespace SahaBT.Entities.Model.ResultModel
{
    public class StudentsByLessonCodeResponseModel : ResponseModel
    {
        public List<StudentsByLessonCodeModel> Data { get; set; }
    }

}
