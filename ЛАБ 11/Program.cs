using ClassLibrary10lab;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ЛАБ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\u001b[1m1 задание\u001b[0m");
            Guitar guitar = new Guitar { Name = "Гитара", NumberOfStrings = 6 };
            ElectricGuitar electricGuitar = new ElectricGuitar { Name = "Электрогитара", NumberOfStrings = 6 , PowerSource = "батарейки"};
            Piano piano = new Piano { Name = "Пианино", KeyboardLayout = "октавная", NumberOfKeys = 80 };

            Queue queue = new Queue();
            
            queue.Enqueue(guitar);
            queue.Enqueue(electricGuitar);
            queue.Enqueue(piano);

            Console.WriteLine("Список элементов:");
            // Перебор элементов коллекции
            foreach (var item in queue)
            {
                Console.WriteLine(item.ToString());
                //Console.WriteLine(item);
            }
            Console.WriteLine();

            // Добавление нового объекта в коллекцию
            MusicalInstrument m = new MusicalInstrument();
            m.RandomInit();
            queue.Enqueue(m);

            Console.WriteLine("Список элементов после добавления элемента :");
            // Перебор элементов коллекции
            foreach (var item in queue)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            // Удаление объекта из коллекции
            Queue tempQueue = new Queue();
            while (queue.Count > 0)
            {
                object obj = queue.Dequeue();
                if (obj != guitar)
                {
                    tempQueue.Enqueue(obj);
                }
            }
            queue = tempQueue;

            Console.WriteLine("Список элементов после удаления Гитары:");
            // Перебор элементов коллекции
            foreach (var item in queue)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            // Запросы
            var guitarRequest = queue.OfType<Guitar>().Average(g => g.NumberOfStrings);
            var electricGuitarsRequest = queue.OfType<ElectricGuitar>().Where(eg => eg.PowerSource == "батарейки").Sum(eg => eg.NumberOfStrings);
            var pianoRequest = queue.OfType<Piano>().Where(p => p.KeyboardLayout == "октавная").Max(p => p.NumberOfKeys);

            Console.WriteLine($"\nСреднее количество струн во всех гитарах: {guitarRequest}");
            Console.WriteLine($"Количество струн во всех электрогитарах с фиксированным источником питания: {electricGuitarsRequest}");
            Console.WriteLine($"Максимальное количество клавиш на фортепиано с октавной раскладкой: {pianoRequest}");

            // Клонирование коллекции
            Queue clone = (Queue)queue.Clone();

            // Поиск элемента в коллекции (electric guitar)
            Queue queue1 = new Queue(queue);
            object elementToFind = electricGuitar;
            bool found = false;

            while (queue.Count > 0)
            {
                var currentElement = queue1.Dequeue();
                if (currentElement == elementToFind)
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine($"Элемент {elementToFind} {(found ? "найден" : "не найден")} в коллекции.");
            Console.WriteLine("**************************************************************************");

            Console.WriteLine("\u001b[1m2 задание\u001b[0m");
            // Создаем SortedSet для хранения объектов класса Student
            SortedSet<MusicalInstrument> sortedSet = new SortedSet<MusicalInstrument>();
            Console.WriteLine($"Count = {sortedSet.Count}");

            // Создаем объекты музыкальных инструментов
            Guitar guitar1 = new Guitar { Name = "Гитара", NumberOfStrings = 6 };
            ElectricGuitar electricGuitar1 = new ElectricGuitar { Name = "Электрогитара", NumberOfStrings = 7, PowerSource = "Батареи" };
            Piano piano1 = new Piano { Name = "Пианино", KeyboardLayout = "октавная", NumberOfKeys = 79 };

            // Добавляем объекты в коллекцию
            sortedSet.Add(guitar1);
            sortedSet.Add(electricGuitar1);
            sortedSet.Add(piano1);

            // Выводим содержимое коллекции на экран
            Console.WriteLine("Элементы в SortedSet:");
            foreach (MusicalInstrument instrument in sortedSet)
            {
                Console.WriteLine(instrument.ToString());
            }

            Piano p = new Piano { Name = "Пианино", KeyboardLayout = "дигитальная", NumberOfKeys = 78 };
            // Добавление другого элемента в коллекцию
            sortedSet.Add(p);

            // Выводим содержимое коллекции после процедуры добавления
            Console.WriteLine("\nЭлементы в SortedSet после добавления:");
            foreach (MusicalInstrument instrument in sortedSet)
            {
                Console.WriteLine(instrument.ToString());
            }

            //Поиск
            Console.WriteLine("Введите элемент для поиска");
            MusicalInstrument instrumentForFind = new MusicalInstrument();
            instrumentForFind.Init();
            if (sortedSet.Contains(instrumentForFind))
            {
                Console.WriteLine($"Элемент {instrumentForFind} найден в коллекции.");
            }
            else
            {
                Console.WriteLine($"Элемент {instrumentForFind} не найден в коллекции.");
            }

            // Удаление элемента
            Console.WriteLine("Введите элемент для удаления");
            MusicalInstrument instrumentForDelete = new MusicalInstrument();
            instrumentForDelete.Init();

            if (sortedSet.Contains(instrumentForDelete))
            {
                sortedSet.Remove(instrumentForDelete);
                Console.WriteLine($"Элемент {instrumentForDelete} успешно удален из коллекции.");
            }
            else
            {
                Console.WriteLine($"Элемент {instrumentForDelete} не найден в коллекции, поэтому его удаление невозможно.");
            }

            // Выводим содержимое коллекции после процедуры удаления
            Console.WriteLine("\nЭлементы в SortedSet после удаления:");
            foreach (MusicalInstrument instrument in sortedSet)
            {
                Console.WriteLine(instrument.ToString());
            }

            // Запрос 1: Среднее количество струн всех гитар
            double request1 = sortedSet.OfType<Guitar>().Average(g => g.NumberOfStrings);
            Console.WriteLine($"\nСреднее количество струн всех гитар: {request1}");

            // Запрос 2: Количество струн всех электрогитар с фиксированным источником питания
            int request2 = sortedSet.OfType<ElectricGuitar>().Where(eg => eg.PowerSource == "Батареи").Sum(eg => eg.NumberOfStrings);
            Console.WriteLine($"Количество струн всех электрогитар с фиксированным источником питания: {request2}");

            // Запрос 3: Максимальное количество клавиш на фортепиано с октавной раскладкой
            //int request3 = sortedSet.OfType<Piano>().Where(p => p.KeyboardLayout == "октавная").Max(p => p.NumberOfKeys);
            //Console.WriteLine($"Максимальное количество клавиш на фортепиано с октавной раскладкой: {request3}");

            //Выполнить клонирование коллекции
            SortedSet<MusicalInstrument> clonedSet = new SortedSet<MusicalInstrument>(sortedSet);

            // Задача 6: Выполнить сортировку коллекции (если коллекция не отсортирована) и поиск заданного элемента в коллекции
            //if (!sortedSet.IsSubsetOf(clonedSet))
            //{
            //    Console.WriteLine("\nКоллекция не отсортирована, производим сортировку...");
            //    sortedSet = new SortedSet<MusicalInstrument>(sortedSet);
            //    foreach (var item in sortedSet)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            // 3 часть
            TestCollection ts = new TestCollection();
            ts.Run(1000);

        }

    }
    
}
