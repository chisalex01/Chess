namespace Chess
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int CollumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalMove { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            CollumnNumber = y;
        }
    }
}
