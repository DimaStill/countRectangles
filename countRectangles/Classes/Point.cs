using System;
using System.Collections.Generic;
using System.Text;

namespace countRectangles.Classes
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y;
        }

        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X != secondPoint.X || firstPoint.Y != secondPoint.Y;
        }
    }
}
