using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            BuildRoom(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];

            PositionSam(samPosition);

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        col = PositionChecker.MoveEnemy(room, row, col);
                    }
                }

                int[] getEnemy = new int[2];

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }

                PositionChecker.KillSamIfWithinReach(room, samPosition, getEnemy);

                PositionChecker.MoveSam(room, moves, samPosition, i);

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }

                PositionChecker.KillNikoladze(room, samPosition, getEnemy);
            }
        }    

        private static void PositionSam(int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void BuildRoom(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

      
    }
}
