using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const long MAX = 100000000; // 10^8
        List<int> primosBase = CribaBase((int)Math.Sqrt(MAX));

        while (true)
        {
            Console.Write("Ingrese el primer número (límite inferior, 0 para salir): ");
            long a = long.Parse(Console.ReadLine());

            Console.Write("Ingrese el segundo número (límite superior, 0 para salir): ");
            long b = long.Parse(Console.ReadLine());

            // Caso de salida
            if (a == 0 && b == 0)
            {
                Console.WriteLine("No hay números primos. Programa finalizado.");
                break;
            }

            // Validaciones
            if (a < 1 || b < 1 || a > MAX || b > MAX)
            {
                Console.WriteLine($"Error: Los números deben estar entre 1 y {MAX}.");
                continue;
            }

            long inicio = Math.Min(a, b);
            long fin = Math.Max(a, b);

            int contador = ContarPrimosEnRango(inicio, fin, primosBase);

            Console.WriteLine($"En el rango [{inicio}, {fin}] hay {contador} números primos.");
        }
    }

    // Criba simple para obtener primos base hasta √n
    static List<int> CribaBase(int limite)
    {
        bool[] esPrimo = new bool[limite + 1];
        for (int i = 2; i <= limite; i++) esPrimo[i] = true;

        for (int i = 2; i * i <= limite; i++)
        {
            if (esPrimo[i])
            {
                for (int j = i * i; j <= limite; j += i)
                    esPrimo[j] = false;
            }
        }

        List<int> primos = new List<int>();
        for (int i = 2; i <= limite; i++)
            if (esPrimo[i]) primos.Add(i);

        return primos;
    }

    // Criba segmentada para contar primos en un rango grande
    static int ContarPrimosEnRango(long inicio, long fin, List<int> primosBase)
    {
        bool[] esPrimo = new bool[fin - inicio + 1];
        for (int i = 0; i < esPrimo.Length; i++) esPrimo[i] = true;

        foreach (int p in primosBase)
        {
            long mult = Math.Max((long)p * p, ((inicio + p - 1) / p) * p);

            for (long j = mult; j <= fin; j += p)
                esPrimo[j - inicio] = false;
        }

        if (inicio == 1) esPrimo[0] = false; // 1 no es primo

        int contador = 0;
        for (int i = 0; i < esPrimo.Length; i++)
            if (esPrimo[i]) contador++;

        return contador;
    }
}
