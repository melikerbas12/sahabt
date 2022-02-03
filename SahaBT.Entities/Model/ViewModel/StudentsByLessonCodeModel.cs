using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahaBT.Entities.Model.ViewModel
{
    public class StudentsByLessonCodeModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<string> LessonCode { get; set; }
    }
}
