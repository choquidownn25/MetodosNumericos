using Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosSistemasEcuacioneso02
{
    public class MetodosSistemasEcuaciones
    {
        public static int nIteraciones { get; set; }
        private static string linea, lineaVector, nColumana, nFila, nVector, xx0, xx1,  netownmT;
        private static int columna, fila, ultimoColumna, ultimoFila, EjeX, DivisionSimetrica;
        private static double[,] matriz;
        private static double[] a;
        private static double[] b;

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
        /// <summary>
        /// Metodo de la secante
        /// </summary>
        /// <param name="x0">Primer Valor</param>
        /// <param name="x1">Segundo Valor</param>
        /// <returns></returns>
        public static double Secante(double x0, double x1)
        {
            Console.WriteLine("\n=== Secante ===");
            double tolerancia = 0.000000001;

            double x2, Ea;
            Ea = tolerancia + 1;

            int i = 2,
            iteracion = 0,
            max = 98;
            x2 = 0;
            while (Ea > tolerancia)
            {
                x2 = x1 - ((f(x1) * (x0 - x1)) / (f(x0) - f(x1)));
                Console.WriteLine("x = "+ i+ x2+"\n");
                Ea = (Math.Abs(x1 - x2));
                x0 = x1;
                x1 = x2;
                i++;
                iteracion++;
                if (iteracion > max)
                {  // Se sobrepasó la máxima cantidad de iteraciones permitidas
                    Console.WriteLine("\nSe sobrepasó la máxima cantidad de iteraciones permitidas\n\n");
                    return 0;
                }
            }
            Console.WriteLine("La raiz es : " + x2);
            return x2;

        }
        /// <summary>
        /// Funcion
        /// </summary>
        /// <param name="x">Eje x</param>
        /// <returns></returns>
        public static double  f(double x)
        {
            return Math.Pow(x, 3) + 5; // funcion x^3 + 5
        }
    
        /// <summary>
        /// Funcion calcular Polinomios
        /// </summary>
        /// <param name="cuantosValoresA">Valor A</param>
        /// <param name="valorDivisionSimetrica">Valor Divicion Simetrica</param>
        /// <param name=""></param>
        /// <returns></returns>
        public static double CalcularEvalucionPolinomios(string valorDivisionSimetricab)
        {
           

            Console.WriteLine("Cuantas Filas!");
            nFila = Console.ReadLine();
            ultimoFila = int.Parse(nFila);

            Console.WriteLine("Cuantas Derivadas!");
            nColumana = Console.ReadLine();
            EjeX = int.Parse(nColumana);
            a = new double[ultimoFila];
           
            Console.WriteLine("Valor Division Simetrica !");
      
            DivisionSimetrica = int.Parse(valorDivisionSimetricab);

            for (fila = 0; fila < ultimoFila; fila++)
            {
               
                    Console.WriteLine("Escriba Posicion [" + (fila + 1) +  "]");
                    linea = Console.ReadLine();
                    a[fila] = double.Parse(linea);
               
            }
            for (fila = 0; fila < ultimoFila; fila++)
            {
               
                    Console.WriteLine("La Matiz es; " + a[fila]);
              
            }
            double resEvaluaPolinomio = Calculo.EvaluaPolinomio(a, EjeX);
            double resEvaluaDerivada = Calculo.EvaluaDerivada(a, EjeX);
            b = new double[a.Length];
            double resDivisionSintetica = Calculo.DivisionSintetica(a, b, EjeX);

            return resEvaluaPolinomio + resEvaluaDerivada + resDivisionSintetica;
        }

        public static  void Muller(double x0 , double x1 , double x2 )
        {

            ///double x0 = 4.5, x1 = 5.5, x2 = 5.0, x3;
            double x3;
            double h0, h1, d0, d1, A, B, C;
            double den, raiz;
            do
            {
                h0 = x1 - x0;
                h1 = x2 - x1;
                d0 = (FuncionMuller(x1) - FuncionMuller(x0)) / h0;
                d1 = (FuncionMuller(x2) - FuncionMuller(x1)) / h1;
                A = (d1 - d0) / (h1 + h0);
                B = A * h1 + d1;
                C = FuncionMuller(x2);
                raiz = Math.Sqrt(B * B - 4.0 * A * C);
                if (Math.Abs(B + raiz) > Math.Abs(B - raiz))
                    den = B + raiz;
                else
                    den = B - raiz;
                x3 = x2 - 2 * C / den;
                Console.WriteLine(" x = " + x3 + " " + f(x3));
                x0 = x1;
                x1 = x2;
                x2 = x3;
            } while (Math.Abs(f(x3)) > 0.000001);

        }
        /// <summary>
        /// Funcion Muller
        /// </summary>
        /// <param name="x">Eje x</param>
        /// <returns></returns>
        public static double FuncionMuller(double x)
        {
            return (x * x * x - 13 * x - 12);
        }

    }
}
