using System;
using System.Collections.Generic;

namespace Library
{
    public class UniFlow
    {
        public readonly List<Group> _groups = new List<Group>();
        public string _flowName { get; private set; } 

        public UniFlow(string flowName)
        {
            _flowName = flowName;
        }

        public void AddGroup()
        {
            Group g = new Group(_flowName, _groups.Count + 1);
            _groups.Add(g);
        }
    }
}