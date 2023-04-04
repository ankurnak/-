using System;

namespace ConsoleApp6
{
    public class Tmatr
    {
        private int[,] matrix; 
        private int rows; 
        private int cols; 

       
        public Tmatr(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.matrix = new int[rows, cols];
        }

       
        public void Resize(int rows, int cols)
        {
            int[,] newMatrix = new int[rows, cols];

            for (int i = 0; i < Math.Min(rows, this.rows); i++)
            {
                for (int j = 0; j < Math.Min(cols, this.cols); j++)
                {
                    newMatrix[i, j] = this.matrix[i, j];
                }
            }

            this.matrix = newMatrix;
            this.rows = rows;
            this.cols = cols;
        }

        
        public void PrintSubmatrix(int startRow, int startCol, int numRows, int numCols)
        {
            for (int i = startRow; i < Math.Min(startRow + numRows, this.rows); i++)
            {
                for (int j = startCol; j < Math.Min(startCol + numCols, this.cols); j++)
                {
                    Console.Write(this.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        
        public void PrintMatrix()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write(this.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void ReadMatrix()
        {
            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    this.matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть к-сть строк: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть к-сть стовбців: ");
            int cols = Convert.ToInt32(Console.ReadLine());

            Tmatr matrix = new Tmatr(rows, cols);
            matrix.ReadMatrix();
            Console.WriteLine("\nМатриця:");
            matrix.PrintMatrix();
        }
    }
}