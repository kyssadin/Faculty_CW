using System;

namespace Library
{
    public class Student
    {
        private string _name;
        public string _flowName { get; private set; }
        public int _groupNumber { get; private set; }

        public Student(string name, string flowName, int groupNumber)
        {
            _name = name;
            _flowName = flowName;
            _groupNumber = groupNumber;
        }

        public string GetName()
        {
            return _name;
        }
    }
}