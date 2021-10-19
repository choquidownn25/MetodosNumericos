using System;
using Funciones;
using Intervalo.Types;

namespace MetodosSistemasEcuacioneso02
{
    class Program
    {
        private static string linea, lineaVector, nColumana, nFila, nVector, xx0, xx1, EjeX, netownmT;
        private static int columna, fila, ultimoColumna, ultimoFila, ultimoVector;
        private static double[,] matriz;
        private static double[] independientes;
        private static double resultadoSecante;
        private static double x0, x1, newtonrasonEjeX, newtonrasonT;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            Console.WriteLine("Cuantas Filas!");
            nFila = Console.ReadLine();
            ultimoFila = int.Parse(nFila);

            Console.WriteLine("Cuantas Columnas!");
            nColumana = Console.ReadLine();
            ultimoColumna = int.Parse(nColumana);
            matriz = new double[ultimoFila, ultimoColumna];
            for (fila = 0; fila < ultimoFila; fila++)
            {
                for (columna = 0; columna < ultimoColumna; columna++)
                {
                    Console.WriteLine("Escriva Posicion [" + (fila + 1) + " , " + (columna + 1) + "]");
                    linea = Console.ReadLine();
                    matriz[fila, columna] = double.Parse(linea);
                }
            }
            for (fila = 0; fila < ultimoFila; fila++)
            {
                for (columna = 0; columna < ultimoColumna; columna++)
                {
                    Console.WriteLine("La Matiz es; " + matriz[fila, columna]);
                }
            }

            Console.WriteLine("Cuantas Vector!");
            nVector = Console.ReadLine();
            ultimoVector = int.Parse(nVector);
            independientes = new double[ultimoVector];
            for (int i = 0; i < ultimoVector; i++)
            {
               
                    Console.WriteLine("Escriva Posicion [" + (i + 1) + "]");
                    lineaVector = Console.ReadLine();
                    
                    independientes[i] = double.Parse(lineaVector);
               
            }

            for (fila = 0; fila < ultimoVector; fila++)
            {
                    Console.WriteLine("El vector  es; " + independientes[fila]);                
            }

            Console.WriteLine("Valor Secante x0!");
            xx0 = Console.ReadLine();
            x0 = int.Parse(xx0);

            Console.WriteLine("Valor Secante x1!");
            xx1 = Console.ReadLine();
            x1 = int.Parse(xx1);


            Console.WriteLine("Netown Rason Eje  x!");
            EjeX = Console.ReadLine();
            newtonrasonEjeX = int.Parse(EjeX);

            Console.WriteLine("Valor Newton Rason x1!");
            netownmT = Console.ReadLine();
            newtonrasonT = int.Parse(netownmT);

            Raices();
            Lineales(matriz, independientes);
            CalculoNumerico();
            CalculoSecante(x0, x1);
            CalcularNetwonRason(newtonrasonEjeX, newtonrasonT);
            CalcularEvalucionPolinomios();
            CalcularMuller();
        }

        private static void CalcularMuller()
        {
            double x0 = 4.5, x1 = 5.5, x2 = 5.0;
            string xx0, xx1, xx2;
            Console.WriteLine("Valor Calcular Muller x0!");
            xx0 = Console.ReadLine();
            x0 = double.Parse(xx0);

            Console.WriteLine("Valor Calcular Muller x1!");
            xx1 = Console.ReadLine();
            x1 = double.Parse(xx1);

            Console.WriteLine("Valor Calcular Muller x2!");
            xx2 = Console.ReadLine();
            x2 = double.Parse(xx2);
            MetodosSistemasEcuaciones.Muller(x0,x1, x2);


        }

        private static void CalcularEvalucionPolinomios()
        {
            Console.WriteLine("==== Calcular Evalucion Polinomios =====");
            Console.WriteLine(" Ingresar valor a evaluar ");
            string valorDivisionSimetricab = Console.ReadLine();
            MetodosSistemasEcuaciones.CalcularEvalucionPolinomios(valorDivisionSimetricab);
        }

        private static void CalcularNetwonRason(double EjeX, double netownmT)
        {
            Console.WriteLine("\n=== Newton Raphson ===");
            // double resI = Calculo.IntegrarRect(Funciones.Funciones.FuncRaizConCubo, new Intervalo<double>(0, 2), 4);
            double resI = Calculo.Newton_Raphson(EjeX, netownmT);
           Console.WriteLine($"Resultado Newton Raphson: {resI}");
        }

        private static void CalculoSecante(double x0, double x1)
        {
            resultadoSecante = MetodosSistemasEcuaciones.Secante(x0, x1);
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

        static void Lineales(double[,] input, double[] independientes)
        {
            
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
