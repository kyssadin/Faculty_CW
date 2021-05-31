using System.Collections.Generic;

namespace Library
{
    public class LessonCell
    {
        public readonly List<Auditorium> takenAuds = new List<Auditorium>();
        public readonly List<Group> groups = new List<Group>();
        public readonly List<Lesson> lessons = new List<Lesson>();
        public readonly List<Teacher> takenTeachers = new List<Teacher>();
    }
}