using System;
using System.Collections.Generic;
using System.Text;

namespace countRectangles.Classes
{
    class Menu
    {
        public static void DisplayMenu()
        {
            do
            {
                DisplayEnteredPoints();
                Console.Write("\nMenu options:\n" +
                    "1. Add point\n" +
                    "2. Calculate count rectangles\n" +
                    "Select option: ");
                try
                {
                    int selectedOption = Convert.ToInt32(Console.ReadLine());
                    SelectMenuOption(selectedOption);
                }
                catch
                {
                    Console.WriteLine("Incorrect input. Try again");
                }
                Console.WriteLine("Press any key for continue");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        private static void SelectMenuOption(int optionIndex)
        {
            switch (optionIndex)
            {
                case 1:
                    Console.Write("Enter X coordinate of the point: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Y coordinate of the point: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    CountRectangles.AddNewPoint(x, y);
                    break;
                case 2:
                    if (CountRectangles.Points.Count < 4)
                    {
                        Console.WriteLine("Enter minimum 4 points");
                        return;
                    }
                    int countRectangles = CountRectangles.Calculate();
                    Console.WriteLine($"Count rectangles: {countRectangles}");
                    Console.WriteLine("Points rectangles");
                    foreach (Rectangle rectangle in CountRectangles.FoundRectangles)
                    {
                        foreach (Point point in rectangle.PointsRectangle)
                        {
                            Console.Write($"({point.X}, {point.Y}); ");
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("Wrong menu option. Try again");
                    break;
            }
        }

        private static void DisplayEnteredPoints()
        {
            Console.Write("Entered Points: ");
            if (CountRectangles.Points.Count == 0)
            {
                Console.Write("none");
                return;
            }

            foreach(Point point in CountRectangles.Points) 
            {
                Console.Write($"({point.X}, {point.Y}); ");
            }
        }
    }
}
