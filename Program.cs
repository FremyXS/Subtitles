using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Subtitles
{
    class Data
    {
        public static List<string> Word = new List<string>( File.ReadAllText("text.txt").Split('\n'));
        public static List<List<char>> AllList = new List<List<char>>();
        public static Array consoleColors = Enum.GetValues(typeof(ConsoleColor));
        public static string Poz = "";
        public static string Color = "";
        public static string Sec1 = "";
        public static string Sec2 = "";
        public static object cvet = 0;

    }
    class Program
    {
        //3 4, 11 12
        static void Main(string[] args)
        {
            for (int i = 0; i < Data.Word.Count; i++)
            {
                Perebor(i);
            }

            for (int i = 00; ; i++) 
            {
                Tablet(i);
                Thread.Sleep(1000);
                Console.Clear();
            }

            

        }
        
        static void Tablet(int sec)
        {
            int p = 5;

            Console.SetCursorPosition(5, p);

            Panache('┌', '┐', '─');

            for (int i = 0; i < 27; i++)
            {
                p++;
                Console.SetCursorPosition(5, p);
                Panache('│', '│', ' ');
            }

            p++;
            Console.SetCursorPosition(5, p);
            Panache('└', '┘', '─');

            for (int i = 0; i < 27; i++)
            {
                if (i == 0 || i == 13 || i == 14 || i == 26)
                {
                    for (int j = 0; j < Data.AllList.Count; j++)
                    {
                        TimeVivod(j);

                        if (Data.Poz == "Top" && i == 0 && ttt(sec))
                        {
                            UpAndDown(j, Data.AllList[j].IndexOf(']') + 1, 6);
                        }
                        else if (Data.Poz == "Bottom" && i == 26 && ttt(sec))
                        {
                            UpAndDown(j, Data.AllList[j].IndexOf(']') + 1, 31);
                        }
                        else if (Data.Poz == "Right" && i == 13 && ttt(sec))
                        {
                            RightAndLeft(j, Data.AllList[j].IndexOf(']') + 1, 100 - (Data.AllList[j].Count - (Data.AllList[j].IndexOf(']') + 1)) + 5);
                        }
                        else if (Data.Poz == "Left" && i == 13 && ttt(sec))
                        {
                            RightAndLeft(j, Data.AllList[j].IndexOf(']') + 1, 6);
                        }
                        else if (Data.Poz != "Top" && Data.Poz != "Bottom" && Data.Poz != "Left" && Data.Poz != "Right" && i == 26 && ttt(sec))
                        {
                            Data.cvet = ConsoleColor.White;
                            UpAndDown(j, 14, 32);
                        }
                    }
                }

            }
           // Console.ReadKey();
        }
        static bool ttt(int sec)
        {
            int vern = 0;

            for (int i = int.Parse(Data.Sec1); i <= int.Parse(Data.Sec2); i++)
            {
                if (sec == i)
                    vern++;
            }

            if (vern > 0)
                return true;
            else
                return false;
        }
        static void Perebor(int i)
        {
            List<char> OneSroka = new List<char>();

            foreach(char n in Data.Word[i])
            {
                OneSroka.Add(n);
            }

            Data.AllList.Add(OneSroka);
            
        }
        static void UpAndDown(int i, int t, int y)
        {
            Console.SetCursorPosition((100 - (Data.AllList[i].Count-t)) / 2 + 5 , y);

            Console.ForegroundColor = (ConsoleColor)Data.cvet;

            for (int j = t; j < Data.AllList[i].Count; j++)
            {
                Console.Write(Data.AllList[i][j]);
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void RightAndLeft(int i, int t, int x)
        {
            Console.SetCursorPosition(x, 18);

            Console.ForegroundColor = (ConsoleColor)Data.cvet;

            for (int j = t; j < Data.AllList[i].Count; j++)
            {
                Console.Write(Data.AllList[i][j]);
            }

            Console.ForegroundColor = ConsoleColor.White;

        }
        
        static void TimeVivod(int i)
        {
            Data.Color = ""; Data.Poz = ""; Data.Sec1 = ""; Data.Sec2 = "";

            for (int j = Data.AllList[i].IndexOf('[') + 1; j < Data.AllList[i].IndexOf(','); j++)
            {
                Data.Poz += Data.AllList[i][j];
            }

            for (int j = Data.AllList[i].IndexOf(',') + 2; j < Data.AllList[i].IndexOf(']'); j++)
            {
                Data.Color += Data.AllList[i][j];
            }

            Data.cvet = 0;

            foreach (var p in Data.consoleColors)
            {
                if (p.ToString() == Data.Color)
                {
                    Data.cvet = p;
                }
            }

            Data.Sec1 += Data.AllList[i][3].ToString() + Data.AllList[i][4].ToString();
            Data.Sec2 += Data.AllList[i][11].ToString() + Data.AllList[i][12].ToString();

            Convert.ToInt32(Data.Sec1); Convert.ToInt32(Data.Sec2);


        }
        static void Panache(char x1, char x2, char x3)
        {
            Console.Write(x1);

            Console.Write(new string(x3, 100));

            Console.WriteLine(x2);
        }
    }
}
