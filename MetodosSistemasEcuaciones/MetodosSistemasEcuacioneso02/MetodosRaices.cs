using System;
using System.Collections.Generic;
using Funciones;
using Intervalo.Types;

namespace MetodosSistemasEcuacioneso02
{
    public class MetodosRaices
    {

        public static double ErrorAbsoluto { get; set; }
        public static double ErrorRelativo { get; set; }

        /// <summary>
        /// Busca aproximaciones de raíces de una función a través del método de bisección.
        /// Recibe un intervalo donde ocurre un cambio de signo en f(x).
        /// </summary>
        /// <param name="intervalo">El intervalo a evaluar, donde ocurre el cambio de signo</param>
        /// <param name="f">La función a evaluar</param>
        /// <param name="iterations">El número de iteraciones que se van a realizar para la aproximación</param>
        /// <returns>Una aproximación a la raíz de la función</returns>
        public static double Biseccion(Intervalo<double> intervalo, Func<double, double> f, int iterations)
        {
            var currIntervalo = new Intervalo<double>(intervalo);
            double semisuma = 0.0;

            for (int i = 0; i <= iterations; i++)
            {
                double prevSemi = semisuma;
                semisuma = (currIntervalo.inicio + currIntervalo.fin) / 2;
                if (MismoSigno(f(currIntervalo.inicio), f(semisuma)))
                {
                    currIntervalo.inicio = semisuma;
                }
                else
                {
                    currIntervalo.fin = semisuma;
                }


                // Calculamos el Error
                if (i == 0) continue;
                ErrorAbsoluto = Math.Abs(semisuma - prevSemi);
                ErrorRelativo = ErrorAbsoluto / Math.Abs(semisuma);

            }

            return semisuma;
        }

        /// <summary>
        /// Busca aproximaciones de raíces de una función a través del método de regla falsa.
        /// Recibe un intervalo donde ocurre un cambio de signo en f(x).
        /// </summary>
        /// <param name="intervalo">El intervalo a evaluar, donde ocurre el cambio de signo</param>
        /// <param name="f">La función a evaluar</param>
        /// <param name="iterations"></param>
        /// <returns>Una aproximación a la raíz de la función</returns>
        public static double ReglaFalsa(Intervalo<double> intervalo, Func<double, double> f, int iterations)
        {
            var currIntervalo = new Intervalo<double>(intervalo);
            double raizRegla = 0.0;

            for (int i = 0; i <= iterations; i++)
            {
                double PrevRaiz = raizRegla;
                double a = currIntervalo.inicio, b = currIntervalo.fin;
                raizRegla = (a * f(b) - b * f(a)) / (f(b) - f(a));
                if (MismoSigno(f(currIntervalo.inicio), f(raizRegla)))
                {
                    currIntervalo.inicio = raizRegla;
                }
                else
                {
                    currIntervalo.fin = raizRegla;
                }


                // Calculamos el Error
                if (i == 0) continue;
                ErrorAbsoluto = Math.Abs(raizRegla - PrevRaiz);
                ErrorRelativo = ErrorAbsoluto / Math.Abs(raizRegla);

            }

            return raizRegla;
        }

        /// <summary>
        /// Busca aproximaciones de raíces de una función a través del método de secante.
        /// Recibe un intervalo donde ocurre un cambio de signo en f(x).
        /// </summary>
        /// <param name="intervalo">El intervalo a evaluar, donde ocurre el cambio de signo</param>
        /// <param name="f">La función a evaluar</param>
        /// <param name="iterations">El número de iteraciones que se van a realizar para la aproximación</param>
        /// <returns>Una aproximación a la raíz de la función</returns>
        public static double Secante(Intervalo<double> intervalo, Func<double, double> f, int iterations)
        {
            double raiz = intervalo.fin, raizAnt = intervalo.inicio;

            for (int i = 2; i <= iterations; i++)
            {
                if (f(raiz) - f(raizAnt) == 0) break;
                double raizNueva = raiz - (f(raiz) * (raiz - raizAnt)) / (f(raiz) - f(raizAnt));
                raizAnt = raiz;
                raiz = raizNueva;

                ErrorAbsoluto = Math.Abs(raiz - raizAnt);
                ErrorRelativo = ErrorAbsoluto / Math.Abs(raiz);
            }

            return raiz;

        }

        /// <summary>
        /// Busca aproximaciones de raíces de una función a través del método de Newton-Raphson.
        /// Recibe un valor inicial de x para comenzar el cálculo.
        /// </summary>
        /// <param name="f">La función a evaluar</param>
        /// <param name="x0">El valor inicial de x</param>
        /// <param name="iterations">El número de iteraciones a realizar para la aproximación</param>
        /// <returns>Una aproximación a la raíz de la función</returns>
        public static double NewtonRaphson(Func<double, double> f, double x0, int iterations)
        {
            double raiz = x0;

            for (int i = 1; i <= iterations; i++)
            {
                double raizAnt = raiz;

                raiz -= f(raiz) / Calculo.Derivar(f, raiz);

                ErrorAbsoluto = Math.Abs(raiz - raizAnt);
                ErrorRelativo = ErrorAbsoluto / Math.Abs(raiz);
            }

            return raiz;
        }

        /// <summary>
        /// Cambia los valores de 2 variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        static void Swap<T>(ref T var1, ref T var2)
        {
            T tmp = var1;
            var1 = var2;
            var2 = tmp;
        }

        /// <summary>
        /// Verifica si 2 variables tienen el mismo signo
        /// </summary>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        /// <returns>true si tienen el mismo signo, false si no</returns>
        static bool MismoSigno(double var1, double var2)
        {
            return (var1 < 0 && var2 < 0) || (var1 > 0 && var2 > 0) ? true : false;
        }

        /// <summary>
        /// Tabula una función y encuentra los intervalos donde hay un cambio de signo en f(x)
        /// </summary>
        /// <param name="inicio">Valor de x donde se iniciará la búsqueda</param>
        /// <param name="fin">Valor de x donde se terminará la búsqueda</param>
        /// <param name="step">El incremento de x para la tabulación</param>
        /// <param name="f">La función a evaluar</param>
        /// <returns></returns>
        public static List<Intervalo<double>> BuscarIntervalos(double inicio, double fin, double step, Func<double, double> f)
        {
            var intervalos = new List<Intervalo<double>>();

            if (inicio > fin)
            {
                Swap(ref inicio, ref fin);
            }

            // Colocar el f(x) con la x anterior para comparar con la actual
            double prevF = f(inicio);
            double currX = inicio;
            while (currX <= fin)
            {
                double currF = f(currX);
                if (!MismoSigno(currF, prevF))
                {
                    // Si hubo un cambio de signo, agregar el intervalo a la lista
                    intervalos.Add(new Intervalo<double>(currX - step, currX));
                }
                prevF = currF;
                currX += step;
            }


            return intervalos;
        }
    }
}
