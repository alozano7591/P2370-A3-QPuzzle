/* Alfredo Lozano
 * 5397591
 * alozano7591@conestogac.on.ca
 * Assignment 3: QGame:
 * This project contains a program that allows users to create puzzle game maps 
 * and save their content.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALozanoQGame
{

    /// <summary>
    /// Form is responsible for the actual gameplay
    /// </summary>
    public partial class GameForm : Form
    {

        //this will be on the title of all message boxes
        private const string MSG_BOX_CAPTION = "Al's QGame";

        //The starting x position of the grid
        public const int START_X = 40;
        //The starting y position of the grid
        public const int START_Y = 60;
        //the value that will be used for length and width of our gridboxes
        public const int BLOCK_SIZE = 50;

        private int rowNum = 0;                                         //row numbers
        private int colNum = 0;                                         //used for tracking column number
        private GridBlock[,] tileBlocks;                                //2D array that tracks all of our blocks
        private string[,] tileDataStrings;                              //2D array of strings used for assigning values to blocks

        //list that stores the images that will be used for grid boxes
        private List<Bitmap> blockImages = new List<Bitmap>();

        private GridBlock selectedBlock;                                //track our selected box

        private int movesNum = 0;                                       //track the numeber of moves
        private int remainingBoxNum = 0;                               //track the remaining number of boxes

        /// <summary>
        /// Upon creating of the form initialize the component
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load our file using the filename given
        /// </summary>
        /// <param name="fileName">This is the name and path of the file to be loaded</param>
        private void LoadFile(string fileName)
        {

            if (File.Exists(fileName))
            {
                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(fileName))
                {
                    int counter = 0;        //counts all lines in the file
                    int tileTracker = -1;    //counts lines for each tile. This ensures we use the right amount of lines per tile
                    int rowTracker = 0;
                    int colTracker = 0;

                    int posX;                                   //starting x position of the grid
                    int posY;                                   //starting y position of the grid

                    int tileCount = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {

                        if (counter == 0)
                        {
                            //for first row make line data rowNum
                            rowNum = int.Parse(ln);
                        }
                        else if (counter == 1)
                        {
                            //for second row make line data colNum
                            colNum = int.Parse(ln);

                            //we have our row and col data, so start tracking tiles on following lines
                            tileDataStrings = new string[rowNum, colNum];
                            tileBlocks = new GridBlock[rowNum, colNum];
                            tileTracker = 0;
                        }
                        else
                        {
                            //start recording tile data until we reach our limit (determined when rowTracker equals rowNum)
                            if (rowTracker < rowNum)
                            {
                                if (tileTracker == 0)
                                {

                                    tileDataStrings[rowTracker, colTracker] = "\nrow: " + ln;
                                    tileTracker++;
                                }
                                else if (tileTracker == 1)
                                {
                                    tileDataStrings[rowTracker, colTracker] += ", col: " + ln;
                                    tileTracker++;
                                }
                                else if (tileTracker == 2)
                                {
                                    int tileType = int.Parse(ln);

                                    tileDataStrings[rowTracker, colTracker] += ", tile type: " + ln;

                                    //we have finished this tile, so increment tile count and reset tracker
                                    //for new tile 
                                    tileCount++;
                                    tileTracker = 0;

                                    //if our tile is not nothing, then make a block
                                    if (tileType > 0)
                                    {

                                        GridBlock block = new GridBlock(this, BLOCK_SIZE, rowTracker, colTracker, tileType);

                                        //Check if the type is valid and will produce a proper tile, if not still make but warn player
                                        if(!block.CheckIfTileTypeValid(tileType))
                                        {
                                            MessageBox.Show($"Warning: Tile type '{tileType}' is not a valid tile type. \n" +
                                                $"This will result in the tile been created with no valid value. \n" +
                                                $"This may seriously affect gameplay, perhaps make a new level file.", MSG_BOX_CAPTION);
                                        }

                                        tileBlocks[rowTracker, colTracker] = block;

                                        block.Left = START_X + (BLOCK_SIZE * colTracker);
                                        block.Top = START_Y + (BLOCK_SIZE * rowTracker);

                                        //this.Controls.Add(block);
                                        pnlTiles.Controls.Add(block);

                                        if (block.GetBlockType() == GridBlock.GridBlockType.RedBox || 
                                            block.GetBlockType() == GridBlock.GridBlockType.GreenBox)
                                        {
                                            block.Click += new EventHandler(box_Click);
                                            remainingBoxNum++;
                                            tbRemainingBoxes.Text = remainingBoxNum.ToString();
                                        }

                                    }

                                    //increment our column
                                    colTracker++;

                                    //once we reach our limit restart our column and go to next row
                                    if (colTracker >= colNum)
                                    {

                                        colTracker = 0;
                                        rowTracker++;

                                        if (rowTracker >= rowNum)
                                        {
                                            Console.WriteLine("We have reached the specified row/col limit");
                                        }
                                    }
                                }

                            }
                        }

                        Console.WriteLine(ln);
                        counter++;
                    }

                    //close the file and stop reading
                    file.Close();
                    Console.WriteLine($"File has {counter} lines.");
                }
            }
        }

        /// <summary>
        /// When the menu strip is pressed show options and react to pressed
        /// </summary>
        /// <param name="sender">the object thats sending message</param>
        /// <param name="e">the arguments</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                dlgOpen.Filter = "game file|*.qgame|Text File|*.txt|all files|*.*";

                DialogResult r = dlgOpen.ShowDialog();

                switch (r)
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        ResetGame();
                        LoadFile(dlgOpen.FileName);
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //all other exceptions show this message
                MessageBox.Show(ex.Message, MSG_BOX_CAPTION);

            }

        }

        /// <summary>
        /// Called on form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Load(object sender, EventArgs e)
        {
            //add images to the list for our grid images
            blockImages.Add(null);
            blockImages.Add(Properties.Resources.WallBlock);
            blockImages.Add(Properties.Resources.RedDoor);
            blockImages.Add(Properties.Resources.GreenDoor);
            blockImages.Add(Properties.Resources.RedBox);
            blockImages.Add(Properties.Resources.GreenBox);
        }

        /// <summary>
        /// Used to move the selected box left, right, up, or down.
        /// If no box is selected then show a warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBlock == null)
                {
                    MessageBox.Show("No box selected", MSG_BOX_CAPTION);
                    return;
                }

                Button btnDir = sender as Button;

                if (btnDir.Name == "btnLeft")
                {
                    MoveBox(-1, 0);
                }
                else if (btnDir.Name == "btnRight")
                {
                    MoveBox(1, 0);
                }
                else if (btnDir.Name == "btnUp")
                {
                    MoveBox(0, -1);
                }
                else if (btnDir.Name == "btnDown")
                {
                    MoveBox(0, 1);
                }

                //if the player has no boxes left, then they have won
                if (remainingBoxNum <= 0)
                {
                    MessageBox.Show(
                        "You Win! \n" +
                        "Total Moves: " + movesNum,
                        MSG_BOX_CAPTION);
                    ResetGame();
                }
            }
            catch (Exception ex)
            {
                //all other exceptions show this message
                MessageBox.Show(ex.Message, MSG_BOX_CAPTION);

            }

        }

        /// <summary>
        /// Use to move box in a direction. We don't have vectors, so xDir or yDir are used to determine directions.
        /// Only x or y are intended to have a value, if both have values other than 0 then x is prioritized.
        /// </summary>
        /// <param name="xDir">Treat as Vector2.X</param>
        /// <param name="yDir">Treat as Vector2.Y</param>
        private void MoveBox(int xDir, int yDir)
        {
            int colVal = selectedBlock.ColNum;
            int rowVal = selectedBlock.RowNum;
            bool tileClear = true;
            GridBlock nextBlock;
            bool moved = false;

            if (xDir != 0)
            {


                while (tileClear)
                {

                    nextBlock = GetTile(rowVal, colVal + xDir);

                    if (nextBlock == null)
                    {
                        selectedBlock.Left += BLOCK_SIZE * xDir;
                        tileBlocks[rowVal, colVal] = null;          //clear previous tileBlock index since we moved box out of its spot
                        colVal += xDir;
                        selectedBlock.ColNum = colVal;
                        tileBlocks[rowVal, colVal] = selectedBlock;

                        moved = true;
                    }
                    else
                    {

                        if (selectedBlock.CheckIfOtherTileIsMatch(nextBlock))
                        {
                            MessageBox.Show("We have a match", MSG_BOX_CAPTION);
                            moved = true;
                            BoxMatchAction(selectedBlock);
                        }

                        tileClear = false;
                    }

                }

            }
            else if (yDir != 0)
            {
                while (tileClear)
                {

                    nextBlock = GetTile(rowVal + yDir, colVal);

                    if (nextBlock == null)
                    {
                        tileBlocks[rowVal, colVal] = null;          //clear previous tileBlock index since we moved box out of its spot
                        selectedBlock.Top += BLOCK_SIZE * yDir;
                        rowVal += yDir;
                        selectedBlock.RowNum = rowVal;
                        tileBlocks[rowVal, colVal] = selectedBlock;

                        moved = true;
                    }
                    else
                    {

                        if (selectedBlock.CheckIfOtherTileIsMatch(nextBlock))
                        {
                            MessageBox.Show("We have a match", MSG_BOX_CAPTION);
                            moved = true;
                            BoxMatchAction(selectedBlock);
                        }

                        tileClear = false;
                    }

                }
            }

            if (moved)
            {
                movesNum++;
                tbMovesNumber.Text = movesNum.ToString();
            }

        }

        /// <summary>
        /// Called when a match is detected. This will remove the box from the game 
        /// and update our remaining box count.
        /// </summary>
        /// <param name="box">The box that found a matching door</param>
        private void BoxMatchAction(GridBlock box)
        {

            //remove the box from our panel and update info
            pnlTiles.Controls.Remove(box);
            selectedBlock = null;
            
            for(int i = 0; i < tileBlocks.GetLength(0); i++)
            {
                for(int j = 0; j < tileBlocks.GetLength(1); j++)
                {
                    if (tileBlocks[i,j] == box)
                    {
                        tileBlocks[i, j] = null;
                    }
                }
            }

            box.Dispose();
            remainingBoxNum--;
            tbRemainingBoxes.Text = remainingBoxNum.ToString();

        }

        /// <summary>
        /// Call to see what tile is at a specific coordinate
        /// </summary>
        /// <param name="row">acts as Y coord</param>
        /// <param name="col">acts as X coord</param>
        /// <returns></returns>
        private GridBlock GetTile(int row, int col)
        {

            //check the row and column, return the tile if there is one, return null otherwise
            return tileBlocks[row, col] == null ? null : tileBlocks[row, col];

        }

        /// <summary>
        /// Call this method when a box has hit a matching coloured door
        /// </summary>
        /// <param name="box">the selected box</param>
        /// <param name="door">the door that it hit</param>
        private void InitiateBoxMatchAction(GridBlock box, GridBlock door)
        {
            MessageBox.Show("We have a match", MSG_BOX_CAPTION);

            for(int i =0; i < tileBlocks.GetLength(0); i++)
            {
                for(int j=0; j < tileBlocks.GetLength(1); j++)
                {
                    if(box == tileBlocks[i, j])
                    {
                        //this.Controls.Remove(box);
                        pnlTiles.Controls.Remove(box);
                        remainingBoxNum--;
                        tbRemainingBoxes.Text = remainingBoxNum.ToString();
                    }
                    
                }
            }
            

        }

        /// <summary>
        /// Called when a green or red box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void box_Click(object sender, EventArgs e)
        {

            GridBlock gridBlock = sender as GridBlock;

            //if the block selected is a box type then make it our new selected box
            if (gridBlock.GetBlockType() == GridBlock.GridBlockType.RedBox || gridBlock.GetBlockType() == GridBlock.GridBlockType.GreenBox)
            {
                //if we have a selected box already then revert its border style back to normal
                if(selectedBlock != null)
                {
                    selectedBlock.BorderStyle = BorderStyle.FixedSingle;
                }

                //make this box our current selected box and update its border
                selectedBlock = gridBlock;
                selectedBlock.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        /// <summary>
        /// Clears board of all the tile bloocks and clears all the txt values
        /// </summary>
        private void ResetGame()
        {
            if (tileBlocks == null)
                return;

            for (int i = 0; i < tileBlocks.GetLength(0); i++)
            {
                for (int j = 0; j < tileBlocks.GetLength(1); j++)
                {

                    pnlTiles.Controls.Remove(tileBlocks[i,j]);
                    remainingBoxNum--;
                    tbRemainingBoxes.Text = remainingBoxNum.ToString();

                }
            }

            movesNum = 0;
            remainingBoxNum = 0;

            tbMovesNumber.Text = movesNum.ToString();
            tbRemainingBoxes.Text = remainingBoxNum.ToString();

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
