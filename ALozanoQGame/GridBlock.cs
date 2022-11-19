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
        public GridBlock(DesignerForm form, int size, int row, int col)
        {
            this.owner = form;
            this.Width = size;
            this.Height = size;
            this.RowNum = row;
            this.ColNum = col;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
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
