using System.Collections.Generic;

namespace SahaBT.Shared
{
    public class Student : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
    }
}
