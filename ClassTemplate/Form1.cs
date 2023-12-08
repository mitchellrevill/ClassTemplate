using GameboardGUI;
using System.Text.Json;

namespace ClassTemplate
{
    public partial class Form1 : Form
    {
        const int NUM_OF_BOARD_ROWS = 8;
        const int NUM_OF_BOARD_COL = 8;

        GameboardImageArray GUI_Controls;
        int[,] GameDataArray;
        string tileImagesDirPath = "Resources/";

        public Form1()
        {
            InitializeComponent();
            Point top = new Point(10, 10);
            Point bottom = new Point(10, 10);
            // Offset from Corner of the form (Allows you to move where the board is generated)

            GameDataArray = this.MakeBoardArray(); 

            try
            {
                GUI_Controls = new GameboardImageArray(this, GameDataArray, top, bottom, 0, tileImagesDirPath);
                GUI_Controls.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                GUI_Controls.UpdateBoardGui(GameDataArray); // Updates the GameGUI with GAMEBOARDDATA
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.ToString(), "GAME BOARD SIZE PROBLEM", MessageBoxButtons.OK);
                this.Close();
            }

        }
        private int[,] MakeBoardArray()
        {
            int[,] BoardArray = new int[NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL];
            return BoardArray;
            // Builds Array Before Constructor Which is stored in gameboarddata.
        }

        public void GameTileClicked(object sender, EventArgs e)
        {
            int selectionRow = GUI_Controls.GetCurrentRowIndex(sender);
            int selectionCol = GUI_Controls.GetCurrentColumnIndex(sender);

            // Generates click event, "GetCurrentColumn/RowIndex Collects Coordinates of clicked picturebox
            // Index's from 0, 0,0 is top left of the grid.

            // GUI_Controls.SetTile(TileRow, TileCol, ImagePath)
        }
    }
}


// Few notes
// GUI_Controls does not store any data about the game, it just applies changes (SetTile(), UpdateBoardGui())
// GameDataArray actually stores all the game data, so if you wants cells to be able to change based on the game you have to update the GameDataArray 
// With the same "Move" you did to change the GUI so you have a accurate "Map" of the GUI
//
// Heres Some examples of USEFUl solutions to possible problems
//
// GUI_Controls.UpdateBoardGui(array of coords/values) 
// GUI_Controls.GetCurrentRowIndex(sender);
// GUI_Controls.GetCurrentColumnIndex(sender);
// GUI_Controls.SetTile(TileRow, TileCol, ImagePath)
