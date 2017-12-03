using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMHKAssignment3
{
    /// <summary>
    /// Puzzle Class :
    /// This class is for puzzle methods,
    /// including: Sorting puzzles, File IO, etc.
    /// This class helps the project to be organized by
    /// seperating form events and methods that are needed for the events.
    /// </summary>
    class Puzzle
    {
        /// <summary>
        /// WinCheck method :
        /// This method checks if the current puzzle is ordered correctly.
        /// If so, return true.
        /// Otherwise, return false.
        /// </summary>
        /// <param name="shuffleCards"></param>
        /// <returns></returns>
        public static bool WinCheck(string[,] shuffleCards)
        {
            int counter = 1;
            bool winnerCheck = true;
            for (int i = 0; i < shuffleCards.GetLength(0); i++)
                for (int j = 0; j < shuffleCards.GetLength(1); j++)
                {
                    if (!(i == shuffleCards.GetLength(0) - 1 && j == shuffleCards.GetLength(1) - 1) && shuffleCards[i, j] != counter.ToString())
                        winnerCheck = false;

                    else if (i == shuffleCards.GetLength(0) - 1 && j == shuffleCards.GetLength(1) - 1 && shuffleCards[i, j] != "Empty")
                    {
                        winnerCheck = false;
                    }

                    counter++;
                }
            return winnerCheck;
        }
        /// <summary>
        /// ShufflePuzzle method :
        /// This methods shuffles the puzzle.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string[,] ShufflePuzzle(int row, int column)
        {
            string[,] shuffleValue = CorrectOrder(row, column);
            string[,] emptyIndex = new string[1, 2];
            int emptyRowIndex = row - 1;
            int emptyColumnIndex = column - 1;
            List<string[,]> temp = new List<string[,]>();
            Random rnd = new Random();
            int rndNo = rnd.Next(20, 100);

            //Use Random number for iteration to make different combinations of puzzles.
            for (int i = 0; i < rndNo; i++)
            {
                temp = ShuffleArray(emptyRowIndex, emptyColumnIndex, shuffleValue);
                shuffleValue = temp[0];
                emptyIndex = temp[1];
                emptyRowIndex = int.Parse(emptyIndex[0, 0]);
                emptyColumnIndex = int.Parse(emptyIndex[0, 1]);
            }

            // Make Empty place in correct spot for row 
            // EmptyBackkLoop = shuffleValue.GetLength(0)-1 - emptyRowIndex;
            for (int i = emptyRowIndex; i < shuffleValue.GetLength(0) - 1; i++)
            {
                shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex + 1, emptyColumnIndex];
                shuffleValue[emptyRowIndex + 1, emptyColumnIndex] = "Empty";
                emptyRowIndex++;
            }
            // Make Empty place in correct spot for column
            // EmptyBackkLoop = shuffleValue.GetLength(1)-1 - emptyColumnIndex;
            for (int i = emptyColumnIndex; i < shuffleValue.GetLength(1) - 1; i++)
            {
                shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex, emptyColumnIndex + 1];
                shuffleValue[emptyRowIndex, emptyColumnIndex + 1] = "Empty";
                emptyColumnIndex++;
            }

            return shuffleValue;
        }
        /// <summary>
        /// ShuffleArray method :
        /// This method shuffles the array.
        /// </summary>
        /// <param name="emptyRowIndex"></param>
        /// <param name="emptyColumnIndex"></param>
        /// <param name="correctOrder"></param>
        /// <returns></returns>
        public static List<string[,]> ShuffleArray(int emptyRowIndex, int emptyColumnIndex, string[,] correctOrder)
        {
            List<string[,]> shuffleValueArrayAndEmptyIndex = new List<string[,]>();
            string[,] shuffleValue = correctOrder;
            string[,] EmptyIndex = new string[1, 2];
            for (int i = 0; i < shuffleValue.GetLength(0); i++)
            {
                for (int j = 0; j < shuffleValue.GetLength(1); j++)
                {
                    int sum = Math.Abs((i - emptyRowIndex) + (j - emptyColumnIndex));
                    if (sum == 1)
                    {
                        shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[i, j];
                        shuffleValue[i, j] = "Empty";
                        emptyRowIndex = i;
                        emptyColumnIndex = j;

                        if (emptyRowIndex < shuffleValue.GetLength(0) - 1)
                        {
                            shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex + 1, emptyColumnIndex];
                            shuffleValue[emptyRowIndex + 1, emptyColumnIndex] = "Empty";
                            emptyRowIndex++;
                        }
                        else
                        {
                            shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex - 1, emptyColumnIndex];
                            shuffleValue[emptyRowIndex - 1, emptyColumnIndex] = "Empty";
                            emptyRowIndex--;
                        }
                        if (emptyColumnIndex < shuffleValue.GetLength(1) - 1)
                        {
                            shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex, emptyColumnIndex + 1];
                            shuffleValue[emptyRowIndex, emptyColumnIndex + 1] = "Empty";
                            emptyColumnIndex++;
                        }
                        else
                        {
                            shuffleValue[emptyRowIndex, emptyColumnIndex] = shuffleValue[emptyRowIndex, emptyColumnIndex - 1];
                            shuffleValue[emptyRowIndex, emptyColumnIndex - 1] = "Empty";
                            emptyColumnIndex--;
                        }
                        break;
                    }
                }
            }
            EmptyIndex[0, 0] = emptyRowIndex.ToString();
            EmptyIndex[0, 1] = emptyColumnIndex.ToString();

            shuffleValueArrayAndEmptyIndex.Add(shuffleValue);
            shuffleValueArrayAndEmptyIndex.Add(EmptyIndex);

            return shuffleValueArrayAndEmptyIndex;
        }
        /// <summary>
        /// CorrectOrder method :
        /// This method generates the puzzle in the correct order.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string[,] CorrectOrder(int row, int column)
        {
            List<string[,]> correctOredrArrayAndEmptyIndex = new List<string[,]>();
            string[,] shuffleValue = new string[row, column];
            int counter = 1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (!(i == row - 1 && j == column - 1))
                    {
                        shuffleValue[i, j] = counter.ToString();
                        counter++;
                    }
                    else
                    {
                        shuffleValue[i, j] = "Empty";
                    }
                }
            }
            return shuffleValue;
        }
        /// <summary>
        /// Do save method :
        /// This methods saves the file with the name the user enters.
        /// Inside of the file, it saves puzzle-array and puzzle size.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="shuffleCards"></param>
        public static void doSave(string filename, string[,] shuffleCards)
        {
            StreamWriter writer = new StreamWriter(filename);
            Random r = new Random();
            string size = shuffleCards.GetLength(0).ToString() + "*" + shuffleCards.GetLength(1).ToString();
            writer.WriteLine("Puzzle");
            writer.WriteLine(size);

            for (int i = 0; i < shuffleCards.GetLength(0); i++)
            {
                for (int j = 0; j < shuffleCards.GetLength(1); j++)
                {
                    writer.WriteLine(shuffleCards[i, j]);
                }
            }
            writer.Close();
        }
        /// <summary>
        /// Do load method :
        /// This methods loads the file with the name the user entered.
        /// Inside of the file, it loads puzzles-array and puzzle size.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<string[,]> doLoad(string filename)
        {
            List<string[,]> loadFileInfo = new List<string[,]>();
            string fileExt = System.IO.Path.GetExtension(filename);
            string[,] shufflePuzzle;
            string[,] size2D = new string[1, 2];

            if (fileExt != ".txt")
            {
                shufflePuzzle = new string[1, 1];
                shufflePuzzle[0, 0] = "Please load correct file.";
            }
            else
            {
                StreamReader reader = new StreamReader(filename);
                string[] size = new string[2];

                if (reader.ReadLine() != "Puzzle")
                {
                    shufflePuzzle = new string[1, 1];
                    shufflePuzzle[0, 0] = "Please load correct file.";
                }
                else
                {
                    size = reader.ReadLine().Split('*');
                    size2D[0, 0] = size[0];
                    size2D[0, 1] = size[1];

                    int row = int.Parse(size[0]);
                    int column = int.Parse(size[1]);
                    shufflePuzzle = new string[row, column];

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            shufflePuzzle[i, j] = reader.ReadLine();
                        }
                    }
                    reader.Close();
                }

            }
            loadFileInfo.Add(shufflePuzzle);
            loadFileInfo.Add(size2D);
            return loadFileInfo;
        }
    }
}
