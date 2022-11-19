using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALozanoQGame
{
    internal class TileType : PictureBox
    {

        //Added an enum for keeping track of block types
        //enums aren't significantly more useful right now than ints, but I placed them in preperation for the next assignment
        //which I assume these will be much more usefull for
        public enum GridBlockType { None, Wall, RedDoor, GreenDoor, RedBox, GreenBox };

        //the enum for this specific block
        private GridBlockType blockType = GridBlockType.None;

        public int TileSize { get; set; } = 50;

        //Properties used to track the exact row and column of this GridBlock object
        public int RowNum { get; set; }
        public int ColNum { get; set; }

        private DesignerForm owner;

        /// <summary>
        /// GridBlock constructor. Called when object created.
        /// </summary>
        /// <param name="form">The owning form of the button</param>
        /// <param name="size">The size of the button. Size is used for both length and width.</param>
        /// <param name="row">The row number of the column</param>
        /// <param name="col">The column number of the grid block</param>
        public TileType(DesignerForm form, int size, int row, int col)
        {
            this.owner = form;
            TileSize = size;
            this.Width = TileSize;
            this.Height = TileSize;
            this.RowNum = row;
            this.ColNum = col;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public TileType(int tileType, int rowNum, int colNum, DesignerForm owner)
        {
            //this.blockType = tileType;
            RowNum = rowNum;
            ColNum = colNum;
            this.owner = owner;
        }




        /// <summary>
        /// Sets the block type by changing the image and setting it to a new enum using the given int.
        /// </summary>
        /// <param name="bitmapIMG">The image to change the block to.</param>
        /// <param name="blockNum">A number corresponding to the enum block types</param>
        public void SetBlockType(Bitmap bitmapIMG, int blockNum)
        {
            this.Image = bitmapIMG;

            blockType = (GridBlockType)blockNum;
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
