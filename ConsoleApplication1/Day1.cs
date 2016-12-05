using System;

namespace ConsoleApplication1
{
    public class Day1
    {
        public void Run()
        {
            string routeStr =
                @"R2, L3, R2, R4, L2, L1, R2, R4, R1, L4, L5, R5, R5, R2, R2, R1, L2, L3, L2, L1, R3, L5, R187, R1, R4, L1, R5, L3, L4, R50, L4, R2, R70, L3, L2, R4, R3, R194, L3, L4, L4, L3, L4, R4, R5, L1, L5, L4, R1, L2, R4, L5, L3, R4, L5, L5, R5, R3, R5, L2, L4, R4, L1, R3, R1, L1, L2, R2, R2, L3, R3, R2, R5, R2, R5, L3, R2, L5, R1, R2, R2, L4, L5, L1, L4, R4, R3, R1, R2, L1, L2, R4, R5, L2, R3, L4, L5, L5, L4, R4, L2, R1, R1, L2, L3, L2, R2, L4, R3, R2, L1, L3, L2, L4, L4, R2, L3, L3, R2, L4, L3, R4, R3, L2, L1, L4, R4, R2, L4, L4, L5, L1, R2, L5, L2, L3, R2, L2";

            Direction dir = Direction.N;
            int x = 0, y = 0;
            foreach (string s in routeStr.Split(','))
            {
                int dist = Convert.ToInt32(s.Trim().Substring(1));
                dir = GetDirection(dir, s.Trim()[0].ToString());

                if (dir == Direction.N) y += dist;
                if (dir == Direction.E) x += dist;
                if (dir == Direction.S) y -= dist;
                if (dir == Direction.W) x -= dist;
                Console.WriteLine("Input={0}: dir={1}, dist={2}, x={3}, y{4}", s.Trim(),
                    Enum.GetName(typeof (Direction), dir), dist, x, y);
            }

            Console.WriteLine("x={0}, y={1}, total={2}", x, y, x + y);
        }

        enum Direction{N,E,S,W};

        Direction GetDirection(Direction dir, string turnCommand)
        {
            if (dir == Direction.N) return (turnCommand == "R") ? Direction.E : Direction.W;
            if (dir == Direction.E) return (turnCommand == "R") ? Direction.S : Direction.N;
            if (dir == Direction.S) return (turnCommand == "R") ? Direction.W : Direction.E;
            if (dir == Direction.W) return (turnCommand == "R") ? Direction.N : Direction.S;
            throw new ArgumentException("Incorrect Direction: " + turnCommand);
        }
    }
}