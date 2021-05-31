namespace Library
{
    public class Teacher
    {
        private readonly string _name;
        public string discipline { get; private set; }
        public int workingHours = 0;

        public Teacher(string name, string subject)
        {
            _name = name;
            discipline = subject;
        }

        public void AddLesson()
        {
            workingHours++;
        }

        public void RemoveLesson()
        {
            workingHours--;
        }

        public string GetName()
        {
            return _name;
        }
    }
}