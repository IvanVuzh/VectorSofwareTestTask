using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("############## T A S K 1 ###########");
            var sudoku = new Sudoku();
            Console.WriteLine("Enter size");
            do
            {
                try
                {
                    sudoku.Size = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Not integer entered try again");
                }
            }
            while (sudoku.Size == 0);
            
            
            sudoku.SetData();
            sudoku.Print();
            sudoku.checkResult();
        }
    }
    class Sudoku
    {
        int size;
        public int Size
        {
            get { return size; }
            set
            {
                if (value > 1 && Math.Sqrt(value) % 1 == 0)
                {
                    size = value;
                }
                else
                {
                    size = 0;
                    Console.WriteLine("Wrong size entered");
                }
            }
        }
        public int[,] SudokuData { get; set; }

        public void SetData()
        {

            while (Size == 0)
            {
                Console.WriteLine("Enter Size of sudoku first");
                try
                {
                    Size = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Not integer entered");
                }
            }
            Console.WriteLine("Enter sudoku data");
            SudokuData = new int[Size, Size];
            int intChecker = 0;
            for (int i = 0; i < Size; i++) //rows
            {
                for (int j = 0; j < Size; j++) //columns
                {
                    Console.WriteLine($"Enter element in row {i + 1} and column {j + 1}");
                    while (intChecker == 0 || intChecker > Size)
                    {
                        try
                        {
                            intChecker = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Not integer or too big integer entered. Reenter data");
                        }
                    }
                    SudokuData[i, j] = intChecker;
                    intChecker = 0;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Sudoku is:\n");
            string toPrint = "[ ";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    toPrint += SudokuData[i, j] + ", ";
                }
                toPrint = toPrint.Remove(toPrint.Length - 2);
                toPrint += " ]";
                Console.WriteLine(toPrint);
                toPrint = "[ ";
            }
        }

        public void checkResult()
        {
            List<int> uniqueChecher = new List<int>();
            List<int> uniqueChecherCol = new List<int>();
            bool result = true;
            for (int i = 0; i < Size; i++)      //row & col checker
            {

                for (int j = 0; j < Size; j++)
                {
                    uniqueChecher.Add(SudokuData[i, j]);
                    uniqueChecherCol.Add(SudokuData[j, i]);
                }
                if (uniqueChecher.Distinct().Count() != Size)
                {
                    Console.WriteLine($"Error in row {i + 1}");
                    result = false;
                }
                if (uniqueChecherCol.Distinct().Count() != Size)
                {
                    Console.WriteLine($"Error in column {i + 1}");
                    result = false;
                }
                uniqueChecher.Clear();
                uniqueChecherCol.Clear();
            }

            int squareStep = Convert.ToInt32(Math.Sqrt(Size));
            int squareColNumber = 0;
            for (int r = 0; r < squareStep; r++)        //little square rows taker
            {
                for (int i = r * squareStep; i < (r + 1) * squareStep; i++)
                {
                    for (int j = squareColNumber; j < (squareColNumber + 1)*squareStep; j++)
                    {
                        uniqueChecher.Add(SudokuData[i, j]);
                    }
                    if (uniqueChecher.Distinct().Count() != uniqueChecher.Count)
                    {
                        Console.WriteLine($"Error in small square");
                        result = false;
                    }
                    uniqueChecher.Clear();
                }
                squareColNumber++;
            }
            if(result)
            {
                Console.WriteLine("You successfuly passed sudoku! Congrats!");
            }
            else
            {
                Console.WriteLine("Sudoku test failed. Try again.");
            }
        }
    }
}
