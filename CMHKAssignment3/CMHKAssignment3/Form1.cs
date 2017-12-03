
/***************************************************************************
 *  NAME : CHEVY MCMARTIN, HYERIM KIM
 *  STUDENT NUMBER : 7657968, 7518301
 *  REVISION HISTORY : OCT 19TH 2017
 *  PROJECT : ASSIGNMENT 3
 *  
 *  
 *  DOCUMENTATION COMMENT :
 *  THIS IS 15-PUZZLE GAME.
 *  WHEN THE PUZZLES ARE IN ORDER, THE GAME WILL END AND READY FOR NEW GAME.
 ***************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using CMHKAssignment3.Properties;
using Newtonsoft.Json;

namespace CMHKAssignment3
{
    public partial class Form1 : Form
    {
        // variables
        Button[,] button;
        int emptyRowIndex;
        int emptyColumnIndex;
        string[,] shufflePuzzles;

        public Form1()
        {
            InitializeComponent();
            shufflePuzzles = Puzzle.ShufflePuzzle(4, 4);
            GenerateButton(shufflePuzzles);
        }
        /// <summary>
        /// GenerateButton methods :
        /// This methods generates buttons programmatically 
        /// as the same size as the array (row, column) 
        /// </summary>
        /// <param name="shufflePuzzles"></param>
        public void GenerateButton(string[,] shufflePuzzles)
        {
            int btHeight = 420 / (shufflePuzzles.GetLength(0) + 1);
            int btWeight = 420 / (shufflePuzzles.GetLength(1) + 1);
            int top = 10;
            int left = 10;

            int counter = 0;
            int row = shufflePuzzles.GetLength(0);
            int column = shufflePuzzles.GetLength(1);
            button = new Button[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {

                    button[i, j] = new Button();
                    button[i, j].Size = new Size(btWeight, btHeight);
                    int fontsize;
                    if (btWeight > btHeight)
                        fontsize = Convert.ToInt16(btHeight * 0.6);
                    else
                        fontsize = Convert.ToInt16(btWeight*0.3);

                    button[i,j].Image = CMHKAssignment3.Properties.Resources.Button;
                    button[i, j].Left = left;
                    button[i, j].Top = top;
                    button[i, j].Font = new Font("Arial",fontsize, FontStyle.Bold);

                    if (shufflePuzzles[i, j] == "Empty")
                    {
                        button[i, j].Visible = false;
                        button[i, j].Text = shufflePuzzles[i, j].ToString();
                        emptyRowIndex = i;
                        emptyColumnIndex = j;
                    }
                    else
                    {
                        button[i, j].Text = shufflePuzzles[i, j].ToString();
                    }

                    button[i, j].Tag = i + "," + j;
                    button[i, j].Click += new EventHandler(button_Click);
                    btPanel.Controls.Add(button[i, j]);
                    left += btWeight + 2;
                    counter++;
                }
                left = 10;
                top += btHeight + 2;
            }
        }
        /// <summary>
        /// Geverate Button Click Event :
        /// When you click generate button, this event occures.
        /// This event makes puzzles based on the rows and columns you enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateBt_Click(object sender, EventArgs e)
        {
            btPanel.Controls.Clear();
            int row;
            int column;
            bool rowCheck = Int32.TryParse(RowsTxt.Text, out row);
            bool columnCheck = Int32.TryParse(ColumnsTxt.Text, out column);
            

            if (rowCheck && columnCheck)
            {
                if (row < 2 || column < 2 || row > 7 || column > 7)
                {
                    MessageBox.Show("The row and column should be between 2 and 7, inclusive.");
                    btPanel.Controls.Clear();
                    shufflePuzzles = null;
                }
                else
                {
                    shufflePuzzles = Puzzle.ShufflePuzzle(row, column);
                    if (Puzzle.WinCheck(shufflePuzzles))
                    {
                       GenerateBt_Click(sender, e);
                    }
                    GenerateButton(shufflePuzzles);
                }
            }
            else
            {
                MessageBox.Show("Please put number only.");
            }
        }
        /// <summary>
        /// Button Click Event :
        /// When you click button to make puzzles in correct order, this event occures.
        /// this event allows you to switch it with empty button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_Click(object sender, EventArgs e)
        {
            string[] index = new string[2];
            Button Clickedbutton = sender as Button;
            var tag = Clickedbutton.Tag.ToString();
            int buttonRowIndex;
            int buttonColumnIndex;
            index = tag.Split(new string[] { "," }, StringSplitOptions.None);
            buttonRowIndex = Convert.ToInt16(index[0]);
            buttonColumnIndex = Convert.ToInt16(index[1]);

            int sum = Math.Abs((buttonRowIndex - emptyRowIndex) + (buttonColumnIndex - emptyColumnIndex));
            if (sum == 1)
            {
                button[emptyRowIndex, emptyColumnIndex].Text = button[buttonRowIndex, buttonColumnIndex].Text;
                shufflePuzzles[emptyRowIndex, emptyColumnIndex] = button[buttonRowIndex, buttonColumnIndex].Text;
                button[emptyRowIndex, emptyColumnIndex].Visible = true;
                button[buttonRowIndex, buttonColumnIndex].Text = "Empty";
                shufflePuzzles[buttonRowIndex, buttonColumnIndex] = "Empty";
                button[buttonRowIndex, buttonColumnIndex].Visible = false;
                button[emptyRowIndex, emptyColumnIndex].Focus();
                emptyRowIndex = buttonRowIndex;
                emptyColumnIndex = buttonColumnIndex;

                if (Puzzle.WinCheck(shufflePuzzles))
                {
                    MessageBox.Show("Well done!");
                    GenerateBt_Click(sender, e);
                }
            }
        }
        /// <summary>
        /// Save Button Click Event :
        /// When you click save button, this event occurs.
        /// This event allows you to save puzzle file with the file name you enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBt_Click(object sender, EventArgs e)
        {
            if (shufflePuzzles == null || shufflePuzzles.GetLength(0) == 0 || shufflePuzzles.GetLength(1) == 0)
            {
                MessageBox.Show("Please generate puzzles first.");
            }
            else
            {
                DialogResult result = dlgSave.ShowDialog();
                switch (result)
                {
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        string filename = dlgSave.FileName;
                        Puzzle.doSave(filename, shufflePuzzles);
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Yes:
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Load Button Click Event :
        /// When you click button to make puzzles in correct order, this event occures.
        /// this event allows you to switch it with empty button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBt_Click(object sender, EventArgs e)
        {
            btPanel.Controls.Clear();
            DialogResult result = dlgOpen.ShowDialog();
            switch (result)
            {
                case DialogResult.Abort:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    string filename = dlgOpen.FileName;
                    List<string[,]> loadFile = new List<string[,]>();
                    string[,] size = new string[1, 2];
                    loadFile = Puzzle.doLoad(filename);
                    shufflePuzzles = loadFile[0];
                    size = loadFile[1];

                    if (shufflePuzzles.GetLength(0) == 1 && shufflePuzzles.GetLength(1) == 1)
                    {
                        MessageBox.Show(shufflePuzzles[0, 0]);
                    }
                    else
                    {
                        RowsTxt.Text = size[0, 0];
                        ColumnsTxt.Text = size[0, 1];
                        GenerateButton(shufflePuzzles);
                        if (Puzzle.WinCheck(shufflePuzzles))
                        {
                            MessageBox.Show("Well done!");
                            GenerateBt_Click(sender, e);
                        }
                    }
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Yes:
                    break;
                default:
                    break;
            }
        }
    }
}

