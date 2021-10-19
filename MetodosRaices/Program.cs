using Intervalo.Types;
using System;

namespace MetodosRaices
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Raices();
            Console.ReadKey();
        }

        public static void Raices()
        {
            // Parámetros
            Func<double, double> func = Funciones.Funciones.FuncExp2;
            double inicioEval = -9, finEval = 9, step = 1;
            int iteraciones = 1000;

            // Obtenemos la tabla con los intervalos donde cambia de signo
            var intervalos = MetodosRaices.BuscarIntervalos(inicioEval, finEval, step, func);

            // Por bisección
            Console.WriteLine("\n=== Bisección ===");
            foreach (Intervalo<double> intervalo in intervalos)
            {
                double output = MetodosRaices.Biseccion(intervalo, func, iteraciones);

                Console.WriteLine($"Intervalo [{intervalo.inicio}, {intervalo.fin}]:");
                Console.WriteLine($"Aproximación: {output}, Error relativo: { MetodosRaices.ErrorRelativo }");
            }

            // Por Regla Falsa
            Console.WriteLine("\n=== Regla Falsa ===");
            foreach (Intervalo<double> intervalo in intervalos)
            {
                double output = MetodosRaices.ReglaFalsa(intervalo, func, iteraciones);

                Console.WriteLine($"Intervalo [{intervalo.inicio}, {intervalo.fin}]:");
                Console.WriteLine($"Aproximación: {output}, Error relativo: { MetodosRaices.ErrorRelativo }");
            }

            // Por Secante
            Console.WriteLine("\n=== Secante ===");
            foreach (Intervalo<double> intervalo in intervalos)
            {
                double output = MetodosRaices.Secante(intervalo, func, iteraciones);

                Console.WriteLine($"Intervalo [{intervalo.inicio}, {intervalo.fin}]:");
                Console.WriteLine($"Aproximación: {output}, Error relativo: { MetodosRaices.ErrorRelativo }");
            }

            // Por Newton-Raphson
            Console.WriteLine("\n=== Newton-Raphson ===");
            foreach (Intervalo<double> intervalo in intervalos)
            {
                double x0 = (intervalo.fin - intervalo.inicio) / 2;
                double output = MetodosRaices.NewtonRaphson(func, x0, iteraciones);

                Console.WriteLine($"x0 = {x0}:");
                Console.WriteLine($"Aproximación: {output}, Error relativo: { MetodosRaices.ErrorRelativo }");
            }
        }

    }
}
