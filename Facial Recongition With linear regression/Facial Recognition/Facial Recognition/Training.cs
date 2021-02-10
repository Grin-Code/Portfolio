using System;
using System.Drawing;

namespace Facial_Recognition
{
    class Sample
    {
        //tranning images
        public Image[] trainingImg = new Image[5];
        //down image and vectorised
        //[rows,columns]
        //.GetLength(0) = rows
        //.GetLength(1) = columns
        public float[,] Xi;
        public float[,] y;
        public float[] hatyi;
    }

    class Training
    {
        public static Training Instance { get; } = new Training();
        public string trainingDir { get; set; }

        //int a = 92;
        //int b = 112;
        readonly int c = 20;
        readonly int d = 20;
        readonly int q;
        Size scd;
        private Training() 
        {
            q = c * d;
            scd.Width = c;
            scd.Height = d;           
        }

        public Sample GetSample(int i)
        {
            Sample sample1 = new Sample();
            //for (int i = 1; i <= 40; i++)
            //{
            i++;
            string file = "\\S" + i;
            string path = trainingDir + file;
            

            for (int j = 0; j < 5; j++)
            {
                sample1.trainingImg[j] = Image.FromFile(path + "\\" + (j + 1) * 2 + ".jpg");                
            }
            
            return sample1;
            //}
        }


        public Sample GetSingleSample(string dir)
        {
            Sample sample1 = new Sample();

            sample1.trainingImg[0] = Image.FromFile(dir);

            return sample1;
        }

        public Sample DisaplyImages(string path)
        {
            Sample sample = new Sample();
            for (int j = 0; j < 5; j++)
            {
                sample.trainingImg[j] = Image.FromFile(path + "\\" + (j + 1) * 2 + ".jpg");
            }
            return sample;
        }
        public float[,] DownSample(Sample sample)
        {
            float[,] Wi = new float[q, 5];
            for (int i = 0; i < 5; i++)
            {
                //down size the image to 20X20
                Bitmap img = new Bitmap(sample.trainingImg[i], scd);
                Color c;
                int max = MathMatrix.GetMax(img);
                int min = MathMatrix.GetMin(img);

                for (int k = 0; k < img.Width; k++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        c = img.GetPixel(k, j);

                        //since image is black and white RGB will all be the same value
                        int r = Convert.ToByte(c.R);
                        //normalize RGB of each pixel
                        //this is to grant full range of colour
                        r = (r - min) * (255 / (max - min));

                        //converts r to a number between 0 and 1
                        float nR = r / 255f;
                        Wi[20 * k + j, i] = nR;
                    }
                }
            }
            return Wi;
        }
        public float[,] SingleDownSample(Sample sample)
        {
            float[,] Wi = new float[q,1];
            //down size the image to 20X20
            Bitmap img = new Bitmap(sample.trainingImg[0], scd);
            Color colour;
            int max = MathMatrix.GetMax(img);
            int min = MathMatrix.GetMin(img);

            for (int k = 0; k < img.Width; k++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    colour = img.GetPixel(k, j);

                    //since image is black and white RGB will all be the same value
                    int r = Convert.ToByte(colour.R);
                    //normalize RGB of each pixel
                    //this is to grant full range of colour
                    r = (r - min) * (255 / (max - min));

                    //converts r to a number between 0 and 1
                    float nR = r / 255f;
                    Wi[20 * k + j, 0] = nR;
                }
            } 
            return Wi;
        }
       
        
        public float[] Train(Sample sample)
        {
            /*float[,] hatYi;
            float[,] Hi;
            //t is the transposed of Xi
            //Xi(Xti * Xi)^-1 * Xti  = Hi
            float[,] temp = MathMatrix.DotProduct(MathMatrix.Transpose(sample.Xi), sample.Xi);
            temp = MathMatrix.Inv(temp);            
            temp = MathMatrix.DotProduct(sample.Xi, temp);
            Hi = MathMatrix.DotProduct(temp, MathMatrix.Transpose(sample.Xi));
            hatYi = MathMatrix.DotProduct(Hi, sample.y);*/

            float[,] test = MathMatrix.DotProduct(MathMatrix.DotProduct(MathMatrix.Inv(MathMatrix.DotProduct(MathMatrix.Transpose(sample.Xi), sample.Xi)), MathMatrix.Transpose(sample.Xi)), sample.y);
            test = MathMatrix.DotProduct(sample.Xi,test);
            for (int i = 0; i < test.GetLength(0); i++)
                test[i, 0] = test[i, 0] / 100;
            return test.ToArray();
        }
    }
}
