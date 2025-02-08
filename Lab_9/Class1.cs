using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class DialClock
    {
        //Поля
        private int hours;
        private int minutes;

        static int countObjects = 0;

        //Свойство часов
        public int Hours
        {
            get { return hours; }
            set { hours = value % 12; }
        }

        //Свойство минут
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value % 60; }
        }

        //Свойство углов часовой и минутной стрелки
        public double HourAngle { get; set; }
        public double MinuteAngle { get; set; }

        public DialClock(double hourAngle, double minuteAngle)
        {
            HourAngle = hourAngle;
            MinuteAngle = minuteAngle;
        }

        //Перегрузка оператора >
        public static bool operator >(DialClock a, DialClock b)
        {
            return Math.Abs(a.HourAngle - a.MinuteAngle) > Math.Abs(b.HourAngle - b.MinuteAngle);
        }

        //Перегрузка оператора <
        public static bool operator <(DialClock a, DialClock b)
        {
            return Math.Abs(a.HourAngle - a.MinuteAngle) < Math.Abs(b.HourAngle - b.MinuteAngle);
        }


        //Конструктор без параметров
        public DialClock()
        {
            hours = 0;
            minutes = 0;
            countObjects++;
        }

        //Конструктор с параметрами
        public DialClock(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            countObjects++;
        }

        //Конструктор копирования
        public DialClock(DialClock p)
        {
            this.hours = p.Hours;
            this.minutes = p.Minutes;
            countObjects++;
        }

        //Информация об объекте
        public void Info()
        {
            Console.WriteLine($"Часы: {hours}, Минуты: {minutes}");
        }

        //Статический метод вычисления угла между часовой и минутной стрелками
        public static double CalculateAngle(int hours, int minutes)
        {
            double angle = Math.Abs(30 * hours + minutes / 2 - 6 * minutes);
            return angle;
        }

        //Метод класса
        public double GetAngle()
        {
            return CalculateAngle(hours, minutes);
        }


        //Статическое поле для подсчета количества созданных элементов
        public static int CountObjects => countObjects;

        //Унарная операция с добавлением минуты
        public static DialClock operator ++(DialClock clock)
        {
            int newHours = clock.Hours;
            int newMinutes = clock.Minutes + 1;

            if (newHours >= 24)
            {
                newHours -= 24;
            }

            if (newMinutes >= 60)
            {
                newMinutes -= 60;
            }

            return new DialClock(newHours, newMinutes);
        }

        //Унарная операция с вычитанием минуты
        public static DialClock operator --(DialClock clock)
        {
            int newHours = clock.Hours;
            int newMinutes = clock.Minutes - 1;

            if (newHours < 0)
            {
                newHours += 24;
            }

            if(newMinutes < 0)
            {
                newMinutes += 60;
            }

            return new DialClock(newHours, newMinutes);
        }

        //Явное приведение к bool
        public static explicit operator bool (DialClock clock)
        {
            double angle = Math.Abs(30 * clock.hours + clock.minutes / 2 - 6 * clock.minutes);
            return angle % 2.5 == 0;
        }

        //Неявное приведение к int
        public static explicit operator int (DialClock clock)
        {
            return clock.Hours * 60 + clock.Minutes;
        }

        //Перегрузка оператора +
        public static DialClock operator +(DialClock dc, int minutesAdd)
        {
            int totalMinutes = dc.minutes + minutesAdd;
            int newMinutes = totalMinutes % 60;
            int newHours = dc.hours + totalMinutes / 60;
            return new DialClock(newHours % 24, newMinutes);
        }

        //Перегрузка оператора + правосторонняя
        public static DialClock operator +(int minutesAdd,  DialClock dc)
        {
            return dc + minutesAdd;
        }

        //Перегрузка оператора - 
        public static DialClock operator -(DialClock dc, int minutesSub)
        {
            int totalMinutes = dc.minutes - minutesSub;
            int newMinutes = (totalMinutes + 60) % 60;
            int newHours = dc.hours + ((totalMinutes + 60) / 60 - 1);
            return new DialClock(newHours % 24, Math.Abs(newMinutes));
        }

        //Перегрузка оператора - правосторонняя
        public static DialClock operator -(int minutesSub, DialClock dc)
        {
            int totalMinutes = dc.minutes - minutesSub;
            int newMinutes = (totalMinutes + 1440) % 60;
            int newHours = (dc.hours * 60 + totalMinutes) / 60;
            return new DialClock(newHours % 24, newMinutes);
        }


        //Перевод в строку для вывода
        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        
    }
    //Класс массивов
    internal class DialClockArray
    {
        //
        private static int dialClockCount = 0;
        private static int dialClockArrayCount = 0;

        public readonly DialClock[] array;

        //
        public DialClockArray(int size)
        {
            array = new DialClock[size];
            dialClockArrayCount++;
        }

        //
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

        //
        public DialClockArray(DialClockArray other)
        {
            array = new DialClock[other.array.Length];
            for (int i = 0; i < other.array.Length; i++)
            {
                array[i] = new DialClock(other.array[i].HourAngle, other.array[i].MinuteAngle);
                dialClockCount++;   
            }
            dialClockArrayCount++;
        }


        //
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

        //
        public static int GetDialClockCount() => dialClockCount;
        public static int GetDialClockArrayCount() => dialClockArrayCount;

        //
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

