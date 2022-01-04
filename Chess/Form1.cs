using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        bool Start = false;
        bool Finish = false;

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }
         
        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];

            myBoard.MarkLegalMoves(currentCell);

            if(Start == false && y == myBoard.Size - 1 || btnGrid[x, y].Text == "Move" )
                currentCell.CurrentlyOccupied = true;

            if (y == myBoard.Size - 1)
                Start = true;

                if (Start == true && Finish == false && myBoard.theGrid[x, y].CurrentlyOccupied == true)
                {
                    for (int i = 0; i < myBoard.Size; i++)
                    {
                        for (int j = 0; j < myBoard.Size; j++)
                        {
                            btnGrid[i, j].Text = "";

                            if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                            {
                                btnGrid[i, j].Text = "♟️";

                                if (j == 0)
                                {
                                    Start = false;
                                    Finish = true;
                                    btnGrid[i - 1, j].Text = "";
                                }
                            }
                            else if (myBoard.theGrid[i, j].LegalMove == true && Finish == false)
                                btnGrid[i, j].Text = "Move";
                        }
                    }
                }
                if(Finish == true)
                    MessageBox.Show("You won!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
