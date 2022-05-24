using System;
using System.Collections.Generic;
using System.Linq;

namespace Z_2
{
    class Note
    {
        public long ThePhoneNumber;
        public string TheSurname;
        public DateTime TheBirthday;
        public Note()
        {
        }
        public Note(long aPhoneNumber, string aSurname, DateTime aBirthday)
        {
            ThePhoneNumber = aPhoneNumber;
            TheSurname = aSurname;
            TheBirthday = aBirthday;
        }
        public static void Display(Note[] MyNote)
        {
            if (MyNote.Length != 0)
                for (int i = 0; i < MyNote.Length; i++)
                    Console.WriteLine("{3}: Фамилия: {0}, Дата рождения: {1}, Номер телефона: {2}", MyNote[i].TheSurname, MyNote[i].TheBirthday.Date, MyNote[i].ThePhoneNumber, i + 1);
            else
                Console.WriteLine("Записная книга пуста");
        }
        public static void SurNameSort(Note[] MyNote)
        {
            Array.Sort(MyNote, CompareTo);
        }        
        static int CompareTo(Note x, Note y)
        {
            int i = 0;
            while (i < x.TheSurname.Length && i < y.TheSurname.Length)
            {
                if (x.TheSurname[i] < y.TheSurname[i]) return -1;
                if (x.TheSurname[i] > y.TheSurname[i]) return +1;
                i++;
            }
            if (x.TheSurname.Length < y.TheSurname.Length) return -1;
            if (x.TheSurname.Length > y.TheSurname.Length) return +1;
            return 0;
        }
        public static void SearchNote(Note[] MyNote, string search)
        {
            int number = 0;
            bool flag = int.TryParse(search, out number);
            for (int i = 0; i < MyNote.Length; i++)
            {
                if (flag)
                    if (MyNote[i].ThePhoneNumber == int.Parse(search))
                    {
                        Console.WriteLine("Фамилия:{0}, Дата рождения: {1}, Номер телефона: {2}", MyNote[i].TheSurname, MyNote[i].TheBirthday, MyNote[i].ThePhoneNumber);
                        number++;
                    }
                if (!flag)
                    if (MyNote[i].TheSurname == search)
                    {
                        Console.WriteLine("Фамилия:{0}, Дата рождения: {1}, Номер телефона: {2}", MyNote[i].TheSurname, MyNote[i].TheBirthday, MyNote[i].ThePhoneNumber);
                        number++;
                    }
            }
            if (number == 0)
                Console.WriteLine("Нет записей с искомыми параметрами");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            Note[] TheMyNote = new Note[0];
            DateTime DT = new DateTime();
            int Year, Mounth, Day;
            while (true)
            {
                Console.WriteLine("__________________________");
                Console.WriteLine("0.Заполнить автоматически");
                Console.WriteLine("1.Добавить Новую запись");
                Console.WriteLine("2.Отобразить записную книжку");
                Console.WriteLine("3.Отсортироовать по фамилии");
                Console.WriteLine("4.Поиск");          
                long.TryParse(Console.ReadLine(), out n);
                switch (n)
                {
                    case 1:
                        Note[] temp = new Note[TheMyNote.Length + 1];
                        temp[temp.Length - 1] = new Note();
                        for (int i = 0; i < TheMyNote.Length; i++)
                            temp[i] = TheMyNote[i];
                        Console.WriteLine("Введите номер телефона");
                        long.TryParse(Console.ReadLine(), out temp[temp.Length - 1].ThePhoneNumber);
                        Console.WriteLine("Введите фамилию");
                        temp[temp.Length - 1].TheSurname = Console.ReadLine();
                        Console.WriteLine("Введите год рождения");
                        Year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц рождения");
                        Mounth = int.Parse(Console.ReadLine());
                        Console.WriteLine("День");
                        Day = int.Parse(Console.ReadLine());
                        DT = new DateTime(Year, Mounth, Day);
                        temp[temp.Length - 1].TheBirthday = DT;
                        TheMyNote = temp;
                        break;
                    case 2:
                        Note.Display(TheMyNote);
                        break;
                    case 0:
                        Note[] temp1 = new Note[5];
                        temp1[0] = new Note(375299435628, "Петров", new DateTime(2002, 1, 1));
                        temp1[1] = new Note(375299535838, "Иванов", new DateTime(1998, 4, 1));
                        temp1[2] = new Note(375259474671, "Смирнов", new DateTime(1994, 3, 1));
                        temp1[3] = new Note(375290465223, "Васильев", new DateTime(2000, 9, 1));
                        temp1[4] = new Note(375259965653, "Анисимов", new DateTime(1995, 12, 1));
                        TheMyNote = temp1;
                        break;
                    case 3:
                        Note.SurNameSort(TheMyNote);
                        Note.Display(TheMyNote);
                        break;
                    case 4:
                        Console.WriteLine("Введите фимилию , или номер телефона");
                        Note.SearchNote(TheMyNote, Console.ReadLine());
                        break;
                }
            }
        }
    }
}
