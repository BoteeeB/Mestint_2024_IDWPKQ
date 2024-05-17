using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_APP_IDWPKQ
{
    public partial class Penzerme : Form
    {
        private Penzerme_State game;
        private Random rnd;
        private int stepCount;

        public Penzerme()
        {
            InitializeComponent();
            game = new Penzerme_State();
            DrawGameBoard();
            rnd = new Random();
            stepCount = 0;
        }

        private async void DefaultSolve_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Backtrack solver = new Backtrack(50, true);
                Node terminalNode = solver.Search();
                Stack<Node> solution = solver.GetSolution(terminalNode);

                if (solution == null)
                {
                    game = new Penzerme_State();
                    DrawGameBoard();
                    await Task.Delay(500);
                }
                else
                {
                    while (solution.Count > 0)
                    {
                        Node node = solution.Pop();
                        game = node.State;
                        stepCount++;
                        stepsLabel.Text = $"Steps: {stepCount}";
                        DrawGameBoard();
                        await Task.Delay(500);
                    }
                    break;
                }
            }
        }

        private async void DepthFirstSolve_Click(object sender, EventArgs e)
        {
            while (true)
            {
                DepthFirst solver = new DepthFirst();
                Node terminalNode = solver.Search();
                Stack<Node> solution = solver.GetSolution(terminalNode);

                if (solution == null)
                {
                    game = new Penzerme_State();
                    DrawGameBoard();
                    await Task.Delay(500);
                }
                else
                {
                    while (solution.Count > 0)
                    {
                        Node node = solution.Pop();
                        game = node.State;
                        stepCount++;
                        stepsLabel.Text = $"Steps: {stepCount}";
                        DrawGameBoard();
                        await Task.Delay(500);
                    }
                    break;
                }
            }
        }

        private async void BreadthFirstSolve_Click(object sender, EventArgs e)
        {
            while (true)
            {
                BreadthFirst solver = new BreadthFirst();
                Node terminalNode = solver.Search();
                Stack<Node> solution = solver.GetSolution(terminalNode);

                if (solution == null)
                {
                    game = new Penzerme_State();
                    DrawGameBoard();
                    await Task.Delay(500);
                }
                else
                {
                    while (solution.Count > 0)
                    {
                        Node node = solution.Pop();
                        game = node.State;
                        stepCount++;
                        stepsLabel.Text = $"Steps: {stepCount}";
                        DrawGameBoard();
                        await Task.Delay(500);
                    }
                    break;
                }
            }
        }

        private async void TrialError_Click(object sender, EventArgs e)
        {
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
                    stepsLabel.Text = $"Steps: {stepCount}";
                    DrawGameBoard();
                    await Task.Delay(10);
                }
                else
                {
                    game = new Penzerme_State();
                    DrawGameBoard();
                }
                solved = game.IsGoalState;
            }
        }

        private void DrawGameBoard()
        {
            gamePanel.Controls.Clear();

            gamePanel.Width = 4 * 100;
            gamePanel.Height = 4 * 100;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Panel cell = new Panel();
                    cell.BackColor = game.Baseboard[i, j] == 'C' ? Color.Gold : Color.White;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.Width = 100;
                    cell.Height = 100;
                    cell.Location = new Point(j * 100, i * 100);
                    gamePanel.Controls.Add(cell);
                }
            }
        }
    }
}
