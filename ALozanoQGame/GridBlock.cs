/* GridBlock.cs
 * A public class that is used as a construction block in the game.
 * Revision History: 
 *      Alfredo Lozano, 2022.11.04: Created
 *      Alfredo Lozano, 2022.11.05: Get/Set for enum type
 *      Alfredo Lozano, 2022.11.06: Added save logic
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ALozanoQGame
{



    /// <summary>
    /// A GridBlock is a PictureBox object used for desigining the game and eventually the actual gameplay. 
    /// Each gridblock also stores their type values and images.
    /// </summary>
    public class GridBlock : PictureBox
    {

        //Added an enum for keeping track of block types
        //enums aren't significantly more useful right now than ints, but I placed them in preperation for the next assignment
        //which I assume these will be much more usefull for
        public enum GridBlockType { None, Wall, RedDoor, GreenDoor, RedBox, GreenBox};

        //the enum for this specific block
        private GridBlockType blockType = GridBlockType.None;

        public int BlockSize { get; set; } = 50;

        //Properties used to track the exact row and column of this GridBlock object
        public int RowNum { get; set; }
        public int ColNum { get; set; }

        //list that stores the images that will be used for grid boxes
        private List<Bitmap> blockImages = new List<Bitmap>();

        //the form that owns this block
        private Form owner;

        /// <summary>
        /// GridBlock constructor. Called when object created.
        /// </summary>
        /// <param name="form">The owning form of the button</param>
        /// <param name="size">The size of the button. Size is used for both length and width.</param>
        /// <param name="row">The row number of the column</param>
        /// <param name="col">The column number of the grid block</param>
        public GridBlock(Form form, int size, int row, int col)
        {
            this.owner = form;
            BlockSize = size;
            this.Width = BlockSize;
            this.Height = BlockSize;
            this.RowNum = row;
            this.ColNum = col;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            
        }

        public GridBlock(Form owner, int blockSize, int rowNum, int colNum, int blockTypeNum)
        {
            this.owner = owner;
            
            //set our block size
            BlockSize = blockSize;
            this.Width = BlockSize;
            this.Height = BlockSize;

            RowNum = rowNum;
            ColNum = colNum;

            SetBlockType(blockTypeNum);

            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }




        /// <summary>
        /// Sets the block type by changing the image and setting it to a new enum using the given int.
        /// Available for custom setting of images
        /// </summary>
        /// <param name="bitmapIMG">The image to change the block to.</param>
        /// <param name="blockNum">A number corresponding to the enum block types</param>
        public void SetBlockType(Bitmap bitmapIMG, int blockNum)
        {
            this.Image = bitmapIMG;

            blockType = (GridBlockType)blockNum;
        }

        /// <summary>
        /// Set block type only using a number. This will have block set image on its own using default images
        /// </summary>
        /// <param name="blockNum"></param>
        public void SetBlockType(int blockNum)
        {

            this.blockType = (GridBlockType)blockNum;

            switch (blockType)
            {
                case GridBlockType.None:

                    break;
                case GridBlockType.Wall:
                    Image = Properties.Resources.WallBlock;
                    break;
                case GridBlockType.RedDoor:
                    Image = Properties.Resources.RedDoor;
                    break;
                case GridBlockType.GreenDoor:
                    Image = Properties.Resources.GreenDoor;
                    break;
                case GridBlockType.RedBox:
                    Image = Properties.Resources.RedBox;
                    break;
                case GridBlockType.GreenBox:
                    Image = Properties.Resources.GreenBox;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Call this in order to get the integer version of the block type
        /// </summary>
        /// <returns></returns>
        public int GetBlockTypeNumber()
        {
            return (int)blockType;
        }

    }
}
