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

        private int rowNum = 0;
        private int colNum = 0; 
        private int[,] tileTypes;
        private string[,] tileDataStrings;

        public GameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load our file using the filename given
        /// </summary>
        /// <param name="fileName">This is the name and path of the file to be loaded</param>
        private void Load(string fileName)
        {

            if (File.Exists(fileName))
            {
                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(fileName))
                {
                    int counter = 0;        //counts all lines in the file
                    int tileTracker = -1;    //counts lines for each tile. This ensures we use the right amount of lines per tile
                    int tileCount = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        if(counter == 0)
                        {
                            //for first row make line data rowNum
                            rowNum = int.Parse(ln);
                        }
                        else if(counter == 1)
                        {
                            //for second row make line data colNum
                            colNum = int.Parse(ln);
                        }
                        else if(counter == 2)
                        {

                            tileDataStrings = new string[rowNum, colNum];

                            //for third row start tracking tile data
                            tileTracker = 0;
                        }

                        
                        if(tileTracker == 0)
                        {

                            tileDataStrings[tileCount, tileCount] = "row: " + ln;
                            tileTracker++;
                        }
                        else if(tileTracker == 1)
                        {
                            tileDataStrings[tileCount, tileCount] = "col: " + ln;
                            tileTracker++;
                        }
                        else if(tileTracker == 2)
                        {
                            tileDataStrings[tileCount, tileCount] = "tyle type: " + ln;
                            tileTracker=0;
                            tileCount++;
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
                    Load(dlgOpen.FileName);

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
    }
}
