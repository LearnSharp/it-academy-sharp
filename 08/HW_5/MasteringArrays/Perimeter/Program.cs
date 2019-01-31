using System;

namespace Perimeter
{
    internal class Program
    {
        /// <summary>
        ///Создать класс Point с двумя int и одним string
        ///закрыть их в свойства с только get
        ///создать один конструктор с инициализацией всех полей класса
        ///
        ///создать класс Figure, с конструкторами, принимающими от трёх до пяти
        /// объектов Point, в нём реализовать два метода:
        ///     первый - типа double с двумя параметрами типа Point для нахождения
        ///              длины стороны многоугольника
        ///     второй - void для вывода периметра многоугольника и его названия
        ///*********************
        ///вывести в Main() результат работы программы
        /// </summary>
        private static void Main()
        {
            var res = 0.00;

            var figure1 =
                new Figure(new Point(1, 2), new Point(3, 4), new Point(5, 6));
            figure1.GetPerimeterView(ref res);

            var figure2 =
                new Figure(new Point(1, 2), new Point(3, 4), new Point(5, 6),
                           new Point(7, 8));
            figure2.GetPerimeterView(ref res);

            var figure3 =
                new Figure(new Point(1, 2), new Point(3, 4), new Point(5, 6),
                           new Point(7, 8), new Point(9, 10));
            figure3.GetPerimeterView(ref res);

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
            public Figure(Point pointA, Point pointB, Point pointC)
            {
                PointA = pointA;
                PointB = pointB;
                PointC = pointC;
                FormFigure = (int) BaseFigure.Triangle;
            }

            public Figure(Point pointA, Point pointB, Point pointC,
                          Point pointD)
            {
                PointA = pointA;
                PointB = pointB;
                PointC = pointC;
                PointD = pointD;
                FormFigure = (int) BaseFigure.Quadrangle;
            }

            public Figure(Point pointA, Point pointB, Point pointC,
                          Point pointD, Point pointE)
            {
                PointA = pointA;
                PointB = pointB;
                PointC = pointC;
                PointD = pointD;
                PointE = pointE;
                FormFigure = (int) BaseFigure.Pentagon;
            }


            private int FormFigure { get; }

            private Point PointA { get; }
            private Point PointB { get; }
            private Point PointC { get; }
            private Point PointD { get; }
            private Point PointE { get; }

            private static int Square(int x)
            {
                return x = x * x;
            }

            public double LengthOfSide(Point point1, Point point2)
            {
                return Math.Sqrt(Square(point2.PointX - point1.PointX) +
                                 Square(point2.PointY - point2.PointY));
            }

            public void GetPerimeterView(ref double result)
            {
                switch (FormFigure)
                {
                    case (int) BaseFigure.Triangle:
                        result = LengthOfSide(PointA, PointB) +
                                 LengthOfSide(PointB, PointC) +
                                 LengthOfSide(PointC, PointA);
                        Console.WriteLine("Triangle perimeter: {0:f2}", result);
                        break;
                    case (int) BaseFigure.Quadrangle:
                        result = LengthOfSide(PointA, PointB) +
                                 LengthOfSide(PointB, PointC) +
                                 LengthOfSide(PointC, PointD) +
                                 LengthOfSide(PointD, PointA);
                        Console.WriteLine("Quadrangle perimeter: {0:f2}",
                                          result);
                        break;
                    case (int) BaseFigure.Pentagon:
                        result = LengthOfSide(PointA, PointB) +
                                 LengthOfSide(PointB, PointC) +
                                 LengthOfSide(PointC, PointD) +
                                 LengthOfSide(PointD, PointE) +
                                 LengthOfSide(PointE, PointA);
                        Console.WriteLine("Pentagon perimeter: {0:f2}", result);
                        break;
                    default:
                        result = 0;
                        break;
                }
            }

            private enum BaseFigure
            {
                Triangle,
                Quadrangle,
                Pentagon
            }
        }
    }
}