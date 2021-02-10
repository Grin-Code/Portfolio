using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace Facial_Recognition
{
    public partial class Form1 : Form
    {
        Training Training = Training.Instance;
        Sample display = new Sample();
        Sample[] training = new Sample[40];
        Sample test = new Sample();
        string TestingDir;
        float[] d = new float[40];
        float dMin;

        public Form1()
        {
            InitializeComponent();
        }

        private void dataSetPath_MouseDown(object sender, MouseEventArgs e)
        {
            dataSetPath.Text = string.Empty;
            dataSetPath.ForeColor = Color.Black;
        }

        private void SearchDataSet_Click(object sender, EventArgs e)
        {
            string filepath = dataSetPath.Text;
            if (TestPath(filepath) && Training.trainingDir == null)
            {
                directorylabel.Text = "Training Directory Found";
                Training.trainingDir = filepath;
            }
            /*else if (TestPath(filepath) && Training.trainingDir != filepath)
            {
                directorylabel.Text = "Test Directory Found";
                TestingDir = filepath;
                display = Training.GetSample(0);
            }*/
            else
                directorylabel.Text = "Directory Dosent Exist Try Again or Being Already Being Used";
        }

        private bool TestPath(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }
        int image;
        private void trainningImage_Click(object sender, EventArgs e)
        {
            if (Training.trainingDir != null)
            {
                displayTimer.Stop();
                display = Training.DisaplyImages(Training.trainingDir + "\\" + displayDir.Text);
                traning1.Image = display.trainingImg[0];
                image = 1;
                displayTimer.Start();
            }
            else
                error();
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            if (display != null && image != 5)
            {
                traning1.Image = display.trainingImg[image];
                image ++;
            }
            if (image == 5)
            {
                displayTimer.Stop();
            }
        }
        int Class;
        int pic;
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine(d[minPos]);
            label3.Text = "Searching";
            bool imagefound = false;

            foundImage.Image = training[Class].trainingImg[pic];

            if (d[Class] == dMin)
                imagefound = true;
            

            if (imagefound)
            {
                label3.Text = "Match Found";
                Class = 0;
                searchTimer.Stop();
            }
            if (pic >= 4)
                Class++;

            if (pic == 4)
                pic = 0;
            pic++;
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            if (Training.trainingDir != null)
            {
                for (int i = 0; i < training.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        training[i] = Training.GetSample(i);
                        training[i].Xi = Training.DownSample(training[i]);
                    }
                    training[i].y = Training.SingleDownSample(training[i]);
                    training[i].hatyi = Training.Train(training[i]);
                }
                //Debug.WriteLine("image loading Complete");
                label2.Text = "Training Completed";
            }
            else
                error();
        }

        private void error()
        {
            directorylabel.Text = "Training directory hasn't been inputted into the system";
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (training[0] != null && TestingDir != null)
            {
                float[,] yqx1;
                testImage.Image = Image.FromFile(TestingDir);
                yqx1 = Training.SingleDownSample(Training.GetSingleSample(TestingDir));
                GetDistance(yqx1.ToArray());
                Class = 0;
                pic = 0;
                dMin = d.Min();
                searchTimer.Start();
            }
            else
                label2.Text = "Training must be done before testing";
        }

        private void GetDistance(float[] y)
        {
            //di(y) = ||y-hatyi||2
            for(int i = 0; i < d.Length; i++)
            {
                //Debug.WriteLine(training[i].hatyi);
                d[i] = y.EuclideanDistance(training[i].hatyi);
                //Debug.WriteLine(d[i]);
            }
            //Debug.WriteLine(" ");
        }

        private void testImage_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if(data != null)
            {                
                var file = data as string[];
                TestingDir = file[0];
                //Debug.WriteLine(TestingDir);
                if (file.Length > 0)
                {
                    testImage.Image = Image.FromFile(file[0]);
                }
            }
        }

        private void testImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testImage.AllowDrop = true;
        }
    }
}
