using System;

namespace Library
{
    public class Data
    {
        public Data(Group group, Lesson lesson, Teacher teacher, Auditorium auditorium, int daynumber, int lessonnumber)
        {
            grp = group;
            lssn = lesson;
            tchr = teacher;
            ad = auditorium;
            DayNumber = daynumber;
            LessonNumber = lessonnumber;
        }
        public readonly Group grp;
        public readonly Lesson lssn;
        public readonly Teacher tchr;
        public readonly Auditorium ad;
        public readonly int DayNumber;
        public readonly int LessonNumber;
    }
}