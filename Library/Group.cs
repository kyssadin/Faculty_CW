using System;
using System.Collections.Generic;

namespace Library
{
    public class Group
    {
        public List<Student> _students = new List<Student>();
        public string _flowName { get; private set; }
        private int _groupNumber { get; set; }

        public Group(string flowName, int groupNumber)
        {
            _flowName = flowName;
            _groupNumber = groupNumber;
        }

        public void FillGroup()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(20, 30); i++)
            {
                _students.Add(new Student($"{_flowName}-{_groupNumber}_Student_{i+1}", _flowName, _groupNumber));
            }
        }

        public string GetName()
        {
            return _flowName + "-" + _groupNumber;
        }
    }
}