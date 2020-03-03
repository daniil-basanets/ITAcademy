using System;

namespace Chess
{
    class Сhessboard
    {
        private readonly byte height;
        private readonly byte width;
        private BoardItem[,] board;
        private readonly char DrawSymbol = '*';

        public Сhessboard(byte rows, byte colls, char drawSymbol = '*')
        {
            width = colls;
            height = rows;
            board = new BoardItem[height, width];
            for (byte i = 0; i < height; i++)
            {
                for (byte j = 0; j < width; j++)
                {
                    if (i % 2 == 0)
                        board[i, j] = new BoardItem(j % 2 == 0, i, j);
                    else
                        board[i, j] = new BoardItem(j % 2 != 0, i, j);
                }
            }
            DrawSymbol = drawSymbol;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0, -2}", board[i, j].IsBlack ? DrawSymbol : ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
