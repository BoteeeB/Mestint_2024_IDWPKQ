using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinForm_APP_IDWPKQ;

namespace teszt
{
    class Program
    {
        static void Main(string[] args)
        {
            Penzerme_State state = new Penzerme_State();
            int steps = SolveWithTrialAndError(state);
            Console.WriteLine($"Megoldás lépésszáma: {steps}");
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
