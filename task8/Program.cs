// See https://aka.ms/new-console-template for more information
using System;

class A
{
    static int[,] chessboard = new int[8, 8];
    static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

    static void MoveKnight()
    {
    
        int x = 0;
        int y = 0;
        chessboard[x, y] = 1;

        
        for (int step = 2; step <= 64; step++)
        {
            int minAvailableMoves = int.MaxValue;
            int nextX = 0;
            int nextY = 0;

            for (int i = 0; i < 8; i++)
            {
                int nextXPos = x + dx[i];
                int nextYPos = y + dy[i];

                if (IsValidMove(nextXPos, nextYPos) && chessboard[nextXPos, nextYPos] == 0)
                {
                    int availableMoves = CountAvailableMoves(nextXPos, nextYPos);
                    if (availableMoves < minAvailableMoves)
                    {
                        minAvailableMoves = availableMoves;
                        nextX = nextXPos;
                        nextY = nextYPos;
                    }
                }
            }

            chessboard[nextX, nextY] = step;
            x = nextX;
            y = nextY;
        }
    }

    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && y >= 0 && x < 8 && y < 8;
    }

    static int CountAvailableMoves(int x, int y)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int nextX = x + dx[i];
            int nextY = y + dy[i];

            if (IsValidMove(nextX, nextY) && chessboard[nextX, nextY] == 0)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        MoveKnight();

        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(chessboard[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
