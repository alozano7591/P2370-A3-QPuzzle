/* DesignerForm.cs
 * Public class that is used for the form functionality and design of the game designer.
 * Revision History: 
 *      Alfredo Lozano, 2022.11.04: Created
 *      Alfredo Lozano, 2022.11.05: Get/Set for enum type, tracks and counts box types
 */

using ALozanoQGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
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
    /// Form class for the design form. This is responsible for the base functions of the game designer form.
    /// </summary>
    public partial class DesignerForm : Form
    {

        //The starting x position of the grid
        public const int START_X = 200;
        //The starting y position of the grid
        public const int START_Y = 150;
        //the value that will be used for length and width of our gridboxes
        public const int GRID_BLOCK_SIZE = 50;

        public const string MSG_BOX_CAPTION = "Al's QGame";

        //variables used for holding our box images
        private Bitmap wallImage;
        private Bitmap redDoorImage;
        private Bitmap greenDoorImage;
        private Bitmap redBoxImage;
        private Bitmap greenBoxImage;

        //keeps track of which image is going to be set onto blocks
        private Bitmap activeImage;
        //keeps track of block type of activeImage
        private GridBlock.GridBlockType activeBlockType = GridBlock.GridBlockType.None;

        //Keeps track of our rows and columns
        private int Rows { get; set; }
        private int Columns { get; set; }  

        //this keeps track of all the GridBlock objects in the game
        private List<GridBlock> gridBlocks = new List<GridBlock>();


        private string supportedFileTypes = "QGame file|*.qgame|Text File|*.txt|All files|*.*";

        /// <summary>
        /// Form constructor, initializes components
        /// </summary>
        public DesignerForm()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Start the process of generating game grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {

            try
            {

                int rows = int.Parse(tbRows.Text);          //number of rows the grid will have
                int cols = int.Parse(tbColumns.Text);       //number of columns the grid will have

                int posX;                                   //starting x position of the grid
                int posY;                                   //starting y position of the grid

                //if we have more than 0 rows and 0 cols then make grid
                if (rows <= 0 || cols <= 0)
                {
                    throw new Exception("Error: Rows and Columns must be greater than zero, please submit proper numbers.");
                }
                else
                {
                    //for every row, create the number of boxes needed based on column number assigned
                    for (int i = 0; i < rows; i++)
                    {
                        posY = START_Y + (GRID_BLOCK_SIZE * i);

                        for (int j = 0; j < cols; j++)
                        {
                            posX = START_X + (GRID_BLOCK_SIZE * j);

                            GridBlock block = new GridBlock(this, GRID_BLOCK_SIZE, i, j);

                            block.Left = posX;
                            block.Top = posY;

                            this.Controls.Add(block);

                            block.Click += new EventHandler(pictureBoxGridBlock_Click);

                            //Add the newly created block to our class list
                            gridBlocks.Add(block);
                        }
                    }

                    //check if grid height too large for current form, is so increase form height size
                    if (gridBlocks[gridBlocks.Count - 1].Bottom > this.Size.Height)
                    {
                        //increase the height to fit the grid
                        this.Size = new Size(this.Size.Width, gridBlocks[gridBlocks.Count - 1].Bottom + gridBlocks[gridBlocks.Count - 1].Size.Height);
                    }

                    //check if grid width too large for current form, is so increase form width size
                    if (gridBlocks[gridBlocks.Count - 1].Right > this.Size.Width)
                    {
                        //increase the width to fit the grid
                        this.Size = new Size(gridBlocks[gridBlocks.Count - 1].Right + gridBlocks[gridBlocks.Count - 1].Size.Width, this.Size.Height);
                    }

                    //If we've gotten this far then the creation of the grid is probably successul 
                    //save our rows and columns to our global values for later use
                    Rows = rows;
                    Columns = cols;
                }

            }
            catch(FormatException ex)
            {
                //Show this message when it is detected that a user has entered an incorrect format
                MessageBox.Show("Format Error: input values for rows and columns must be integers. Please enter whole numbers only.\n" +
                    ex.Message, 
                    MSG_BOX_CAPTION);
            
            }
            catch(Exception ex)
            {
                //all other exceptions show this message
                MessageBox.Show(ex.Message, MSG_BOX_CAPTION);

            }

        }

        /// <summary>
        /// Responds to each tool button that is clicked.
        /// Each button changes the current grid image that is active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnBlockTool_Click(object sender, EventArgs e)
        {

            //save a reference to the button that we have just pressed
            Button btnTool = sender as Button;

            //find out which image and boxtype top associate
            if (btnTool == btnNone)
            {
                activeImage = null;
                activeBlockType = GridBlock.GridBlockType.None;
            }
            else if (btnTool == btnWall)
            {
                activeImage = wallImage;
                activeBlockType = GridBlock.GridBlockType.Wall;
            }
            else if (btnTool == btnRedDoor)
            {
                activeImage = redDoorImage;
                activeBlockType = GridBlock.GridBlockType.RedDoor;
            }
            else if (btnTool == btnGreenDoor)
            {
                activeImage = greenDoorImage;
                activeBlockType = GridBlock.GridBlockType.GreenDoor;
            }
            else if (btnTool == btnRedBox)
            {
                activeImage = redBoxImage;
                activeBlockType = GridBlock.GridBlockType.RedBox;
            }
            else if (btnTool == btnGreenBox)
            {
                activeImage = greenBoxImage;
                activeBlockType = GridBlock.GridBlockType.GreenBox;
            }


        }

        /// <summary>
        /// This event is tied to each grid block that is instaniated. When a grid block is pressed call this method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBoxGridBlock_Click(object sender, EventArgs e)
        {

            GridBlock gridBlock = sender as GridBlock;

            //gridBlock.SetBlockType(blockImages[activeIMGIndex], activeIMGIndex);
            gridBlock.SetBlockType(activeImage, (int)activeBlockType);

        }

        /// <summary>
        /// Start the saving process for the current game design layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if(gridBlocks.Count <= 0)
                {
                    throw new Exception("Unable to save since nothing has been created yet");
                }

                int numOfWalls = 0;
                int numOfDoors = 0;
                int numOfBoxes = 0;

                saveFileDialogDesign.Filter = supportedFileTypes;

                DialogResult result = saveFileDialogDesign.ShowDialog();

                

                switch(result)
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        try
                        {
                            SaveFile(saveFileDialogDesign.FileName);

                            //loop through list of girdblocks and return the number of each type (walls, doors, boxes)
                            for (int i = 0; i < gridBlocks.Count; i++)
                            {
                                if (gridBlocks[i].GetBlockType() == GridBlock.GridBlockType.Wall)
                                {
                                    numOfWalls++;
                                }
                                else if (gridBlocks[i].GetBlockType() == GridBlock.GridBlockType.RedDoor || 
                                    gridBlocks[i].GetBlockType() == GridBlock.GridBlockType.GreenDoor)
                                {
                                    numOfDoors++;
                                }
                                else if (gridBlocks[i].GetBlockType() == GridBlock.GridBlockType.RedBox ||
                                    gridBlocks[i].GetBlockType() == GridBlock.GridBlockType.GreenBox)
                                {
                                    numOfBoxes++;
                                }
                            }

                            //When Save is successfull show a message detailing the walls, doors and boxes
                            MessageBox.Show(string.Format(
                                "File Saved Successfull\n" +
                                "Total Number of walls: {0}\n" +
                                "Total Number of doors: {1}\n" +
                                "Total Number of boxes: {2}",
                                numOfWalls, numOfDoors, numOfBoxes),
                                MSG_BOX_CAPTION);

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Unable to save due to error: " + ex.Message);
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, MSG_BOX_CAPTION);
            }
            
        }

        /// <summary>
        /// Call to save file. File uses the firs two lines for rows and columns.
        /// Each following line is reserved for properties related to a GridBlock 
        /// For each GridBlock there is a line for row, another for column, and a third for type
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveFile(string fileName)
        {

            StreamWriter writer = new StreamWriter(fileName);

            writer.WriteLine(Rows);
            writer.WriteLine(Columns);

            //record block properties, using one new line per property per block
            for(int i = 0; i < gridBlocks.Count; i++)
            {
                writer.WriteLine(gridBlocks[i].RowNum);
                writer.WriteLine(gridBlocks[i].ColNum);
                writer.WriteLine(gridBlocks[i].GetBlockTypeNumber());
            }

            //close strema writer
            writer.Close();

        }

        /// <summary>
        /// Close this designer form. This will return user to the starting form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Called once the form has loaded. This is used to initialize several variables and lists.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesignerForm_Load(object sender, EventArgs e)
        {
            
            //save our images to variables. Saved to array before but that ended up forcing me to use magic numbers
            wallImage   = Properties.Resources.WallBlock;
            redDoorImage = Properties.Resources.RedDoor;
            greenDoorImage = Properties.Resources.GreenDoor;
            redBoxImage = Properties.Resources.RedBox;
            greenBoxImage = Properties.Resources.GreenBox;

            //add our resourced images to our ImageList, this will allow for use of images in buttons with custom sizing
            imageListTools.Images.Add(Properties.Resources.None);
            imageListTools.Images.Add(Properties.Resources.WallBlock);
            imageListTools.Images.Add(Properties.Resources.RedDoor);
            imageListTools.Images.Add(Properties.Resources.GreenDoor);
            imageListTools.Images.Add(Properties.Resources.RedBox);
            imageListTools.Images.Add(Properties.Resources.GreenBox);

            //assign images from our ImageList to our buttons
            btnNone.Image = imageListTools.Images[0];
            btnWall.Image = imageListTools.Images[1];
            btnRedDoor.Image = imageListTools.Images[2];
            btnGreenDoor.Image = imageListTools.Images[3];
            btnRedBox.Image = imageListTools.Images[4];
            btnGreenBox.Image = imageListTools.Images[5];

        }
    }
}
