using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Library;

namespace Faculty
{
    class Program
    {
        static void Main(string[] args)
        {
            UniFlow IS = new UniFlow("IS");
            IS.AddGroup();
            IS.AddGroup();
            IS._groups[0].FillGroup();
            IS._groups[1].FillGroup();

            UniFlow IP = new UniFlow("IP");
            IP.AddGroup();
            IP.AddGroup();
            IP._groups[0].FillGroup();
            IP._groups[1].FillGroup();


            List<UniFlow> uni = new List<UniFlow> {IS, IP};


            Teacher HM = new Teacher("Vladimir", "High Math");
            Teacher TA = new Teacher("Stepan", "Theory of Algorythms");

            Lesson hM = new Lesson("High Math");
            Lesson tA = new Lesson("Theory of Algorythms");

            List<Lesson> lssn = new List<Lesson> {hM, tA};

            List<Teacher> tch = new List<Teacher> {HM, TA};

            Auditorium x = new Auditorium(300);
            Auditorium y = new Auditorium(301);

            List<Auditorium> audis = new List<Auditorium> {x, y};

            Timetable tt = new Timetable(uni, tch, audis, lssn);

            InteractionClass interaction = new InteractionClass(tt);
            interaction.Start();


        }
    }
}