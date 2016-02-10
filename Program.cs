using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filestream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(FS);

            string[] numbers = sr.ReadLine().Split();

            int min = Convert.ToInt32(numbers[0]);
            int max = Convert.ToInt32(numbers[0]);

            foreach (string numb in numbers)
            {
                if (Convert.ToInt32(numb) < min)
                    min = Convert.ToInt32(numb);
                if (Convert.ToInt32(numb) > max)
                    max = Convert.ToInt32(numb);
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
