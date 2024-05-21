using System;
using System.Collections.Generic;
using WinForm_APP_IDWPKQ;

namespace teszt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the search algorithm:");
            Console.WriteLine("1. BreadthFirst");
            Console.WriteLine("2. DepthFirst");
            Console.WriteLine("3. Backtrack");

            int choice = int.Parse(Console.ReadLine());
            SolverBase solver = null;

            switch (choice)
            {
                case 1:
                    solver = new BreadthFirst(true);
                    break;
                case 2:
                    solver = new DepthFirst(true);
                    break;
                case 3:
                    solver = new Backtrack(100, true);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Node result = solver.Search();
            if (result != null)
            {
                Console.WriteLine("Solution found!");
                Stack<Node> solution = solver.GetSolution(result);
                while (solution.Count > 0)
                {
                    Node node = solution.Pop();
                    PrintBoard(node.State.Baseboard);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No solution found.");
            }
            Console.ReadLine();
        }

        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
