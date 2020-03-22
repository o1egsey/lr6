using System;

namespace Task1
{
    //визначення інтерфейсу
    interface IDemo
    {
        void Show(); //оголошення методу
        double Dlina(); //оголошення методу
        int X { get; } //оголошення властивості X
        int Y { get; } //оголошення властивості Y
        int this[int i] { get; set; } //оголошення індексатора (читання-запис)
    }
    class DemoPoint : IDemo
    {
        protected int x;
        protected int y;
        public DemoPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public void Show() //реалізація методу, оголошеного в інтерфейсі
        {
            Console.WriteLine("Точка на плоскосте: ({0}, {1});", x, y);
        }
        public double Dlina() //реалізація методу, оголошеного в інтерфейсі
        {
            return Math.Sqrt(x * x + y * y);
        }
        public int X //реалізація властивості, оголошеної в інтерфейсі
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public int this[int i] //реалізація індексатора, оголошеного в інтерфейсі
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else throw new Exception("Недопустимое значение индекса.");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else throw new Exception("Недопустимое значение индекса.");
            }
        }
    }
    class DemoShape : DemoPoint, IDemo
    {
        protected int z;
        public DemoShape(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }
        // реалізація методу, оголошеного в інтерфейсі, з приховуванням однойменного методу з базового класу
        public new void Show()
        {
            Console.WriteLine("Точка в пространстве: ({0}, {1}, {2});", x, y, z);
        }
        // реалізація методу, оголошеного в інтерфейсі, з приховуванням однойменного методу з базового класу
        public new double Dlina()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        // реалізація індексатора, оголошеного в інтерфейсі, з приховуванням однойменного індексатора з базового класу
        public new int Y
        {
            get { return y; }
        }
        public new int this[int i]
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else if (i == 2) return z;
                else throw new Exception("неприпустиме значення індексу");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else if (i == 2) z = value;
                else throw new Exception("неприпустиме значення індексу");
            }
        }
    }
    interface IMeasurable
    {
        double Perimeter();
        double Area();
        void Show();
    }
    class Square : IMeasurable
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }
        public void Show()
        {
            Console.WriteLine("Квадрат со стороной {0} (side);", side);
        }
        public double Perimeter()
        {
            return (4 * side);
        }
        public double Area()
        {
            return (side * side);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Task1 (Part 1)-----------------");
            //створення масиву інтерфейсних посилань
            IDemo[] a = new IDemo[4];
            //заповнення масиву
            a[0] = new DemoPoint(0, 1);
            a[1] = new DemoPoint(-3, 0);
            a[2] = new DemoShape(3, 4, 0);
            a[3] = new DemoShape(0, 5, 6);
            // перегляд масиву
            foreach (IDemo x in a)
            {
                x.Show();
                Console.WriteLine("Длинна = {0:f2};", x.Dlina());
                Console.WriteLine("x = {0}, y = {1};", x.X, x.Y);
                x[1] += x[0];

                Console.Write("Новые координаты - ");
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("-----------------Task1 (Part 2)-----------------");
            //створення масиву інтерфейсних посилань
            IMeasurable[] b = new IMeasurable[4];
            //заповнення масиву
            b[0] = new Square(1);
            b[1] = new Square(2);
            b[2] = new Square(3);
            b[3] = new Square(4);
            // перегляд масиву
            foreach (IMeasurable y in b)
            {
                y.Show();
                Console.WriteLine("Периметр квадрата равен {0}, а площадь равна {1};", y.Perimeter(), y.Area());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
