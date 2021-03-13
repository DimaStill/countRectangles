using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace countRectangles.Classes
{
    static class CountRectangles
    {
        public static List<Point> Points { get; } = new List<Point>();

        public static List<Rectangle> FoundRectangles { get; } = new List<Rectangle>();

        // Проверяем диагонали прямоугольника, т.к. у прямоугольника диагонали равны 
        // и имеют точку пересечения, в которой диагонали делятся пополам
        public static int Calculate()
        {
            int countRectangles = 0;

            for (int i = 0; i < Points.Count; i++)
            {
                Point firstPoint = Points[i];
                for (int j = 0; j < Points.Count; j++)
                {
                    if (i == j) continue;
                    Point secondPoint = Points[j];
                    for (int k = 0; k < Points.Count; k++)
                    {
                        if (i == k || j == k) continue;
                        Point thirdPoint = Points[k];
                        for (int t = 0; t < Points.Count; t++)
                        {
                            if (i == t || j == t || k == t) continue;
                            Point fourthPoint = Points[t];
                            Point halfDiagonalPointBetweenFirstAndSecond = GetPointOfHalfDiagonal(firstPoint, secondPoint);
                            Point halfDiagonalPointBetweenThirdAndFourth = GetPointOfHalfDiagonal(thirdPoint, fourthPoint);

                            if (halfDiagonalPointBetweenFirstAndSecond == halfDiagonalPointBetweenThirdAndFourth)
                            {
                                bool rectangleIsExist = FoundRectangles.Any(rectangle =>
                                    rectangle.PointsRectangle.All(point =>
                                        point == firstPoint || point == secondPoint || point == thirdPoint || point == fourthPoint
                                   )
                                );
                                if (!rectangleIsExist)
                                {
                                    Rectangle newRectangle = new Rectangle(firstPoint, secondPoint, thirdPoint, fourthPoint);
                                    FoundRectangles.Add(newRectangle);
                                    countRectangles++;
                                }
                            }
                        }
                    }
                }
            }

            return countRectangles;
        }

        private static Point GetPointOfHalfDiagonal(Point firstPoint, Point secondPoint)
        {
            double smallerX = Math.Min(firstPoint.X, secondPoint.X);
            double smallerY = Math.Min(firstPoint.Y, secondPoint.Y);
            double largerX = Math.Max(firstPoint.X, secondPoint.X);
            double largerY = Math.Max(firstPoint.Y, secondPoint.Y);
            double xHalfDiagonalLength = (largerX - smallerX) / 2;
            double yHalfDiagonalLength = (largerY - smallerY) / 2;
            return new Point(smallerX + xHalfDiagonalLength, smallerY + yHalfDiagonalLength);
        }

        public static void AddNewPoint(double x, double y)
        {
            Points.Add(new Point(x, y));
        }
    }
}
