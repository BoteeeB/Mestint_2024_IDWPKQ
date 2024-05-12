using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_APP_IDWPKQ
{
    public partial class Penzerme : Form
    {
        private Penzerme_State game;
        private Random rnd;
        public Penzerme()
        {
            InitializeComponent();
            game = new Penzerme_State(); // Létrehozzuk a játék állapotát
            DrawGameBoard(); // Rajzoljuk ki a játéktáblát
            rnd = new Random();
        }


        private void DefaultSolve_Click(object sender, EventArgs e)
        {
            // ez a backtrack
        }

        private void DepthFirstSolve_Click(object sender, EventArgs e)
        {
            // Létrehozunk egy DepthFirst algoritmust
            DepthFirst solver = new DepthFirst();

            // Megkeressük a megoldást
            Node solutionNode = solver.Search();

            // Ha van megoldás
            if (solutionNode != null)
            {
                // Összegyűjtjük a megoldást egy sztringben
                StringBuilder solutionString = new StringBuilder();
                Stack<Node> solutionStack = new Stack<Node>();
                while (solutionNode != null)
                {
                    solutionStack.Push(solutionNode);
                    solutionNode = solutionNode.Parent;
                }
                while (solutionStack.Count != 0)
                {
                    solutionString.AppendLine(solutionStack.Pop().ToString());
                }

                // Kiírjuk a megoldást
                MessageBox.Show("Megoldás találva:\n" + solutionString.ToString());
            }
            else
            {
                // Ha nincs megoldás
                MessageBox.Show("Nincs megoldás.");
            }
        }



        private void BreadthFirstSolve_Click(object sender, EventArgs e)
        {
            // ez a breadthfirst
        }

        private void TrialError_Click(object sender, EventArgs e)
        {
            // Próba-hiba módszer futtatása
            while (!game.IsGoalState) // Amíg nincs célállapot
            {
                // Rajzoljuk ki a játéktáblát
                DrawGameBoard();

                // Véletlenszerű lépés végrehajtása
                Penzerme_Action randomAction = (Penzerme_Action)rnd.Next(0, 4); // Use the class-level random
                bool moved = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (game.board[i, j] == 1 && game.IsNeighbor(i, j))
                        {
                            moved = game.ApplyOperator(true, randomAction);
                            if (moved) break;
                        }
                    }
                    if (moved) break;
                }

                // Ha egyetlen érme sem mozgott, újraindítjuk a játékot
                if (!moved)
                {
                    game = new Penzerme_State();
                    continue;
                }

                // Várunk egy kicsit, hogy látható legyen a lépés
                System.Threading.Thread.Sleep(100);
            }

            // Ha elértük a célállapotot, újra rajzoljuk ki a játéktáblát
            DrawGameBoard();
            MessageBox.Show("Célállapot elérve!");
        }



        private void DrawGameBoard()
        {
            // Töröljük a korábbi rajzot, ha volt
            gamePanel.Controls.Clear();

            // Méretezzük a panelt, hogy a cellák egyenletesen elférjenek benne
            gamePanel.Width = 4 * 100; // 50 a cella mérete
            gamePanel.Height = 4 * 100;

            // Rajzoljuk ki a játéktáblát és az érméket
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Panel cell = new Panel();
                    cell.BackColor = game.board[i, j] == 1 ? Color.Gold : Color.White;
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
