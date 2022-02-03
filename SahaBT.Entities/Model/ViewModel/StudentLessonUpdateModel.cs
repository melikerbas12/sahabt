using System.ComponentModel.DataAnnotations;

namespace SahaBT.Entities.Model.ViewModel
{
    public class StudentLessonUpdateModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //public string LessonCode { get; set; }
    }
}
