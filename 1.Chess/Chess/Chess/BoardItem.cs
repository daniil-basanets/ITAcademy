namespace Chess
{
    struct Coordinates
    {
        public byte Row { get; set; }
        public byte Coll { get; set; }
        public Coordinates(byte rowNum, byte colNum)
        {
            Row = rowNum;
            Coll = colNum;
        }
    }

    class BoardItem
    {
        public Coordinates Position { get; set; }
        public ChessFigure Figure { get; set; }

        public bool IsBlack { get; }
        public BoardItem(bool IsBlack, byte rowNum, byte colNum)
        {
            this.IsBlack = IsBlack;
            Position = new Coordinates(rowNum, colNum);
        }
    }
}
