namespace WinForm_APP_IDWPKQ
{
    partial class Penzerme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DefaultSolve = new System.Windows.Forms.Button();
            this.DepthFirstSolve = new System.Windows.Forms.Button();
            this.BreadthFirstSolve = new System.Windows.Forms.Button();
            this.TrialError = new System.Windows.Forms.Button();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DefaultSolve
            // 
            this.DefaultSolve.BackColor = System.Drawing.Color.ForestGreen;
            this.DefaultSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DefaultSolve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DefaultSolve.Location = new System.Drawing.Point(606, 139);
            this.DefaultSolve.Name = "DefaultSolve";
            this.DefaultSolve.Size = new System.Drawing.Size(184, 94);
            this.DefaultSolve.TabIndex = 1;
            this.DefaultSolve.Text = "BACKTRACK";
            this.DefaultSolve.UseVisualStyleBackColor = false;
            this.DefaultSolve.Click += new System.EventHandler(this.DefaultSolve_Click);
            // 
            // DepthFirstSolve
            // 
            this.DepthFirstSolve.BackColor = System.Drawing.Color.ForestGreen;
            this.DepthFirstSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepthFirstSolve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepthFirstSolve.Location = new System.Drawing.Point(606, 265);
            this.DepthFirstSolve.Name = "DepthFirstSolve";
            this.DepthFirstSolve.Size = new System.Drawing.Size(184, 93);
            this.DepthFirstSolve.TabIndex = 2;
            this.DepthFirstSolve.Text = "DEPTH FIRST";
            this.DepthFirstSolve.UseVisualStyleBackColor = false;
            this.DepthFirstSolve.Click += new System.EventHandler(this.DepthFirstSolve_Click);
            // 
            // BreadthFirstSolve
            // 
            this.BreadthFirstSolve.BackColor = System.Drawing.Color.ForestGreen;
            this.BreadthFirstSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BreadthFirstSolve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BreadthFirstSolve.Location = new System.Drawing.Point(606, 397);
            this.BreadthFirstSolve.Name = "BreadthFirstSolve";
            this.BreadthFirstSolve.Size = new System.Drawing.Size(184, 94);
            this.BreadthFirstSolve.TabIndex = 3;
            this.BreadthFirstSolve.Text = "BREADTH FIRST";
            this.BreadthFirstSolve.UseVisualStyleBackColor = false;
            this.BreadthFirstSolve.Click += new System.EventHandler(this.BreadthFirstSolve_Click);
            // 
            // TrialError
            // 
            this.TrialError.BackColor = System.Drawing.Color.ForestGreen;
            this.TrialError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TrialError.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TrialError.Location = new System.Drawing.Point(606, 12);
            this.TrialError.Name = "TrialError";
            this.TrialError.Size = new System.Drawing.Size(184, 93);
            this.TrialError.TabIndex = 4;
            this.TrialError.Text = "PRÓBA-HIBA";
            this.TrialError.UseVisualStyleBackColor = false;
            this.TrialError.Click += new System.EventHandler(this.TrialError_Click);
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.gamePanel.Location = new System.Drawing.Point(23, 30);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(470, 368);
            this.gamePanel.TabIndex = 5;
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stepsLabel.Location = new System.Drawing.Point(19, 467);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(0, 24);
            this.stepsLabel.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Orange;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearButton.Location = new System.Drawing.Point(450, 434);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 57);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Penzerme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 532);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stepsLabel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.TrialError);
            this.Controls.Add(this.BreadthFirstSolve);
            this.Controls.Add(this.DepthFirstSolve);
            this.Controls.Add(this.DefaultSolve);
            this.Name = "Penzerme";
            this.Text = "Pénzérmés játék";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DefaultSolve;
        private System.Windows.Forms.Button DepthFirstSolve;
        private System.Windows.Forms.Button BreadthFirstSolve;
        private System.Windows.Forms.Button TrialError;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.Button clearButton;
    }
}

