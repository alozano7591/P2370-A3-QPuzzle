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
    public partial class GameForm : Form
    {

        //The starting x position of the grid
        public const int START_X = 40;
        //The starting y position of the grid
        public const int START_Y = 60;
        //the value that will be used for length and width of our gridboxes
        public const int BLOCK_SIZE = 50;

        private int rowNum = 0;
        private int colNum = 0; 
        private GridBlock[,] tileBlocks;
        private string[,] tileDataStrings;

        //list that stores the images that will be used for grid boxes
        private List<Bitmap> blockImages = new List<Bitmap>();

        private GridBlock selectedBlock;

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
                            richTextBox1.Text = "rows: " + rowNum;
                        }
                        else if (counter == 1)
                        {
                            //for second row make line data colNum
                            colNum = int.Parse(ln);
                            richTextBox1.Text += "\ncolumns: " + colNum;


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

                                    richTextBox1.Text += "\n" + (tileDataStrings[rowTracker, colTracker]);

                                    //if our tile is not nothing, then make a block
                                    if (tileType > 0)
                                    {
                                        GridBlock block = new GridBlock(this, BLOCK_SIZE, rowTracker, colTracker, tileType);

                                        block.Left = START_X + (BLOCK_SIZE * colTracker);
                                        block.Top = START_Y + (BLOCK_SIZE * rowTracker);

                                        this.Controls.Add(block);

                                        //if the gridblock that we're adding is a box, then add to event handler
                                        if (tileType == 4 || tileType == 5)
                                        {
                                            block.Click += new EventHandler(box_Click);
                                        }
                                    }

                                    colTracker++;

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
                    file.Close();
                    Console.WriteLine($"File has {counter} lines.");
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "game file|*.qgame|Text File|*.txt|all files|*.*";

            DialogResult r = dlgOpen.ShowDialog();

            switch (r)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
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

        private void box_Click(object sender, EventArgs e)
        {

            GridBlock gridBlock = sender as GridBlock;


            MessageBox.Show("You clicked a box!", "Al's QGame");

            //if the block type is box type
            if(gridBlock.GetBlockTypeNumber() == 4 || gridBlock.GetBlockTypeNumber() == 5)
            {

                selectedBlock = gridBlock;

            }
        }
    }
}
