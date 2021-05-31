using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;

namespace Library
{
    public class InteractionClass
    {
        private Timetable tt;

        public InteractionClass(Timetable timetable)
        {
            tt = timetable;
        }

        private void EditMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option below: (1-8)");
            Console.WriteLine("1. Add lesson for a group.");
            Console.WriteLine("2. Add teacher.");
            Console.WriteLine("3. Add flow.");
            Console.WriteLine("4. Add group to a flow.");
            Console.WriteLine("5. Add lesson (as a discipline).");
            Console.WriteLine("6. Add auditorium.");
            Console.WriteLine("7. Remove lesson.");
            Console.WriteLine("\n8. Go back to menu.");
            Console.WriteLine("\n9. Exit.");
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option below: (1-6)");
            Console.WriteLine("1. Show all groups.");
            Console.WriteLine("2. Show students of a certain group.");
            Console.WriteLine("3. Show timetable for a group.");
            Console.WriteLine("4. Show all teachers.");
            Console.WriteLine("5. Show all auditoriums.");
            Console.WriteLine("\n6. Enter edit menu.");
            Console.WriteLine("\n7. Exit.");
        }

        private void GroupsInfo()
        {
            int counter1 = 1;
            int counter2 = 1;

            for (int i = 0; i < tt.flows.Count; i++)
            {
                Console.WriteLine("\n" + tt.flows[i]._flowName);
                for (int j = 0; j < tt.flows[i]._groups.Count; j++)
                {
                    Console.WriteLine($"{counter1}.{counter2++}. {tt.flows[i]._groups[j].GetName()}");
                }

                Console.WriteLine();

                counter1++;
                counter2 = 1;
            }
        }

        private void TeachersInfo()
        {
            for (int i = 0; i < tt.teachers.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. \nName : {tt.teachers[i].GetName()}\nSubject : {tt.teachers[i].discipline}");
                Console.WriteLine("Working hours : " + tt.teachers[i].workingHours);
            }
        }

