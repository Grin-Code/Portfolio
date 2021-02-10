
namespace Facial_Recognition
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
            this.testImage = new System.Windows.Forms.PictureBox();
            this.foundImage = new System.Windows.Forms.PictureBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.traning1 = new System.Windows.Forms.PictureBox();
            this.trainningImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSetPath = new System.Windows.Forms.TextBox();
            this.SearchDataSet = new System.Windows.Forms.Button();
            this.directorylabel = new System.Windows.Forms.Label();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.displayDir = new System.Windows.Forms.TextBox();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.testImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traning1)).BeginInit();
            this.SuspendLayout();
            // 
            // testImage
            // 
            this.testImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testImage.Location = new System.Drawing.Point(85, 90);
            this.testImage.Name = "testImage";
            this.testImage.Size = new System.Drawing.Size(186, 234);
            this.testImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.testImage.TabIndex = 0;
            this.testImage.TabStop = false;
            this.testImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.testImage_DragDrop);
            this.testImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.testImage_DragEnter);
            // 
            // foundImage
            // 
            this.foundImage.Location = new System.Drawing.Point(340, 90);
            this.foundImage.Name = "foundImage";
            this.foundImage.Size = new System.Drawing.Size(186, 234);
            this.foundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.foundImage.TabIndex = 1;
            this.foundImage.TabStop = false;
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(4, 90);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 23);
            this.trainButton.TabIndex = 2;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(4, 140);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // traning1
            // 
            this.traning1.Location = new System.Drawing.Point(589, 90);
            this.traning1.Name = "traning1";
            this.traning1.Size = new System.Drawing.Size(186, 234);
            this.traning1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.traning1.TabIndex = 4;
            this.traning1.TabStop = false;
            // 
            // trainningImage
            // 
            this.trainningImage.Location = new System.Drawing.Point(599, 356);
            this.trainningImage.Name = "trainningImage";
            this.trainningImage.Size = new System.Drawing.Size(166, 23);
            this.trainningImage.TabIndex = 5;
            this.trainningImage.Text = "Display Trainning Images";
            this.trainningImage.UseVisualStyleBackColor = true;
            this.trainningImage.Click += new System.EventHandler(this.trainningImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter DataSet Path";
            // 
            // dataSetPath
            // 
            this.dataSetPath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dataSetPath.Location = new System.Drawing.Point(187, 36);
            this.dataSetPath.Name = "dataSetPath";
            this.dataSetPath.Size = new System.Drawing.Size(217, 20);
            this.dataSetPath.TabIndex = 7;
            this.dataSetPath.Text = "C:\\Users\\dylan\\Desktop\\ICT365 Supp Assesssment\\Training Set";
            this.dataSetPath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataSetPath_MouseDown);
            // 
            // SearchDataSet
            // 
            this.SearchDataSet.Location = new System.Drawing.Point(410, 36);
            this.SearchDataSet.Name = "SearchDataSet";
            this.SearchDataSet.Size = new System.Drawing.Size(77, 20);
            this.SearchDataSet.TabIndex = 8;
            this.SearchDataSet.Text = "Search";
            this.SearchDataSet.UseVisualStyleBackColor = false;
            this.SearchDataSet.Click += new System.EventHandler(this.SearchDataSet_Click);
            // 
            // directorylabel
            // 
            this.directorylabel.AutoSize = true;
            this.directorylabel.Location = new System.Drawing.Point(184, 59);
            this.directorylabel.Name = "directorylabel";
            this.directorylabel.Size = new System.Drawing.Size(0, 13);
            this.directorylabel.TabIndex = 9;
            // 
            // displayTimer
            // 
            this.displayTimer.Interval = 1000;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // displayDir
            // 
            this.displayDir.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.displayDir.Location = new System.Drawing.Point(674, 330);
            this.displayDir.Name = "displayDir";
            this.displayDir.Size = new System.Drawing.Size(26, 20);
            this.displayDir.TabIndex = 10;
            this.displayDir.Text = "S1";
            this.displayDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // searchTimer
            // 
            this.searchTimer.Interval = 50;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.displayDir);
            this.Controls.Add(this.directorylabel);
            this.Controls.Add(this.SearchDataSet);
            this.Controls.Add(this.dataSetPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trainningImage);
            this.Controls.Add(this.traning1);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.foundImage);
            this.Controls.Add(this.testImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traning1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox testImage;
        private System.Windows.Forms.PictureBox foundImage;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.PictureBox traning1;
        private System.Windows.Forms.Button trainningImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dataSetPath;
        private System.Windows.Forms.Button SearchDataSet;
        private System.Windows.Forms.Label directorylabel;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.TextBox displayDir;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

