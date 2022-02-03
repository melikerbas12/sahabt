using System.Collections.Generic;

namespace SahaBT.Entities.Model.ViewModel
{
    public class StudentsModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public List<string> LessonCode { get; set; }
    }
}
