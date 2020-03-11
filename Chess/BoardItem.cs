namespace Chess
{
    struct Coordinates
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class BoardItem
    {
        public Coordinates Position { get; set; }
        public ChessFigure Figure { get; set; }
        public bool IsBlack { get; }

        public BoardItem(bool IsBlack, int x, int y)
        {
            this.IsBlack = IsBlack;
            Position = new Coordinates(x, y);
        }
    }
}
