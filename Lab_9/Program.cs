using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DialClock clock1 = new DialClock();
            Console.WriteLine(clock1.Info());

            DialClock clock2 = new DialClock(10, 28);
            Console.WriteLine(clock2.Info());

            DialClock clock4 = new DialClock(11, 28);
            Console.WriteLine(clock2.Info());

            DialClock clock3 = new DialClock(clock2);
            Console.WriteLine(clock3.Info());

            Console.WriteLine($"Угол между часовой и минутной стрелкой 1: {clock1.GetAngle()}");
            Console.WriteLine($"Угол между часовой и минутной стрелкой 2: {clock2.GetAngle()}");
            Console.WriteLine($"Угол между часовой и минутной стрелкой 3: {clock3.GetAngle()}");

            Console.WriteLine($"Количество созданных объектов: {DialClock.CountObjects}");

            Console.WriteLine($"Новое время: {++ clock2}");
            Console.WriteLine($"Новое время: {-- clock2}");
            Console.WriteLine($"Новое время: {40 + clock2}");
            Console.WriteLine($"Новое время: {clock2 + 40}");
            Console.WriteLine($"Новое время: {clock2 - 40}");
            Console.WriteLine($"Новое время: {180 - clock2}");


            DialClockArray dialClockArray1 = new DialClockArray(1);
            Console.WriteLine("Пустой массив:");
            dialClockArray1.PrintElements();

            var random = new Random();
            DialClockArray dialClockArray2 = new DialClockArray(5, random);
            Console.WriteLine("Массив, заполненный случайными элементами:");
            dialClockArray2.PrintElements();

            DialClockCollection originalCollection = new DialClockCollection();
            originalCollection.Clocks.Add(dialClockArray2[2]);
            DialClockCollection copiedCollection = new DialClockCollection(originalCollection);

            Console.WriteLine("Скопированная коллекция:");
            DialClockCollection.PrintCollection(copiedCollection);

            dialClockArray2[2] = new DialClock(100, 200);
            Console.WriteLine("Массив после записи в существующий индекс:");
            dialClockArray2.PrintElements();
            Console.WriteLine($"Значение элемента с индексом 2: {dialClockArray2[2]}");
            
            try
            {
                dialClockArray2[2] = new DialClock(10, 30);
                Console.WriteLine($"Запись объекта с существующим индексом: {dialClockArray2[2]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
            try
            {
                Console.WriteLine($"Значение элемента с индексом 10: {dialClockArray2[10]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }

            DialClock maxClock = DialClockArray.FindMaxAngle(dialClockArray2);
            Console.WriteLine($"Объект с максимальным углом между стрелками: {maxClock}");

            Console.WriteLine($"Создано объектов: {DialClockArray.GetDialClockCount()}");
            Console.WriteLine($"Создано коллекций: {DialClockArray.GetDialClockArrayCount()}");
        }



    }
}
