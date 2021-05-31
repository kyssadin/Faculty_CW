namespace Library
{
    public class Lesson
    {
        public string _discipline { get; protected set; }

        public Lesson(string d)
        {
            _discipline = d;
        }
        
        public new virtual string GetType()
        {
            return "";
        }
    }

    public class Lection : Lesson
    {
        public Lection(string d) : base (d)
        {
            _discipline = d;
        }
        public override string GetType()
        {
            return "Lection";
        }
    }

    public class Laboratory : Lesson
    {
        public Laboratory(string d) : base (d)
        {
            _discipline = d;
        }
        
        public override string GetType()
        {
            return "Laboratory";
        }
    }
}