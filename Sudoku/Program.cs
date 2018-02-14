using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku = {
                     {0,0,0,0,0,2,1,0,0},
                     {0,0,4,0,0,8,7,0,0},
                     {0,2,0,3,0,0,9,0,0},
                     {6,0,2,0,0,3,0,4,0},
                     {0,0,0,0,0,0,0,0,0},
                     {0,5,0,6,0,0,3,0,1},
                     {0,0,3,0,0,5,0,8,0},
                     {0,0,8,2,0,0,5,0,0},
                     {0,0,9,7,0,0,0,0,0}
            };

            if (SolveSudoku(sudoku, 0, 0))
            {
                PrintSudoku(sudoku);
            }
            Console.ReadLine();
        }

        static bool IsAvailable(int[,] puzzle, int row, int col, int num)
        {
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; i++)
            {
                if (puzzle[row, i] == num) return false;
                if (puzzle[i, col] == num) return false;
                if (puzzle[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
            }
            return true;
        }

        public static bool SolveSudoku(int[,] puzzle, int row, int col)
        {
            if (row < 9 && col < 9)
            {
                if (puzzle[row, col] != 0)
                {
                    if ((col + 1) < 9) return SolveSudoku(puzzle, row, col + 1);
                    else if ((row + 1) < 9) return SolveSudoku(puzzle, row + 1, 0);
                    else return true;
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (IsAvailable(puzzle, row, col, i + 1))
                        {
                            puzzle[row,col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row, col + 1)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row + 1, 0)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }
                return false;
            }
            else return true;
        }

        public static void PrintSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
