using System.Collections.Generic;

namespace SahaBT.Entities
{
    public class Lesson : BaseEntity, IEntity
    {
        public string LessonCode { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
    }
}
