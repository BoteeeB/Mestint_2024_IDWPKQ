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

        public Penzerme()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            game = new Penzerme_State();
            UpdatePanel(JatekPanel);
        }

        public void UpdatePanel(Panel panel)
        {
            panel.Controls.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button button = new Button();
                    button.Width = button.Height = 100;
                    button.Top = i * 100;
                    button.Left = j * 100;
                    button.Enabled = false;
                    if (i == 1 && j == 1 || i == 1 && j == 2 || i == 2 && j == 1 || i == 2 && j == 2)
                    {
                        button.Font = new Font(button.Font.FontFamily, 37, FontStyle.Bold); // Szöveg formázása
                        button.Text = "O";
                    }
                    panel.Controls.Add(button);
                }
            }
        }


        private void DefaultSolve_Click(object sender, EventArgs e)
        {
            // ez a backtrack
        }

        private void DepthFirstSolve_Click(object sender, EventArgs e)
        {
            // ez a depthfirst
        }

        private void BreadthFirstSolve_Click(object sender, EventArgs e)
        {
            // ez a breadthfirst
        }
    }

}
