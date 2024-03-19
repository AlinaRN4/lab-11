using ClassLibrary10lab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБ_11
{
    internal class TestCollection
    {
        Queue<Guitar> col1 = new Queue<Guitar>();
        Queue<string> col2 = new Queue<string>();
        SortedSet<Guitar> col3 = new SortedSet<Guitar>();
        SortedSet<string> col4 = new SortedSet<string>();
        Guitar? first, midle, last;

        public void CreateCollection(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Guitar guitar = new Guitar();
                guitar.RandomInit();
                //MusicalInstrument m = guitar.GetBase(guitar);
                //m.Name += i.ToString();
                col1.Enqueue(guitar);
                col2.Enqueue(guitar.ToString());
                col3.Add(guitar);
                col4.Add(guitar.ToString() + i.ToString());
                if (i == 0)
                {
                    first = (Guitar)guitar.Clone();
                }
                if (i == size - 1)
                {
                    last =(Guitar)guitar.Clone();
                }
                if (i == (size / 2))
                {
                    midle = (Guitar)guitar.Clone();
                }
            }
        }
        public void FindElement(Guitar guitar, string msg)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine($"{msg} элемент: "); //ищем элемент в 1 коллекции
            stopwatch.Start();
            bool ok = col1.Contains(guitar);
            stopwatch.Stop();
            if (ok) { Console.WriteLine($"В колекции Queue<Guitar> элемент найден за {stopwatch.ElapsedTicks} "); }
            else { Console.WriteLine($"В колекции Queue<Guitar> элемент НЕ найден "); }

            //ищем элемент во второй коллекции
            stopwatch.Restart();
            ok = col2.Contains(guitar.ToString());
            stopwatch.Stop();
            if (ok) { Console.WriteLine($"В колекции Queue<string> элемент найден за {stopwatch.ElapsedTicks} "); }
            else { Console.WriteLine($"В колекции Queue<string> элемент НЕ найден "); }

            //ищем элемент в третьей коллекции
            stopwatch.Restart();
            ok = col3.Contains(guitar.GetBase(guitar));
            stopwatch.Stop();
            if (ok) { Console.WriteLine($"В колекции SortedSet<Guitar> элемент найден за {stopwatch.ElapsedTicks} "); }
            else { Console.WriteLine($"В колекции SortedSet<Guitar> элемент НЕ найден "); }

            //ищем элемент в 4 коллекции
            stopwatch.Restart();
            ok = col4.Contains(guitar.GetBase(guitar).ToString());
            stopwatch.Stop();
            if (ok) { Console.WriteLine($"В колекции SortedSet<string> элемент найден за {stopwatch.ElapsedTicks} "); }
            else { Console.WriteLine($"В колекции SortedSet<string> элемент НЕ найден "); }
        }
        public void Print1st()
        {
            foreach (Guitar s in col1)
            {
                Console.WriteLine(s);
            }
        }
        public void Run(int size)
        {
            CreateCollection(size);
            Console.WriteLine("Первый элемент");
            FindElement(first, first.ToString());
            Console.WriteLine("Средний элемент");
            FindElement(midle, midle.ToString());
            Console.WriteLine("Последний  элемент");
            FindElement(last, last.ToString());
        }
        public class GuitarComparer : IComparer<Guitar>
        {
            public int Compare(Guitar x, Guitar y)
            {
                // Сравниваем объекты Guitar по их содержимому
                // Например, можно сравнивать по названию, цене или другим свойствам
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
