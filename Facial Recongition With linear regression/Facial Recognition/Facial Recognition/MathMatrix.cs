using System;
using System.Linq;
using System.Drawing;

namespace Facial_Recognition
{
    public static class MathMatrix
    {
        public static float[,] Inv(float[,] A)
        {
            int n = A.GetLength(0);
            float[,] result = A.Copy();

            int[] perm;
            int toggle;
            float[,] lum = Decompose(A, out perm, out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            float[] b = new float[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0f;
                    else
                        b[j] = 0.0f;
                }

                float[] x = HelperSolve(lum, b); // 

                for (int j = 0; j < n; ++j)
                {
                    result[j, i] = x[j];
                }

            }
            return result;
            //inverse Matrix
        }

        static float[] HelperSolve(float[,] luMatrix, float[] b)
        {
            int n = luMatrix.GetLength(0);
            float[] x = new float[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                float sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i, j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1, n - 1];
            for (int i = n - 2; i > 0; --i)
            {
                float sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i, j] * x[j];
                x[i] = sum / luMatrix[i, i];
            }

            return x;
        }

        static float[,] Copy(this float[,] matrix)
        {
            //allocates/creates a duplicate of a matrix.
            float[,] result = new float[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i) //copy the values
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    result[i, j] = matrix[i, j];
            return result;
        }

        static float[,] Decompose(float[,] matrix, out int[] perm, out int toggle)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1); //assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows;
            float[,] result = matrix.Copy();
            perm = new int[n]; //set up row permutation result
            for (int i = 0; i < n; ++i)
            {
                perm[i] = i;
            }
            toggle = 1; //toggle tracks row swaps.
            for (int j = 0; j < n - 1; ++j) //each column
            {
                float colMax = Math.Abs(result[j, j]); //find largest val in col
                int pRow = j;

                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i, j]) > colMax)
                    {
                        colMax = Math.Abs(result[i, j]);
                        pRow = i;
                    }
                }

                if (pRow != j)
                {
                    float[] rowPtr = result.GetRow(pRow);
                    result.ReplaceRow(pRow, result.GetRow(j));
                    result.ReplaceRow(j, rowPtr);

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle;
                }
                if (result[j, j] == 0.0)
                {
                    //find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row > n; ++row)
                    {
                        if (result[row, j] != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    //swap rows so 0.0 no longer on diagonal
                    float[] rowPtr = result.GetRow(goodRow);
                    result.ReplaceRow(goodRow, result.GetRow(j));
                    result.ReplaceRow(j, rowPtr);
                    int tmp = perm[goodRow];
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle;
                }

                for (int i = j + 1; i < n; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }
            }
            return result;
        }
        public static float[,] ReplaceRow(this float[,] matrix, int row, float[] nRow)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = nRow[i];
            }
            return matrix;
        }
        public static float[,] ReplaceColumn(this float[,] matrix, int column, float[] nColumn)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[i, column] = nColumn[i];
            }
            return matrix;
        }
        public static float[] GetRow(this float[,] matrix, int rownumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[rownumber, x]).ToArray();
        }
        public static float[] GetColumn(this float[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[x, columnNumber]).ToArray();
        }

        public static float[,] Transpose(this float[,] T)
        {
            var results = new float[T.GetLength(1), T.GetLength(0)];
            for (int r = 0; r < T.GetLength(0); r++)
            {
                for (int c = 0; c < T.GetLength(1); c++)
                {
                    results[c, r] = T[r, c];
                }
            }

            return results;
        }
        public static float[,] DotProduct(float[,] a, float[,] b)
        {

            if (a.GetLength(1) != b.GetLength(0))
            {
                throw new Exception("Fist matrix rows are not equal to second matrix");
            }
            //Debug.WriteLine(a.GetLength(1)+","+ b.GetLength(0));
            float[,] ab = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < ab.GetLength(0); i++) {
                for (int j = 0; j < ab.GetLength(1); j++)
                {
                    float product = 0;

                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        product += a[i, k] * b[k, j];
                    }

                    ab[i, j] = product;
                }
            }

            return ab;
        }
        public static float EuclideanDistance(this float[] a, float[] b)
        {
            var results = new float();
            for(int i =0; i < a.Length; i++)
            {
                results += (float)Math.Pow((a[i] - b[i]), 2);
            }
           
            results = (float)Math.Sqrt(results);
            
            return results;
        }
        public static float[] ToArray(this float[,] a)
        {
            var results = new float[a.GetLength(0)];
            for(int i=0; i < results.Length; i++)
            {
                results[i] = a[i,0];
            }
            return results;
        }
        public static float Distance(float[] x, float[] y) => (float) Math.Sqrt(x.Zip(y, (a, b) => (a - b)*(a-b)).Sum());

        public static float[,] Subtrack(this float[,] a, float[,] b)
        {
            if (a.GetLength(0) != b.GetLength(1)|| a.GetLength(1) != b.GetLength(0))
                throw new ArgumentException("Dimensions of matrices must be the same");
            var results = new float[a.GetLength(0), a.GetLength(1)];

            for(int i =0; i< a.GetLength(0); i++)
            {
                for(int j =0; j<a.GetLength(1); j++)
                {
                    results[i, j] = a[i, j] - b[i, j];
                }
            }
            return results;
        }

        public static int GetMin(Bitmap img)
        {
            int min = int.MaxValue;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    int r = c.R;
                    if (r < min)
                        min = r;
                }
            }
            return min;
        }
        public static int GetMax(Bitmap img)
        {
            int max = int.MinValue;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    int r = c.R;
                    if (r > max)
                        max = r;
                }
            }
            return max;
        }
    }
}
