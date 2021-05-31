using System;
using System.Collections.Generic;

namespace Library
{
    public class Day
    {
        public LessonCell[] EmLessonCells = new LessonCell[5];

        public Day()
        {
            for (int i = 0; i < 5; i++)
            {
                EmLessonCells[i] = new LessonCell();
            }
        }
    }
}