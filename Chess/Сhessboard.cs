using System;

namespace Chess
{
    class Сhessboard
    {
        #region Private Members

        private readonly int height;
        private readonly int width;
        private readonly BoardItem[,] board;
        private readonly char blackSymbol = '*';
        private const char whiteSymbol = ' ';

        #endregion 

        public Сhessboard(int x, int y, char blackSymbol = '*')
        {
            width = x;
            height = y;
            board = new BoardItem[height, width];
            CreateBoardItems();
            this.blackSymbol = blackSymbol;
        }

        private void CreateBoardItems()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i % 2 == 0)
                    {
                        board[i, j] = new BoardItem(j % 2 == 0, i, j);
                    }
                    else
                    {
                        board[i, j] = new BoardItem(j % 2 != 0, i, j);
                    }
                }
            }
        }

        public void DrawBoard()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0, -2}", board[i, j].IsBlack ? blackSymbol : whiteSymbol);
                }
                Console.WriteLine();
            }
        }
    }
}
