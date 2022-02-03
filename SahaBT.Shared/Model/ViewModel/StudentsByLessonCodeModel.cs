using System.Collections.Generic;

namespace SahaBT.Shared.Model.ViewModel
{
    public class StudentsByLessonCodeModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<string> LessonCode { get; set; }
    }
}