        private void FlowInfo()
        {
            for (int i = 0; i < tt.flows.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tt.flows[i]._flowName}");
            }
        }

        private void AudsInfo()
        {
            for (int i = 0; i < tt.auditoriums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tt.auditoriums[i]._number}");
            }
        }

        private void LessonAddition()
        {
            bool flag = false;
            int flowN = 0;
            int grN = 0;
            while (!flag)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Choose the group from the list below:");
                    GroupsInfo();
                    Console.Write("Option (Flow) : ");
                    flowN = Convert.ToInt32(Console.ReadLine());
                    flowN--;
                    Console.Write("Option (Group) : ");
                    grN = Convert.ToInt32(Console.ReadLine());
                    grN--;
                    Console.Clear();
                    string checker = tt.flows[flowN]._groups[grN].GetName();
                    flag = true;
                }
                catch (Exception)
                {
                    flag = false;
                }
            }

            Console.WriteLine("What type of lesson would you like to add?");
            Console.WriteLine("1 - Lection\t\t2 - Laboratory");
            string lessonTypeString = Console.ReadLine();
            flag = false;
            int lessonType = 0;
            while (!flag)
            {
                try
                {
                    lessonType = Convert.ToInt32(lessonTypeString);
                    flag = true;
                }
                catch (Exception)
                {
                    Console.WriteLine(
                        "There was a problem with the lesson type.\nWhat type of lesson would you like to add? 1 or 2");
                    lessonTypeString = Console.ReadLine();
                    flag = false;
                }
            }

            while (lessonType != 1 && lessonType != 2)
            {
                Console.WriteLine("Invalid lesson type. It should be 1 or 2");
                lessonType = Convert.ToInt32(Console.ReadLine());
            }

            if (lessonType == 1)
            {
                flag = false;
                int numberOfDay = 0;
                int numberOfLesson = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Day : (1-5)");
                        numberOfDay = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Lesson : (1-5)");
                        numberOfLesson = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        while (numberOfDay < 1 || numberOfDay > 5 || numberOfLesson > 5 || numberOfLesson < 1)
                        {
                            Console.Write("Day : (1-5)");
                            numberOfDay = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Lesson : (1-5)");
                            numberOfLesson = Convert.ToInt32(Console.ReadLine());
                        }

                        numberOfDay--;
                        numberOfLesson--;
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                flag = false;
                int subjectOption = 0;
                int teacherNumber = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"Choose the teacher from the list : (1-{tt.teachers.Count})");
                        for (int i = 0; i < tt.teachers.Count; i++)
                        {
                            Console.WriteLine(
                                $"{i + 1}. Name : {tt.teachers[i].GetName()}\t Subject : {tt.teachers[i].discipline}");
                        }

                        teacherNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Choose subject : (1-{tt.lessons.Count})");
                        for (int i = 0; i < tt.lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{tt.lessons[i]._discipline}");
                        }

                        subjectOption = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        subjectOption--;
                        teacherNumber--;
                        string teachername = tt.teachers[teacherNumber].GetName();
                        string lessonname = tt.lessons[subjectOption]._discipline;
                        while (tt.teachers[teacherNumber].discipline != tt.lessons[subjectOption]._discipline)
                        {
                            Repick:
                            Console.Clear();
                            Console.WriteLine(
                                "Invalid input! Teachers discipline and the lesson must match. Try again.\n");
                            Console.WriteLine($"Choose teacher : (1-{tt.teachers.Count})");
                            for (int i = 0; i < tt.teachers.Count; i++)
                            {
                                Console.WriteLine(
                                    $"{i + 1}. Name : {tt.teachers[i].GetName()}\t Subject : {tt.teachers[i].discipline}");
                            }

                            Console.WriteLine($"Choose subject : (1-{tt.lessons.Count})");
                            for (int i = 0; i < tt.lessons.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{tt.lessons[i]._discipline}");
                            }

                            subjectOption = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"Choose the teacher from the list : (1-{tt.teachers.Count})");
                            teacherNumber = Convert.ToInt32(Console.ReadLine());
                            subjectOption--;
                            teacherNumber--;
                            try
                            {
                                teachername = tt.teachers[teacherNumber].GetName();
                                lessonname = tt.lessons[subjectOption]._discipline;
                            }
                            catch (Exception)
                            {
                                goto Repick;
                            }
                        }
                        
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                flag = false;
                int auditoriumNumber = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Choose the auditorium : ");

                        for (int i = 0; i < tt.auditoriums.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Auditorium {tt.auditoriums[i]._number}");
                        }

                        auditoriumNumber = Convert.ToInt32(Console.ReadLine());
                        while (auditoriumNumber < 0 || auditoriumNumber > tt.auditoriums.Count)
                        {
                            Console.WriteLine("Choose the auditorium : ");
                            auditoriumNumber = Convert.ToInt32(Console.ReadLine());
                        }

                        auditoriumNumber--;
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                if (tt.days[numberOfDay].EmLessonCells[numberOfLesson].takenTeachers
                    .Contains(tt.teachers[teacherNumber]) || tt.days[numberOfDay].EmLessonCells[numberOfLesson].takenAuds.Contains(tt.auditoriums[auditoriumNumber]))
                {
                    return;
                }

                try
                {
                    tt.RemoveLesson(tt.flows[flowN]._groups[grN], numberOfDay, numberOfLesson);
                }
                catch (Exception)
                {
                    // ignore
                }

                tt.AddLesson(new Data(tt.flows[flowN]._groups[grN],
                    new Lection(tt.lessons[subjectOption]._discipline),
                    tt.teachers[teacherNumber], tt.auditoriums[auditoriumNumber], numberOfDay, numberOfLesson));

            }

            if (lessonType == 2)
            {
                flag = false;
                int numberOfDay = 0;
                int numberOfLesson = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Day : (1-5)");
                        numberOfDay = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Lesson : (1-5)");
                        numberOfLesson = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        while (numberOfDay < 1 || numberOfDay > 5 || numberOfLesson > 5 || numberOfLesson < 1)
                        {
                            Console.Write("Day : (1-5)");
                            numberOfDay = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Lesson : (1-5)");
                            numberOfLesson = Convert.ToInt32(Console.ReadLine());
                        }

                        numberOfDay--;
                        numberOfLesson--;
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                flag = false;
                int subjectOption = 0;
                int teacherNumber = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"Choose the teacher from the list : (1-{tt.teachers.Count})");
                        for (int i = 0; i < tt.teachers.Count; i++)
                        {
                            Console.WriteLine(
                                $"{i + 1}. Name : {tt.teachers[i].GetName()}\t Subject : {tt.teachers[i].discipline}");
                        }

                        teacherNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Choose subject : (1-{tt.lessons.Count})");
                        for (int i = 0; i < tt.lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{tt.lessons[i]._discipline}");
                        }

                        subjectOption = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        subjectOption--;
                        teacherNumber--;
                        string teachername = tt.teachers[teacherNumber].GetName();
                        string lessonname = tt.lessons[subjectOption]._discipline;
                        while (tt.teachers[teacherNumber].discipline != tt.lessons[subjectOption]._discipline)
                        {
                            Repick:
                            Console.Clear();
                            Console.WriteLine(
                                "Invalid input! Teachers discipline and the lesson must match. Try again.\n");
                            Console.WriteLine($"Choose teacher : (1-{tt.teachers.Count})");
                            for (int i = 0; i < tt.teachers.Count; i++)
                            {
                                Console.WriteLine(
                                    $"{i + 1}. Name : {tt.teachers[i].GetName()}\t Subject : {tt.teachers[i].discipline}");
                            }

                            Console.WriteLine($"Choose subject : (1-{tt.lessons.Count})");
                            for (int i = 0; i < tt.lessons.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{tt.lessons[i]._discipline}");
                            }

                            subjectOption = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"Choose the teacher from the list : (1-{tt.teachers.Count})");
                            teacherNumber = Convert.ToInt32(Console.ReadLine());
                            subjectOption--;
                            teacherNumber--;
                            try
                            {
                                teachername = tt.teachers[teacherNumber].GetName();
                                lessonname = tt.lessons[subjectOption]._discipline;
                            }
                            catch (Exception)
                            {
                                goto Repick;
                            }
                        }
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                flag = false;
                int auditoriumNumber = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Choose the auditorium : ");

                        for (int i = 0; i < tt.auditoriums.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Auditorium {tt.auditoriums[i]._number}");
                        }

                        auditoriumNumber = Convert.ToInt32(Console.ReadLine());
                        while (auditoriumNumber < 0 || auditoriumNumber > tt.auditoriums.Count)
                        {
                            Console.WriteLine("Choose the auditorium : ");
                            auditoriumNumber = Convert.ToInt32(Console.ReadLine());
                        }

                        auditoriumNumber--;
                        flag = true;
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }
                
                if (tt.days[numberOfDay].EmLessonCells[numberOfLesson].takenTeachers
                    .Contains(tt.teachers[teacherNumber]) || tt.days[numberOfDay].EmLessonCells[numberOfLesson].takenAuds.Contains(tt.auditoriums[auditoriumNumber]))
                {
                    return;
                }

                try
                {
                    tt.RemoveLesson(tt.flows[flowN]._groups[grN], numberOfDay, numberOfLesson);
                }
                catch (Exception)
                {
                    // ignore
                }

                tt.AddLesson(new Data(tt.flows[flowN]._groups[grN],
                    new Laboratory(tt.lessons[subjectOption]._discipline),
                    tt.teachers[teacherNumber], tt.auditoriums[auditoriumNumber], numberOfDay, numberOfLesson));
            }
        }

        private void AuditoriumAddition()
        {
            tt.auditoriums.Add(new Auditorium(tt.auditoriums[^1]._number+1));
        }

        private void TeacherAddition()
        {
            Console.Clear();
            Console.WriteLine("Input teacher name : ");
            string Name = Console.ReadLine();
            Console.WriteLine($"Choose subject : (1-{tt.lessons.Count})");
            for (int i = 0; i < tt.lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{tt.lessons[i]._discipline}");
                ;                   }
            var subjectOption = Convert.ToInt32(Console.ReadLine());
            
            while ( (subjectOption < 1) || (subjectOption > tt.lessons.Count))
            {
                Console.WriteLine();
                Console.Write("Wrong input! \nOption: ");
                subjectOption = Convert.ToInt32(Console.ReadLine());
            }

            subjectOption--;

            tt.teachers.Add(new Teacher(Name, tt.lessons[subjectOption]._discipline));
        }

        private void FlowAddition()
        {
            Console.Clear();
            Console.WriteLine("Input flow name : ");
            string flowname = Console.ReadLine();
            tt.flows.Add(new UniFlow(flowname));
        }

        private void GroupAddition()
        {
            Console.Clear();
            FlowInfo();
            Console.WriteLine($"Which flow you would like to add group to? (1-{tt.flows.Count}");
            var flowOption = Convert.ToInt32(Console.ReadLine());
            
            while ( (flowOption < 1) || (flowOption > tt.flows.Count))
            {
                Console.WriteLine();
                Console.Write("Wrong input! \nOption: ");
                flowOption = Convert.ToInt32(Console.ReadLine());
            }

            flowOption--;
                    
            tt.flows[flowOption].AddGroup();
            tt.flows[flowOption]._groups[^1].FillGroup();
        }

        private void DisciplineAddition()
        {
            Console.Clear();
            Console.WriteLine("Choose a name for the discipline : ");
            string disciplineName = Console.ReadLine();
            tt.lessons.Add(new Lesson(disciplineName));
        }

        private void LessonRemoval()
        {
            Console.Clear();
            bool flag = false;
            int flowN = 0;
            int grN = 0;
            while (!flag)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Choose the group from the list below:");
                    GroupsInfo();
                    Console.Write("Option (Flow) : ");
                    flowN = Convert.ToInt32(Console.ReadLine());
                    flowN--;
                    Console.Write("Option (Group) : ");
                    grN = Convert.ToInt32(Console.ReadLine());
                    grN--;
                    Console.Clear();
                    string checker = tt.flows[flowN]._groups[grN].GetName();
                    flag = true;
                }
                catch (Exception)
                {
                    flag = false;
                }
            }
            flag = false;
            int numberOfDay = 0;
            int numberOfLesson = 0;
            while (!flag)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Day : (1-5)");
                    numberOfDay = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Lesson : (1-5)");
                    numberOfLesson = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    while (numberOfDay < 1 || numberOfDay > 5 || numberOfLesson > 5 || numberOfLesson < 1)
                    {
                        Console.Write("Day : (1-5)");
                        numberOfDay = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Lesson : (1-5)");
                        numberOfLesson = Convert.ToInt32(Console.ReadLine());
                    }

                    numberOfDay--;
                    numberOfLesson--;
                    flag = true;
                }
                catch (Exception)
                {
                    flag = false;
                }
            }

            try
            {
                tt.RemoveLesson(tt.flows[flowN]._groups[grN], numberOfDay, numberOfLesson);
            }
            catch ( Exception)
            {
                Console.WriteLine("Some data was wrong.");
            }
        }

        public void Start()
        {
            menuStart:
            
            Menu();

            Console.WriteLine();

            Console.Write("Option: ");


            bool check = false;
            int option = 0;
            while (!check)
            {
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    while ( (option < 1) || (option > 7))
                    {
                        Menu();

                        Console.WriteLine();

                        Console.Write("Wrong input! \nOption: ");

                        option = Convert.ToInt32(Console.ReadLine());
                    }
                    check = true;
                }
                catch (Exception)
                {
                    check = false;
                }
            }
            

            if (option == 1)
            {
                Console.Clear();
                GroupsInfo();
                Console.WriteLine("\nWould you like to go back to the menu?");
                Console.WriteLine("1. Yes.\n2. No");
                var opp = Convert.ToInt32(Console.ReadLine());
                while ( (opp != 1) && (opp != 2))
                {
                    Console.Write("Wrong input! \nOption: ");

                    opp = Convert.ToInt32(Console.ReadLine());
                }

                if (opp == 1)
                {
                    goto menuStart;
                }
                else
                {
                    option = 7;
                }
            }

            if (option == 2)
            {
                bool flag = false;
                int opt1 = 0;
                int opt2 = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Choose the group from the list below:");
                        GroupsInfo();
                        Console.Write("Option (Flow) : ");
                        opt1 = Convert.ToInt32(Console.ReadLine());
                        opt1--;
                        Console.Write("Option (Group) : ");
                        opt2 = Convert.ToInt32(Console.ReadLine());
                        opt2--;
                        Console.Clear();
                        Console.WriteLine($"Students of {tt.flows[opt1]._groups[opt2].GetName()} :");
                        for (int i = 0; i < tt.flows[opt1]._groups[opt2]._students.Count; i++)
                        {
                            Console.WriteLine(tt.flows[opt1]._groups[opt2]._students[i].GetName());
                        }
                        flag = true;
                        
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }
                
                Console.WriteLine("\nWould you like to go back to the menu?");
                Console.WriteLine("1. Yes.\n2. No");
                var opp = Convert.ToInt32(Console.ReadLine());
                while ( (opp != 1) && (opp != 2))
                {
                    Console.Write("Wrong input! \nOption: ");

                    opp = Convert.ToInt32(Console.ReadLine());
                }

                if (opp == 1)
                {
                    goto menuStart;
                }
                else
                {
                    option = 7;
                }
            }

            if (option == 3)
            {
                bool flag = false;
                int opt1 = 0;
                int opt2 = 0;
                while (!flag)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Choose the group from the list below:");
                        GroupsInfo();
                        Console.Write("Option (Flow) : ");
                        opt1 = Convert.ToInt32(Console.ReadLine());
                        opt1--;
                        Console.Write("Option (Group) : ");
                        opt2 = Convert.ToInt32(Console.ReadLine());
                        opt2--;
                        Console.Clear();
                        Console.Clear();
                Console.WriteLine($"Timetable of {tt.flows[opt1]._groups[opt2].GetName()} group :");
                Console.WriteLine($"{tt.ShowTable(tt.flows[opt1]._groups[opt2])}");
                        flag = true;
                        
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }

                Console.WriteLine("\nWould you like to go back to the menu?");
                Console.WriteLine("1. Yes.\n2. No");
                var opp = Convert.ToInt32(Console.ReadLine());
                while ( (opp != 1) && (opp != 2))
                {
                    Console.Write("Wrong input! \nOption: ");

                    opp = Convert.ToInt32(Console.ReadLine());
                }

                if (opp == 1)
                {
                    goto menuStart;
                }
                else
                {
                    option = 7;
                }

            }

            if (option == 4)
            {
                Console.Clear();
                TeachersInfo();
                Console.WriteLine("\nWould you like to go back to the menu?");
                Console.WriteLine("1. Yes.\n2. No");
                var opp = Convert.ToInt32(Console.ReadLine());
                while ( (opp != 1) && (opp != 2))
                {
                    Console.Write("Wrong input! \nOption: ");

                    opp = Convert.ToInt32(Console.ReadLine());
                }

                if (opp == 1)
                {
                    goto menuStart;
                }
                else
                {
                    option = 7;
                }
            }
            
            if (option == 5)
            {
                Console.Clear();
                AudsInfo();
                Console.WriteLine("\nWould you like to go back to the menu?");
                Console.WriteLine("1. Yes.\n2. No");
                var opp = Convert.ToInt32(Console.ReadLine());
                while ( (opp != 1) && (opp != 2))
                {
                    Console.Write("Wrong input! \nOption: ");

                    opp = Convert.ToInt32(Console.ReadLine());
                }

                if (opp == 1)
                {
                    goto menuStart;
                }
                else
                {
                    option = 7;
                }
            }
            
            if (option == 6)
            {
                EditMenu();
                
                Console.WriteLine();

                Console.Write("Option: ");

                var editOption = Convert.ToInt32(Console.ReadLine());
            
                while ( (editOption < 1) || (editOption > 9))
                {
                    Menu();

                    Console.WriteLine();

                    Console.Write("Wrong input! \nOption: ");

                    editOption = Convert.ToInt32(Console.ReadLine());
                }

                if (editOption == 1)
                {
                    LessonAddition();
                }

                if (editOption == 2)
                {
                    TeacherAddition();
                }

                if (editOption == 3)
                {
                    FlowAddition();
                }

                if (editOption == 4)
                {
                   GroupAddition();
                }

                if (editOption == 5)
                {
                    DisciplineAddition();
                }

                if (editOption == 6)
                {
                    AuditoriumAddition();
                }

                if ( editOption == 7 )
                {
                    LessonRemoval();
                }

                if (editOption == 9)
                {
                    goto Exit;
                }

                goto menuStart;
            }

            

            Exit:
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("Goodbye!");
            Console.WriteLine("\n\n");
        }
    }
}