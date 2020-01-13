using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMatrix.Model
{
    public class ModelMatrix
    {
        Matrix matrix1;
        Matrix matrix2;
        Matrix matrix3;

        int n = 100;

        Random random = new Random();

        public ModelMatrix()
        {
            matrix1 = new Matrix(100, 100);
            matrix1.ProcessFunction((x, y) => matrix1[x, y] = random.Next(0, 10));
            matrix2 = new Matrix(100, 100);
            matrix2.ProcessFunction((x, y) => matrix2[x, y] = random.Next(0, 10));
            matrix3 = new Matrix(100, 100);
        }

        public void MultiplyMatrix() => matrix3.ProcessFunction((x, y) => matrix3[x, y] = matrix1[x, y] * matrix2[x, y]);

        public Matrix Matrix1 { get => matrix1; set => matrix1 = value; }
        public Matrix Matrix2 { get => matrix2; set => matrix2 = value; }
        public Matrix Matrix3 { get => matrix3; set => matrix3 = value; }
        public int N { get => n; set => n = value; }
    }
}
