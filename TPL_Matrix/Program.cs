using System;
using System.Threading.Tasks;
using System.Threading;

namespace TPL_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] matrix1 = new int[100, 100];
            int[,] matrix2 = new int[100, 100];
            int[,] matrix3 = new int[100, 100];

            for (int i = 0; i < matrix1.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix1.GetUpperBound(1) + 1; j++)
                {
                    matrix1[i, j] = rand.Next(0, 10);
                    matrix2[i, j] = rand.Next(0, 10);
                }
            }
            Parallel.For(0, 100, x =>
            {
                for (int j = 0; j < matrix1.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k < matrix1.GetUpperBound(1) + 1; k++)
                    {
                        matrix3[x, j] += matrix1[x, k] * matrix2[k, j];
                    }
                }
                Console.WriteLine($"This method working in thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
