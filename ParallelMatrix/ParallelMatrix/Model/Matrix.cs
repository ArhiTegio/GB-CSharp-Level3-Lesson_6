using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMatrix.Model
{
    public class Matrix
    {
        public double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }

        public double this[int m, int n]
        {
            get { return data[m, n]; }
            set 
            { 
                data[m, n] = value; 

            }
        }

        public void ProcessFunction(Action<int, int> func) => Parallel.For(0, M, i => { for (var j = 0; j < N; j++) func(i, j); });
    }
}