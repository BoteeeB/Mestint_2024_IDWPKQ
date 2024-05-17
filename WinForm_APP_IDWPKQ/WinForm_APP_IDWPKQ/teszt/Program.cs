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
            Penzerme_State state = new Penzerme_State();

            Console.WriteLine("Select a solver:");
            Console.WriteLine("1. Trial and Error");
            Console.WriteLine("2. Backtrack");
            Console.WriteLine("3. Depth-First");
            Console.WriteLine("4. Breadth-First");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            }

            int steps = 0;
            switch (choice)
            {
                case 1:
                    steps = SolveWithTrialAndError(state);
                    break;
                case 2:
                    steps = SolveWithBacktrack();
                    break;
                case 3:
                    steps = SolveWithDepthFirst();
                    break;
                case 4:
                    steps = SolveWithBreadthFirst();
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Solution steps: {steps}");
            Console.ReadLine();
        }

        static int SolveWithTrialAndError(Penzerme_State state)
        {
            List<Penzerme_Action> actions = Enum.GetValues(typeof(Penzerme_Action)).Cast<Penzerme_Action>().ToList();
            Random rnd = new Random();
            int steps = 0;
            bool solved = false;

            while (!solved)
            {
                var possibleActions = actions.Where(a => state.IsOperator(true, a)).ToList();
                if (possibleActions.Count > 0)
                {
                    var action = possibleActions[rnd.Next(possibleActions.Count)];
                    state.ApplyOperator(true, action);
                    steps++;
                    Console.WriteLine($"Steps: {steps}");
                    PrintBoard(state.baseboard);
                }
                else
                {
                    state = new Penzerme_State();
                    PrintBoard(state.baseboard);
                }
                solved = state.IsGoalState;
            }

            return steps;
        }

        static int SolveWithBacktrack()
        {
            Backtrack solver = new Backtrack();
            Node terminalNode = solver.Search();
            Stack<Node> solution = solver.GetSolution(terminalNode);
            int steps = PrintSolution(solution);
            return steps;
        }

        static int SolveWithDepthFirst()
        {
            DepthFirst solver = new DepthFirst();
            Node terminalNode = solver.Search();
            Stack<Node> solution = solver.GetSolution(terminalNode);
            int steps = PrintSolution(solution);
            return steps;
        }

        static int SolveWithBreadthFirst()
        {
            BreadthFirst solver = new BreadthFirst();
            Node terminalNode = solver.Search();
            Stack<Node> solution = solver.GetSolution(terminalNode);
            int steps = PrintSolution(solution);
            return steps;
        }

        static int PrintSolution(Stack<Node> solution)
        {
            if (solution == null)
            {
                Console.WriteLine("No solution found.");
                return 0;
            }

            int steps = 0;
            while (solution.Count > 0)
            {
                Node node = solution.Pop();
                Penzerme_State state = node.State;
                steps++;
                Console.WriteLine($"Steps: {steps}");
                PrintBoard(state.baseboard);
            }

            return steps;
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
