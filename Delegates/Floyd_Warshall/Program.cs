using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] proximityMatrix = PrepareFirstState();
            Solve(ref proximityMatrix);
            Dump(proximityMatrix);
           
            Console.ReadLine();
        }

        private static void Dump(double[][] matrix)
        {
            int size = matrix.Count();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0}\t", matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void Solve(ref double[][] matrix)
        {
            int size = matrix.Count();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        matrix[j][k] = Math.Min(matrix[j][k], matrix[j][i] + matrix[i][k]);
                    }
                }
            }
        }

        private static double[][] PrepareFirstState()
        {
            double[][] matrix = new double[6][]
            {
                new double[6], 
                new double[6], 
                new double[6], 
                new double[6], 
                new double[6], 
                new double[6]
            };

            matrix[0][0] = 0;
            matrix[0][1] = 5;
            matrix[0][2] = double.PositiveInfinity;
            matrix[0][3] = double.PositiveInfinity;
            matrix[0][4] = 16;
            matrix[0][5] = 8;

            matrix[1][0] = 5;
            matrix[1][1] = 0;
            matrix[1][2] = 1;
            matrix[1][3] = double.PositiveInfinity;
            matrix[1][4] = double.PositiveInfinity;
            matrix[1][5] = 2;

            matrix[2][0] = double.PositiveInfinity;
            matrix[2][1] = 1;
            matrix[2][2] = 0;
            matrix[2][3] = 1;
            matrix[2][4] = double.PositiveInfinity;
            matrix[2][5] = 6;

            matrix[3][0] = double.PositiveInfinity;
            matrix[3][1] = double.PositiveInfinity;
            matrix[3][2] = 1;
            matrix[3][3] = 0;
            matrix[3][4] = 4;
            matrix[3][5] = 5;

            matrix[4][0] = 16;
            matrix[4][1] = double.PositiveInfinity;
            matrix[4][2] = double.PositiveInfinity;
            matrix[4][3] = 4;
            matrix[4][4] = 0;
            matrix[4][5] = 4;

            matrix[5][0] = 8;
            matrix[5][1] = 2;
            matrix[5][2] = 6;
            matrix[5][3] = 5;
            matrix[5][4] = 4;
            matrix[5][5] = 0;

            return matrix;
        }
    }
}
