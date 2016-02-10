using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFarManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            DirectoryInfo directory = new DirectoryInfo(@"C:\");

            List<FileSystemInfo> Items = new List<FileSystemInfo>();
            Items.AddRange(directory.GetFiles());
            Items.AddRange(directory.GetDirectories());
            Stack<string> stc = new Stack<string>();
            stc.Push(directory.FullName);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            while (true)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[index].GetType() == typeof(FileInfo))
                    {
                        if (index == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                    }
                    else
                    {
                        if (index == i)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine(Items[i].Name);
                }
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.Enter)
                {
                    if (Items[index].GetType() == typeof(FileInfo))
                    {
                        FileRead(Items[index].FullName);
                    }
                    else
                    {
                        stc.Push(Items[index].FullName);
                        directory = new DirectoryInfo(Items[index].FullName);
                        Items.Clear();
                        Items.AddRange(directory.GetDirectories());
                        Items.AddRange(directory.GetFiles());
                        index = 0;
                    }
                    //FileRead();
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0)
                        index--;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    if (index < Items.Count - 1)
                        index++;
                }
                if (button.Key == ConsoleKey.Escape)
                {
                    directory = new DirectoryInfo(stc.Peek());
                    stc.Pop();
                    Items.Clear();
                    Items.AddRange(directory.GetDirectories());
                    Items.AddRange(directory.GetFiles());
                    index = 0;
                }
                //CurrentDirectory = Items[index].Name;
                Console.Clear();
            }


        }
        public static void FileRead(string Fullname)
        {
            Console.Clear();
            try
            {
                using (FileStream fs = File.Open(Fullname, FileMode.OpenOrCreate))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(temp.GetString(b));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to open");
            }

            while (true)
            {

                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.Escape)
                    break;
                else
                    continue;
            }
        }
    }

}