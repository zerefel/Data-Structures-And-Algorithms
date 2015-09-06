using System;
using System.Collections;
using System.Collections.Generic;
using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private static int width = 9;
    private static int height = 7;
    private static char[,] labyrinth;
 

    private const char VisitedCell = 's';
    
    public static void Main()
    {
        ReadLabyrinth();

        string shortestPathToExit = FindShortestPathToExit();

        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPathToExit);
        }

    }

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartNode();

        if (startPosition == null)
        {
            return null;
        }

        // Enqueue the start cell, while the queue has elements, enqueue all children of the current element
        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            Point currentCell = queue.Dequeue();

            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", 1, 0);
            TryDirection(queue, currentCell, "D", 0, 1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }

        return null;
    }

    static Point FindStartNode()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labyrinth[y, x] == VisitedCell)
                {
                    return new Point(){X = x, Y = y};
                }
            }
        }

        // No start point found
        return null;
    }

    static bool IsExit(Point point)
    {
        bool isOnBorderY = point.Y == 0 || point.Y == height - 1;
        bool isOnBorderX = point.X == 0 || point.X == width - 1;

        return isOnBorderX || isOnBorderY;
    }

    static void TryDirection(Queue<Point> queue, Point currentPosition, string direction, int x, int y)
    {
        int newX = currentPosition.X + x;
        int newY = currentPosition.Y + y;

        if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newY, newX] == '-')
        {
            labyrinth[newY, newX] = VisitedCell;

            var nextCell = new Point()
            {
                X = newX,
                Y = newY,
                PreviousPoint = currentPosition,
                Direction = direction
            };

            queue.Enqueue(nextCell);
        }
    }

    static string TracePathBack(Point currentCell)
    {
        string path = string.Empty;
        string reversedPath = String.Empty;

        while (currentCell.PreviousPoint != null)
        {
            path += currentCell.Direction;
            currentCell = currentCell.PreviousPoint;
        }

        for (int i = path.Length - 1; i >= 0; i--)
        {
            reversedPath += path[i];
        }

        return reversedPath;
    }

    static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());

        labyrinth = new char[height, width];

        for (int row = 0; row < height; row++)
        {
            string labyrinthLine = Console.ReadLine();

            char[] splittedLine = labyrinthLine.ToCharArray();

            for (int col = 0; col < splittedLine.Length; col++)
            {
                labyrinth[row, col] = splittedLine[col];
            }
        }
    }
}