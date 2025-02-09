using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class DialClockArray
    {
        //Поля
        private static int dialClockCount = 0;
        private static int dialClockArrayCount = 0;

        public readonly DialClock[] array;

        //Конструктор без параметров
        public DialClockArray(int size)
        {
            array = new DialClock[size];
            dialClockArrayCount++;
        }

        //Конструктор для создания массива из рандомных элементов
        public DialClockArray(int size, Random random)
        {
            array = new DialClock[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = new DialClock(random.Next(0, 361), random.Next(0, 361));
                dialClockCount++;
            }
            dialClockArrayCount++;
        }

        //Конструктор копирования

        public DialClockArray(DialClock[] data) 
        {
            array = new DialClock[data.Length];
            Array.Copy(data, array, data.Length);
        }


        //Индексатор для доступа к элементам
        public DialClock this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else
                    throw new IndexOutOfRangeException("Индекс вышел за границы массива");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new IndexOutOfRangeException("Индекс вышел за границы массива");
            }
        }

        //Печать элементов
        public void PrintElements()
        {
            foreach (var clock in array)
            {
                Console.WriteLine(clock);
            }
        }

        //Статическое поле для подсчета количества созданных элементов
        public static int GetDialClockCount() => dialClockCount;
        public static int GetDialClockArrayCount() => dialClockArrayCount;

        //Метод для поиска максимального элемента массива
        public static DialClock FindMaxAngle(DialClockArray array)
        {
            if (array == null || array.array.Length == 0)
                return null;

            DialClock maxClock = array[0];
            for (int i = 1; i < array.array.Length; i++)
            {
                if (array[i] > maxClock)
                {
                    maxClock = array[i];
                }
            }
            return maxClock;
        }

    }

    //Коллекция
    public class DialClockCollection
    {
        public List<DialClock> Clocks { get; private set; }

        public DialClockCollection()
        {
            Clocks = new List<DialClock>();
        }

        // Конструктор копирования с глубоким копированием
        public DialClockCollection(DialClockCollection other)
        {
            Clocks = new List<DialClock>();
            if (other != null && other.Clocks != null)
            {
                foreach (var clock in other.Clocks)
                {
                    Clocks.Add(new DialClock(clock));
                }
            }
        }
        //Печать коллекции
        public static void PrintCollection(DialClockCollection collection)
        {
            if (collection != null && collection.Clocks != null)
            {
                foreach (var clock in collection.Clocks)
                {
                    Console.WriteLine(clock);
                }
            }
            else
            {
                Console.WriteLine("Коллекция пуста или не задана");
            }
        }
    }
}
