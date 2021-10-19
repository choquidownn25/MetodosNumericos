using Intervalo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    public class Calculo
    {
        /// <summary>
        /// El valor pequeño usado para derivar (el valor que tiene a cero)
        /// </summary>
        public static double H { get; } = Math.Pow(10, -10);

        /// <summary>
        /// Calcula la derivada de una función en un punto mediante una aproximación a la definición de derivada.
        /// Utiliza la propiedad H.
        /// </summary>
        /// <param name="f">La función a derivar</param>
        /// <param name="val">El valor en el que se evalúa la derivada</param>
        /// <returns>Una aproximación a la derivada</returns>
        public static double Derivar(Func<double, double> f, double val)
        {

            return (f(val + H) - f(val)) / H;
        }

        /// <summary>
        /// Calcula la integral definida de una función en un intervalo mediante una aproximación por el método
        /// de Newton-Cotes por rectángulos.
        /// </summary>
        /// <param name="f">La función a integrar</param>
        /// <param name="intervalo">El intervalo de evaluación</param>
        /// <param name="numIntervalos">La cantidad de intervalos en los que se dividirá la función</param>
        /// <returns>Una aproximación a la integral</returns>
        public static double IntegrarRect(Func<double, double> f, Intervalo<double> intervalo, int numIntervalos)
        {
            double delta = Math.Abs(intervalo.fin - intervalo.inicio) / numIntervalos;
            double x0 = intervalo.inicio;
            double x1 = x0 + delta;

            double suma = 0;

            while (x1 <= intervalo.fin)
            {
                suma += f(x0);
                x0 = x1;
                x1 += delta;
            }
            return delta * suma;
        }

        /// <summary>
        /// Metodo Neton Rapson
        /// </summary>
        /// <param name="x0">Para eje x</param>
        /// <param name="T">Parametro</param>
        /// <returns></returns>
        public static double Newton_Raphson(double x0, double T)
        {
            int i = 0;
            double x = x0;
            while (Math.Abs(f(x)) > T)
            {
                x = x - f(x) / df(x);
            }
            return x;
        }
        /// <summary>
        /// Funcion 
        /// </summary>
        /// <param name="x">Eje x</param>
        /// <returns></returns>
        public static double f(double x)
        {
            return (x * x * x - 5.0 * x * x + 7.0 * x - 3.0);
        }
        /// <summary>
        /// Funcion diferencial
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double df(double x)
        {
            return (3.0 * x * x - 10.0 * x + 7.0);
        }
        /// <summary>
        /// Derivada de la funcion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ddf(double x)
        {
            return (6.0 * x - 10.0);
        }

        /// <summary>
        /// Evaluar Polinomio
        /// </summary>
        /// <param name="a">Array A</param>
        /// <param name="x">Eje x</param>
        /// <returns></returns>
        public static double EvaluaPolinomio(double [] a, double x)
        {
            int n = a.Length, i;
            double p = 0;
            for (i = n - 1; i >= 0; i--)
                p = p * x + a[i];
            return p;
        }
        /// <summary>
        /// Evaluar la derivada de la funcion
        /// </summary>
        /// <param name="a">Array</param>
        /// <param name="x">Eje x</param>
        /// <returns></returns>
        public static double EvaluaDerivada(double [] a, double x)
        {

            int n = a.Length, i;
            double df = 0;
            for (i = n - 2; i >= 0; i--)
                df = df * x + a[i + 1] * (i + 1);
            return df;
        }
        /// <summary>
        /// Division Sintetica
        /// </summary>
        /// <param name="a">Valores a</param>
        /// <param name="b">Valores b</param>
        /// <param name="s">Valor s</param>
        /// <returns></returns>
        public static double DivisionSintetica(double [] a, double [] b, double s)
        {
            int n = a.Length;
            b[n - 1] = a[n - 1];
            for (int i = n - 2; i >= 0; i--)
                b[i] = a[i] - b[i + 1] * s;
            for (int i = n - 1; i > 0; i--)
                Console.WriteLine(b[i] + " ");
                Console.WriteLine("residuo = " + b[0]);
            return b.Length;
        }
    }
}
