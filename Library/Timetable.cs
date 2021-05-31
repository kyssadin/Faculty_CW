using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic;

namespace Library
{
    public class Timetable
    {
        public readonly Day[] days = new Day[5];
        public readonly List<UniFlow> flows;
        public readonly List<Teacher> teachers;
        public readonly List<Auditorium> auditoriums;
        public readonly List<Lesson> lessons;

        public Timetable(List<UniFlow> flws, List<Teacher> tch, List<Auditorium> auds, List<Lesson> less)
        {
            for (int i = 0; i < 5; i++)
            {
                days[i] = new Day();
            }

            flows = flws;
            teachers = tch;
            auditoriums = auds;
            lessons = less;
        }

        public void AddLesson(Data data)
        {
            if (data.lssn is Lection)
            {
                int index = -1;
                for (int i = 0; i < flows.Count; i++)
                {
                    if (flows[i]._flowName == data.grp._flowName)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                    throw new Exception("Couldn't find the flow.");

                for (int i = 0; i < flows[index]._groups.Count; i++)
                {
                    days[data.DayNumber].EmLessonCells[data.LessonNumber].groups.Add(flows[index]._groups[i]);
                    days[data.DayNumber].EmLessonCells[data.LessonNumber].lessons.Add(data.lssn);
                    days[data.DayNumber].EmLessonCells[data.LessonNumber].takenAuds.Add(data.ad);
                    days[data.DayNumber].EmLessonCells[data.LessonNumber].takenTeachers.Add(data.tchr);
                }
                data.tchr.AddLesson();
            }

            if (data.lssn is Laboratory)
            {
                days[data.DayNumber].EmLessonCells[data.LessonNumber].groups.Add(data.grp);
                days[data.DayNumber].EmLessonCells[data.LessonNumber].lessons.Add(data.lssn);
                days[data.DayNumber].EmLessonCells[data.LessonNumber].takenAuds.Add(data.ad);
                days[data.DayNumber].EmLessonCells[data.LessonNumber].takenTeachers.Add(data.tchr);
                data.tchr.AddLesson();
            }
        }

        public void RemoveLesson(Group group, int day, int lesson)
        {
            int index = -1;

            for (int i = 0; i < days[day].EmLessonCells[lesson].groups.Count; i++)
            {
                if (days[day].EmLessonCells[lesson].groups[i].GetName() == group.GetName())
                {
                    index = i;
                    break;
                }
            }

            if (days[day].EmLessonCells[lesson].lessons[index] is Lection)
            {
                int flowIndex = -1;
                for (int j = 0; j < flows.Count; j++)
                {
                    if (flows[j]._flowName == group._flowName)
                    {
                        flowIndex = j;
                        break;
                    }
                }
                
                days[day].EmLessonCells[lesson].takenTeachers[index].RemoveLesson();

                string flowName = flows[flowIndex]._flowName;

                for (int k = 0; k < days[day].EmLessonCells[lesson].groups.Count; k++)
                {
                    if (days[day].EmLessonCells[lesson].groups[k]._flowName == flowName)
                    {
                        days[day].EmLessonCells[lesson].groups.RemoveAt(k);
                        days[day].EmLessonCells[lesson].takenAuds.RemoveAt(k);
                        days[day].EmLessonCells[lesson].lessons.RemoveAt(k);
                        days[day].EmLessonCells[lesson].takenTeachers.RemoveAt(k);
                        k--;
                    }
                }
                
            }

            else if (days[day].EmLessonCells[lesson].lessons[index] is Laboratory)
            {
                days[day].EmLessonCells[lesson].groups.RemoveAt(index);
                days[day].EmLessonCells[lesson].takenAuds.RemoveAt(index);
                days[day].EmLessonCells[lesson].lessons.RemoveAt(index);
                days[day].EmLessonCells[lesson].takenTeachers[index].RemoveLesson();
                days[day].EmLessonCells[lesson].takenTeachers.RemoveAt(index);
            }
        }
        
        public string ShowTable(Group g)
        {
            string ret = "";

            for (int i = 0; i < days.Length; i++)
            {
                ret += $"\n\n{i + 1} Day : \n";
                for (int j = 0; j < days[i].EmLessonCells.Length; j++)
                {
                    ret += $"\n{j + 1} lesson : ";
                    for (int k = 0; k < days[i].EmLessonCells[j].groups.Count; k++)
                    {
                        if (days[i].EmLessonCells[j].groups[k].GetName() == g.GetName())
                        {
                            ret += days[i].EmLessonCells[j].lessons[k].GetType() + " of ";
                            ret += days[i].EmLessonCells[j].lessons[k]._discipline + " by ";
                            ret += days[i].EmLessonCells[j].takenTeachers[k].GetName() + " in ";
                            ret += "Auditorium # " + Convert.ToString(days[i].EmLessonCells[j].takenAuds[k]._number);
                        }
                    }
                }
            }
            
            return ret;
        }
    }
}