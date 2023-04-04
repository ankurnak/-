using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp31
{
    public partial class Form1 : Form
    {
        private Tmatr matrix;
        public Form1()
        {
            InitializeComponent();
        }
        public class Tmatr
        {
            private int[,] matrix;
            private int numRows;
            private int numCols;

            public Tmatr(int rows, int columns)
            {
                numRows = rows;
                numCols = columns;
                matrix = new int[numRows, numCols];
            }

            public void Resize(int rows, int columns)
            {
                numRows = rows;
                numCols = columns;
                matrix = new int[numRows, numCols];
            }

            public int[,] GetMatrix()
            {
                return matrix;
            }

            public int GetNumRows()
            {
                return numRows;
            }

            public int GetNumCols()
            {
                return numCols;
            }

            public void SetElement(int row, int col, int value)
            {
                matrix[row, col] = value;
            }

            public int GetElement(int row, int col)
            {
                return matrix[row, col];
            }

            public int[,] GetSubMatrix(int rowStart, int rowEnd, int colStart, int colEnd)
            {
                int[,] subMatrix = new int[rowEnd - rowStart + 1, colEnd - colStart + 1];
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    for (int j = colStart; j <= colEnd; j++)
                    {
                        subMatrix[i - rowStart, j - colStart] = matrix[i, j];
                    }
                }
                return subMatrix;
            }
        }
            private void button1_Click(object sender, EventArgs e)
            {
                int rows = int.Parse(textBox1.Text);
                int columns = int.Parse(textBox2.Text);
                matrix = new Tmatr(rows, columns);
            }

            private void button2_Click(object sender, EventArgs e)
            {
                int rows = int.Parse(textBox1.Text);
                int columns = int.Parse(textBox2.Text);
                matrix.Resize(rows, columns);
            }

            private void button3_Click(object sender, EventArgs e)
            {
                textBox3.Text = matrix.ToString();
            }

            private void button4_Click(object sender, EventArgs e)
            {
            int startRow = int.Parse(textBox4.Text);
            int startColumn = int.Parse(textBox5.Text); // заменил textBox6 на textBox5, так как textBox6 используется для numRows
            int numRows = int.Parse(textBox6.Text);
            int numColumns = int.Parse(textBox7.Text);
            int[,] submatrixArray = matrix.GetSubMatrix(startRow, startColumn, startRow + numRows - 1, startColumn + numColumns - 1); // заменил numRows на startRow + numRows - 1 и numColumns на startColumn + numColumns - 1, так как они должны быть индексами, а не количеством строк и столбцов
            Tmatr submatrix = new Tmatr(numRows, numColumns);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    submatrix.SetElement(i, j, submatrixArray[i, j]);
                }
            }
            textBox3.Text = MatrixToString(submatrix.GetMatrix(), numRows, numColumns); // использовал метод MatrixToString для вывода матрицы в виде строки
        }
        private string MatrixToString(int[,] matrix, int numRows, int numCols)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    stringBuilder.Append(matrix[i, j].ToString());
                    if (j < numCols - 1)
                    {
                        stringBuilder.Append(", ");
                    }
                }

                if (i < numRows - 1)
                {
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }


        }
    }

