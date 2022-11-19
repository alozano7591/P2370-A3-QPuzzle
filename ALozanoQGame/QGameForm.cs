/* QGameForm.cs
 * This is the main base form for the application.
 * Revision History: 
 *      Alfredo Lozano, 2022.11.04: Created
 *      Alfredo Lozano, 2022.11.05: Added notes
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALozanoQGame
{

    /// <summary>
    /// QGameForm class. This has all the logic to the simple starting form that acts as a main menu for the game.
    /// </summary>
    public partial class QGameForm : Form
    {

        /// <summary>
        /// Main Class for the game form. This is the main caller for other objects and logic
        /// </summary>
        public QGameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When button pressed it will call this function which closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This method is used for opening the game designer window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {

            DesignerForm designerForm = new DesignerForm();

            designerForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();    
        }
    }
}
