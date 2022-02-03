using System.ComponentModel.DataAnnotations;

namespace SahaBT.Entities.Model.ViewModel
{
    public class StudentLessonAddModel
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public int StudentAge { get; set; }
        [Required]
        public string LessonCode { get; set; }
    }

}
