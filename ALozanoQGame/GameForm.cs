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
                    int rowTracker = 0;
                    int colTracker = 0;

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
                                    tileDataStrings[rowTracker, colTracker] += ", tile type: " + ln;

                                    //we have finished this tile, so increment tile count and reset tracker
                                    //for new tile 
                                    tileCount++;
                                    tileTracker = 0;

                                    richTextBox1.Text+= "\n" + (tileDataStrings[rowTracker, colTracker]);

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
