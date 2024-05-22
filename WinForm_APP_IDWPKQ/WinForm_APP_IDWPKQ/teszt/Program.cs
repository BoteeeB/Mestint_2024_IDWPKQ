using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("4. Trial and Error");

            int choice = int.Parse(Console.ReadLine());
            SolverBase solver = null;
            int stepCount = 0;

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
                case 4:
                    TrialError();
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            if (solver != null)
            {
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
                        stepCount++;
                    }
                }
                else
                {
                    Console.WriteLine("No solution found.");
                }

                Console.WriteLine($"Solution found in {stepCount} steps!");
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

        static void TrialError()
        {
            Penzerme_State game = new Penzerme_State();
            Random rnd = new Random();
            int stepCount = 0;
            List<Penzerme_Action> actions = Enum.GetValues(typeof(Penzerme_Action)).Cast<Penzerme_Action>().ToList();

            bool solved = false;

            while (!solved)
            {
                var possibleActions = actions.Where(a => game.IsOperator(true, a)).ToList();
                if (possibleActions.Count > 0)
                {
                    var action = possibleActions[rnd.Next(possibleActions.Count)];
                    game.ApplyOperator(true, action);
                    stepCount++;
                    Console.WriteLine($"Step {stepCount}: Applied action {action}");
                    PrintBoard(game.Baseboard);
                }
                else
                {
                    game = new Penzerme_State();
                    Console.WriteLine("No possible actions, resetting the game.");
                    PrintBoard(game.Baseboard);
                }
                solved = game.IsGoalState;
            }

            Console.WriteLine("Game solved!");
            Console.ReadLine();
        }

    }
}
