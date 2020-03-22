using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface IMeasurable
    {
        double Perimeter();
        double Area();
        void Show();
    }

    class Square : IMeasurable, IComparable<Square>
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
        public int CompareTo(Square a)
        {
            return this.Perimeter().CompareTo(a.Perimeter());
        }
    }

    class Task2
    {
        static void Main(string[] args)
        {
            Square[] b = new Square[4];
            b[0] = new Square(7);
            b[1] = new Square(3);
            b[2] = new Square(8);
            b[3] = new Square(2);
            foreach (Square x in b)
            {
                x.Show();
                Console.WriteLine("Периметр квадрата равен {0}, а площадь равна {1};", x.Perimeter(), x.Area());
                Console.WriteLine();
            }
            Console.WriteLine("***********************************************");
            Console.WriteLine("Сортировка за значением периметра квадрата:");
            Array.Sort(b);
            foreach (Square x in b)
            {
                x.Show();
                Console.WriteLine("Периметр квадрата равен {0}, а площадь равна {1};", x.Perimeter(), x.Area());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
