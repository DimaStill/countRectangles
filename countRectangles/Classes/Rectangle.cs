using System;
using System.Collections.Generic;
using System.Text;

namespace countRectangles.Classes
{
    class Rectangle
    {
        public Point[] PointsRectangle { get; } = new Point[4];

        public Rectangle(Point A, Point B, Point C, Point D)
        {
            PointsRectangle[0] = A;
            PointsRectangle[1] = B;
            PointsRectangle[2] = C;
            PointsRectangle[3] = D;
        }
    }
}
