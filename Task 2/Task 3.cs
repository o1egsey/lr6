using System;
using System.Collections.Generic;


namespace Task3
{
    interface IRoom : IComparable<IRoom>
    {
        double Area();
        double V();
        void Show();
        int W_c { get; }
    }

    class RoomComparer : IComparer<IRoom>
    {
        public int Compare(IRoom a, IRoom b)
        {
            return a.W_c.CompareTo(b.W_c);
        }
    }

    class MyRoom : IRoom
    {
        protected double width;
        protected double length;
        protected double height;
        protected int window_count;
        public MyRoom(double x, double y, double z, int w)
        {
            this.width = x; this.length = y;
            this.height = z;
            this.window_count = w;
        }

        public int W_c
        {
            get { return window_count; }
        }
        public double Area()
        {
            return (width * length);
        }
        public double V()
        {
            return (width * length * height);
        }
        public void Show()
        {
            Console.WriteLine("Ширина и длина комнаты равны {0} и {1} соответственно, высота - {2};", width, length, height);
            Console.WriteLine("Количество окон в комнате равна {0};", window_count);
            Console.WriteLine("Площадь равна {0}, обьем - {1};", Area(), V());
        }

        public int CompareTo(IRoom a)
        {
            return this.Area().CompareTo(a.Area());
        }
    }

    class ClassRoom : MyRoom, IRoom
    {
        private int seating_count;
        public ClassRoom(double x, double y, double z, int w, int s) : base(x, y, z, w)
        {
            this.seating_count = s;
        }

        public new int W_c
        {
            get { return window_count; }
        }
        public new double Area()
        {
            return (width * length);
        }
        public new double V()
        {
            return (width * length * height);
        }
        public new void Show()
        {
            Console.WriteLine("Ширина и длина комнаты равны {0} и {1} соответственно, высота - {2};", width, length, height);
            Console.WriteLine("Количество окон в комнате равна {0}, количество мест для сидения - {1};", window_count, seating_count);
            Console.WriteLine("Площадь равна {0}, обьем - {1};", Area(), V());
        }

        public new int CompareTo(IRoom a)
        {
            return this.Area().CompareTo(a.Area());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRoom[] array = new IRoom[4];

            array[0] = new MyRoom(5, 7, 2.5, 4);
            array[1] = new MyRoom(2, 4, 2.3, 1);

            array[2] = new ClassRoom(6, 10, 2.7, 4, 15);
            array[3] = new ClassRoom(5, 8, 2.6, 3, 12);

            Console.WriteLine("Информация про комнаты:");
            int index = 0;
            foreach (IRoom x in array)
            {
                index++;
                Console.WriteLine("Комната №{0}:", index);
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("*********************************");
            Console.WriteLine("Сортировка комнат по их площади:");
            Array.Sort(array);
            index = 0;
            foreach (IRoom x in array)
            {
                index++;
                Console.WriteLine("Комната №{0}:", index);
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("*********************************");
            Console.WriteLine("Сортировка комнат по количеству окон в них:");
            Array.Sort(array, new RoomComparer());
            index = 0;
            foreach (IRoom x in array)
            {
                index++;
                Console.WriteLine("Комната №{0}:", index);
                x.Show();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
