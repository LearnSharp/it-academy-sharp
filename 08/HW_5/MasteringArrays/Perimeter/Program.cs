using System;
using System.Collections.Generic;

namespace Perimeter
{
    internal class Program
    {
        /// <summary>
        ///     Создать класс Point с двумя int и одним string
        ///     закрыть их в свойства с только get
        ///     создать один конструктор с инициализацией всех полей класса
        ///     создать класс Figure, с конструкторами, принимающими от трёх до пяти
        ///     объектов Point, в нём реализовать два метода:
        ///     первый - типа double с двумя параметрами типа Point для нахождения
        ///     длины стороны многоугольника
        ///     второй - void для вывода периметра многоугольника и его названия
        ///     *********************
        ///     вывести в Main() результат работы программы
        /// </summary>
        private static void Main()
        {
            var res = 0.00;

            var PointList1 = new List<Point>
                {new Point(1, 2), new Point(3, 4), new Point(5, 6)};
            var PointList2 = new List<Point>
            {
                new Point(1, 2), new Point(3, 4), new Point(5, 6),
                new Point(7, 8)
            };
            var PointList3 = new List<Point>
            {
                new Point(1, 2), new Point(3, 4), new Point(5, 6),
                new Point(7, 8), new Point(9, 10)
            };

            var PointList = new List<List<Point>>
                {PointList1, PointList2, PointList3};

            foreach (var list in PointList)
                new Figure(list).GetPerimeterView(ref res);

            Console.WriteLine();
        }

        internal class Point
        {
            public Point(int pointX, int pointY)
            {
                PointX = pointX;
                PointY = pointY;
            }

            internal int PointX { get; }
            internal int PointY { get; }
        }

        internal class Figure
        {
            public Figure(List<Point> points)
            {
                Points = points;
                FormFigure = points.Count;
            }

            private int FormFigure { get; }

            public List<Point> Points { get; set; }

            private static double Square(int x)
            {
                return x = x * x;
            }

            private static double LengthOfSide(Point point1, Point point2)
            {
                return Math.Sqrt(Square(point2.PointX - point1.PointX) +
                                 Square(point2.PointY - point2.PointY));
            }

            private static void CalculatePerimeter(
                IReadOnlyList<Point> lst, ref double res)
            {
                res = 0.00;
                for (var i = 1; i <= lst.Count; i++)
                {
                    if (i == lst.Count)
                    {
                        res += LengthOfSide(lst[i - 1], lst[0]);
                        break;
                    }

                    res += LengthOfSide(lst[i - 1], lst[i]);
                }
            }


            public void GetPerimeterView(ref double result)
            {
                if (Points.Count > 5) return;
                switch (FormFigure)
                {
                    case (int) BaseFigure.Triangle:
                        CalculatePerimeter(Points, ref result);
                        Console.WriteLine("Triangle perimeter: {0:f2}", result);
                        break;
                    case (int) BaseFigure.Quadrangle:
                        CalculatePerimeter(Points, ref result);
                        Console.WriteLine("Quadrangle perimeter: {0:f2}",
                                          result);
                        break;
                    case (int) BaseFigure.Pentagon:
                        CalculatePerimeter(Points, ref result);
                        Console.WriteLine("Pentagon perimeter: {0:f2}", result);
                        break;
                    default:
                        result = 0;
                        break;
                }
            }

            private enum BaseFigure
            {
                Triangle = 3,
                Quadrangle,
                Pentagon
            }
        }
    }
}