using System.Collections.Generic;

namespace SahaBT.Shared.Model
{
    public class ErrorResponse
    {
        public List<ErrorModel.ErrorModel> Errors { get; set; } = new List<ErrorModel.ErrorModel>();
    }
}
