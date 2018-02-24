using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = BuildMatrix(dimestions);

            string command;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoS = GetIvoS(command);
                int[] evil = GetEvilPath();

                var evilPosition = new Position(evil[0], evil[1]);
                var ivoPosition = new Position(ivoS[0], ivoS[1]);

                EvilTurn(matrix, evilPosition);              

                sum = IvoTurn(matrix, sum, ivoPosition);
            }

            Console.WriteLine(sum);

        }

        private static long IvoTurn(int[,] matrix, long sum, Position ivoPosition)
        {
            while (ivoPosition.X >= 0 && ivoPosition.Y < matrix.GetLength(1))
            {
                if (IsInMatrix(ivoPosition, matrix))
                {
                    sum = CollectStars(matrix, sum, ivoPosition);
                }

                MoveIvo(ivoPosition);
            }

            return sum;
        }

        private static void EvilTurn(int[,] matrix, Position evilPosition)
        {
            while (evilPosition.X >= 0 && evilPosition.Y >= 0)
            {
                if (IsInMatrix(evilPosition, matrix))
                {
                    DestroyPosition(matrix, evilPosition);
                }

                MoveEvil(evilPosition);
            }
        }

        private static long CollectStars(int[,] matrix, long sum, Position ivoPosition)
        {
            sum += matrix[ivoPosition.X, ivoPosition.Y];
            return sum;
        }

        private static void DestroyPosition(int[,] matrix, Position evilPosition)
        {
            matrix[evilPosition.X, evilPosition.Y] = 0;
        }

        private static bool IsInMatrix(Position point, int[,] matrix)
        {
            return point.X >= 0 && point.X < matrix.GetLength(0) && point.Y >= 0 && point.Y < matrix.GetLength(1);
        }


        private static void MoveEvil(Position evilPosition)
        {
            evilPosition.X--;
            evilPosition.Y--;
        }

        private static void MoveIvo(Position ivoPosition)
        {
            ivoPosition.Y++;
            ivoPosition.X--;
        }

        private static int[] GetEvilPath()
        {
            return Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        private static int[] GetIvoS(string command)
        {
            return command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        private static int[,] BuildMatrix(int[] dimestions)
        {
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
