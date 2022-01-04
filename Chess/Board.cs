namespace Chess
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public Board (int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkLegalMoves(Cell currentCell)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (currentCell.RowNumber < Size - 1)
                     theGrid[currentCell.RowNumber + 1, currentCell.CollumnNumber].LegalMove = true;
                    if (currentCell.RowNumber > 0)
                        theGrid[currentCell.RowNumber - 1, currentCell.CollumnNumber].LegalMove = true;
                    if (currentCell.CollumnNumber < Size - 1)
                        theGrid[currentCell.RowNumber, currentCell.CollumnNumber + 1].LegalMove = true;
                    if (currentCell.CollumnNumber > 0)
                        theGrid[currentCell.RowNumber, currentCell.CollumnNumber - 1].LegalMove = true;
                }
            }
        }
    }
}
