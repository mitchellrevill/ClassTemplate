using GameboardGUI;
using System.Text.Json;

namespace ClassTemplate
{
    public partial class Form1 : Form
    {
        const int NUM_OF_BOARD_ROWS = 8;
        const int NUM_OF_BOARD_COL = 8;

        GameboardImageArray _gameBoardGui;
        int[,] gameBoardData;
        string tileImagesDirPath = "Resources/";

        public Form1()
        {
            InitializeComponent();
            Point top = new Point(10, 10);
            Point bottom = new Point(10, 10);
            gameBoardData = this.MakeBoardArray();

            try
            {
                _gameBoardGui = new GameboardImageArray(this, gameBoardData, top, bottom, 0, tileImagesDirPath);
                _gameBoardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameBoardGui.UpdateBoardGui(gameBoardData);
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


        }

        public void GameTileClicked(object sender, EventArgs e)
        {

        }



    }
}