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
            this.JatekPanel = new System.Windows.Forms.Panel();
            this.DefaultSolve = new System.Windows.Forms.Button();
            this.DepthFirstSolve = new System.Windows.Forms.Button();
            this.BreadthFirstSolve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // JatekPanel
            // 
            this.JatekPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.JatekPanel.Location = new System.Drawing.Point(51, 64);
            this.JatekPanel.Name = "JatekPanel";
            this.JatekPanel.Size = new System.Drawing.Size(400, 400);
            this.JatekPanel.TabIndex = 0;
            // 
            // DefaultSolve
            // 
            this.DefaultSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DefaultSolve.Location = new System.Drawing.Point(508, 64);
            this.DefaultSolve.Name = "DefaultSolve";
            this.DefaultSolve.Size = new System.Drawing.Size(184, 94);
            this.DefaultSolve.TabIndex = 1;
            this.DefaultSolve.Text = "BACKTRACK";
            this.DefaultSolve.UseVisualStyleBackColor = true;
            this.DefaultSolve.Click += new System.EventHandler(this.DefaultSolve_Click);
            // 
            // DepthFirstSolve
            // 
            this.DepthFirstSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DepthFirstSolve.Location = new System.Drawing.Point(508, 217);
            this.DepthFirstSolve.Name = "DepthFirstSolve";
            this.DepthFirstSolve.Size = new System.Drawing.Size(184, 93);
            this.DepthFirstSolve.TabIndex = 2;
            this.DepthFirstSolve.Text = "DEPTH FIRST";
            this.DepthFirstSolve.UseVisualStyleBackColor = true;
            this.DepthFirstSolve.Click += new System.EventHandler(this.DepthFirstSolve_Click);
            // 
            // BreadthFirstSolve
            // 
            this.BreadthFirstSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BreadthFirstSolve.Location = new System.Drawing.Point(508, 370);
            this.BreadthFirstSolve.Name = "BreadthFirstSolve";
            this.BreadthFirstSolve.Size = new System.Drawing.Size(184, 94);
            this.BreadthFirstSolve.TabIndex = 3;
            this.BreadthFirstSolve.Text = "BREADTH FIRST";
            this.BreadthFirstSolve.UseVisualStyleBackColor = true;
            this.BreadthFirstSolve.Click += new System.EventHandler(this.BreadthFirstSolve_Click);
            // 
            // Penzerme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 532);
            this.Controls.Add(this.BreadthFirstSolve);
            this.Controls.Add(this.DepthFirstSolve);
            this.Controls.Add(this.DefaultSolve);
            this.Controls.Add(this.JatekPanel);
            this.Name = "Penzerme";
            this.Text = "Pénzérmés játék";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel JatekPanel;
        private System.Windows.Forms.Button DefaultSolve;
        private System.Windows.Forms.Button DepthFirstSolve;
        private System.Windows.Forms.Button BreadthFirstSolve;
    }
}

