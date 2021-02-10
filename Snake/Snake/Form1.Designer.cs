namespace Snake
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Steps = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Steps
            // 
            this.Steps.AutoSize = true;
            this.Steps.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Steps.ForeColor = System.Drawing.SystemColors.Control;
            this.Steps.Location = new System.Drawing.Point(148, 2);
            this.Steps.Name = "Steps";
            this.Steps.Size = new System.Drawing.Size(37, 13);
            this.Steps.TabIndex = 2;
            this.Steps.Text = " Steps";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Score.ForeColor = System.Drawing.SystemColors.Control;
            this.Score.Location = new System.Drawing.Point(218, 2);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(41, 13);
            this.Score.TabIndex = 3;
            this.Score.Text = "Score: ";
            // 
            // PB
            // 
            this.PB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PB.Location = new System.Drawing.Point(122, 65);
            this.PB.Margin = new System.Windows.Forms.Padding(4);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(160, 160);
            this.PB.TabIndex = 4;
            this.PB.TabStop = false;
            this.PB.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(404, 321);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Steps);
            this.Controls.Add(this.PB);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.F1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Steps;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox PB;
    }
}

