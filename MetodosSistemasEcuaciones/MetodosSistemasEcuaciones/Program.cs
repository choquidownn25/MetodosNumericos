using Funciones;
using Intervalo.Types;
using System;

namespace MetodosSistemasEcuaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Raices();
            Lineales();
            CalculoNumerico();
        }

        static void Raices()
        {
            // Parámetros
            Func<double, double> func = Funciones.Funciones.FuncExp2;
            double inicioEval = -3, finEval = 3, step = 1;
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

        static void Lineales()
        {
            double[,] input = {
                { 10, 3, -1 },
                { 1, -15, 2 },
                { -1, 3, 20 },
            };
            double[] independientes = { 4, -8, 10 };
            double epsilon = 0.000;
            double[] iniciales = null, resultados;

            // Jacobi

            resultados = MetodosSistemasEcuaciones.Jacobi(input, independientes, epsilon, iniciales);

            Console.WriteLine("\n=== Jacobi ===");
            for (int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine($"x{i + 1}: {resultados[i]}");
            }
            Console.WriteLine($"\nResuelto en {MetodosSistemasEcuaciones.nIteraciones} iteraciones");


            // Gauss-Seidel 

            resultados = MetodosSistemasEcuaciones.GaussSeidel(input, independientes, epsilon, iniciales);

            Console.WriteLine("\n=== Gauss-Seidel ===");
            for (int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine($"x{i + 1}: {resultados[i]}");
            }
            Console.WriteLine($"\nResuelto en {MetodosSistemasEcuaciones.nIteraciones} iteraciones");

        }

        static void CalculoNumerico()
        {
            Console.WriteLine("\n=== Diferenciación e integración numérica ===");

            double resD = Calculo.Derivar(Funciones.Funciones.FuncParticula, 5);
            Console.WriteLine($"Derivada: {resD}");

            double resI = Calculo.IntegrarRect(Funciones.Funciones.FuncRaizConCubo, new Intervalo<double>(0, 2), 4);
            Console.WriteLine($"Integral: {resI}");
        }
    
    
    }
}
