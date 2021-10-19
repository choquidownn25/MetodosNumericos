using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    /// <summary>
    /// Funciones varias para probar los métodos numéricos
    /// </summary>
    public static class Funciones
    {
        /// <summary>
        /// Funcion cubica
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncCubica(double x)
        {
            return x * x * x - 6;
        }
        /// <summary>
        /// Funcion Seno
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncSin(double x)
        {
            return x * Math.Sin(x) - 1;
        }
        /// <summary>
        /// Funcion Coseno
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncCos(double x)
        {
            return x * x - Math.Cos(x);
        }
        /// <summary>
        /// Funcion Exponecial
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncExp(double x)
        {
            return Math.Pow(Math.E, x) + Math.Pow(2, -x) + 2 * Math.Cos(x) - 6;
        }
        /// <summary>
        /// Seno segundo 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncSin2(double x)
        {
            return Math.Sin(x) + x - 2;
        }
        /// <summary>
        /// Función Exponencial
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncExp2(double x)
        {
            return x * Math.Pow(Math.E, x) - 1;
        }
        /// <summary>
        /// Funcion partical
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static double FuncParticula(double t)
        {
            return 34.78 * (1 - Math.Exp(-0.54 * t));
        }
        /// <summary>
        /// Funcion Raiz Reciproca
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncRaizReciproca(double x)
        {
            return Math.Exp(-x * x / 2) / Math.Sqrt(2 * Math.PI);
        }
        /// <summary>
        /// Funcion Raiz con cubo
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double FuncRaizConCubo(double x)
        {
            return Math.Sqrt(x * x * x + 4);
        }
    }
}
