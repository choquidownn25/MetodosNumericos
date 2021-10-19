using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosSistemasEcuaciones
{
    public class MetodosSistemasEcuaciones
    {

        public static int nIteraciones { get; set; }

        /// <summary>
        /// Busca una aproximación a la solución de un sistema de ecuaciones nxn mediante el método Jacobi.
        /// </summary>
        /// <param name="x">Un arreglo nxn con los coeficientes de las variables</param>
        /// <param name="independientes">Un arreglo tamaño n con los términos independientes de las ecuaciones, del lado opuesto de la igualación</param>
        /// <param name="epsilon">Margen de error permitido (e.g. 0.0001)</param>
        /// <param name="iniciales">Un arreglo tamaño n con los valores para iniciar la búsqueda (opcional)</param>
        /// <returns></returns>
        public static double[] Jacobi(double[,] x, double[] independientes, double epsilon, double[] iniciales = null)
        {
            int numvars = independientes.Length;

            // TODO: Más pruebas para validar entradas
            if (iniciales != null && iniciales.Length != numvars)
            {
                throw new ArgumentException();
            }
            if (x.GetUpperBound(0) != x.GetUpperBound(1))
            {
                throw new ArgumentException();
            }

            if (iniciales == null) iniciales = new double[numvars];

            double[] prevVals = iniciales;
            double[] currVals = new double[numvars];

            nIteraciones = 0;

            bool done;
            do
            {
                done = true;

                for (int i = 0; i < numvars; i++)
                {
                    nIteraciones++;
                    double suma = independientes[i];
                    for (int j = 0; j < numvars; j++)
                    {
                        if (i == j) continue;
                        suma -= x[i, j] * prevVals[j];
                    }
                    suma /= x[i, i];
                    currVals[i] = suma;

                    if (Math.Abs((currVals[i] - prevVals[i]) / currVals[i]) > epsilon) done = false;
                }
                for (int i = 0; i < numvars; i++)
                {
                    prevVals[i] = currVals[i];
                }
            } while (!done);

            return currVals;
        }

        /// <summary>
        /// Busca una aproximación a la solución de un sistema de ecuaciones nxn mediante el método Gauss-Seidel.
        /// </summary>
        /// <param name="x">Un arreglo nxn con los coeficientes de las variables</param>
        /// <param name="independientes">Un arreglo tamaño n con los términos independientes de las ecuaciones, del lado opuesto de la igualación</param>
        /// <param name="epsilon">Margen de error permitido (e.g. 0.0001)</param>
        /// <param name="iniciales">Un arreglo tamaño n con los valores para iniciar la búsqueda (opcional)</param>
        /// <returns></returns>
        public static double[] GaussSeidel(double[,] x, double[] independientes, double epsilon, double[] iniciales = null)
        {
            int numvars = independientes.Length;

            // TODO: Más pruebas para validar entradas
            if (iniciales != null && iniciales.Length != numvars)
            {
                throw new ArgumentException();
            }
            if (x.GetUpperBound(0) != x.GetUpperBound(1))
            {
                throw new ArgumentException();
            }

            if (iniciales == null) iniciales = new double[numvars];

            double[] prevVals = new double[numvars];
            double[] currVals = iniciales;
            nIteraciones = 0;

            bool done;
            do
            {
                done = true;

                for (int i = 0; i < numvars; i++)
                {
                    nIteraciones++;
                    double suma = independientes[i];
                    for (int j = 0; j < numvars; j++)
                    {
                        if (i == j) continue;
                        suma -= x[i, j] * currVals[j];
                    }
                    suma /= x[i, i];
                    prevVals[i] = currVals[i];
                    currVals[i] = suma;

                    if (Math.Abs((currVals[i] - prevVals[i]) / currVals[i]) > epsilon) done = false;
                }
            } while (!done);



            return currVals;
        }
    }

}
