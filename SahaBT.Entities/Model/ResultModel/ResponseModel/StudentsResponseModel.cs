using SahaBT.Entities.Model.ViewModel;
using System.Collections.Generic;

namespace SahaBT.Entities.Model.ResultModel
{
    public class StudentsResponseModel : ResponseModel
    {
        public List<StudentsModel> Data { get; set; }
    }

}
