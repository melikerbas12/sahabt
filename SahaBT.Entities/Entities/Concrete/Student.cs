using System.Collections.Generic;

namespace SahaBT.Entities
{
    public class Student : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
    }
}
