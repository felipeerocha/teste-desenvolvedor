using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTargetSistemas.Services
{
    public class FibonacciService
    {
        public static void VerificarNumeroFibonacci()
        {
            Console.WriteLine("\n--- Verificar Número na Sequência de Fibonacci ---");
            Console.Write("Digite um número para verificar: ");

            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Valor inválido. Digite um número inteiro.");
                return;
            }

            var (pertence, anterior, proximo) = VerificarFibonacciComExplicacao(numero);

            if (pertence)
            {
                Console.WriteLine($"✅ O número {numero} PERTENCE à sequência de Fibonacci.");
            }
            else
            {
                Console.WriteLine($"❌ O número {numero} NÃO pertence à sequência de Fibonacci.");
                Console.WriteLine("\nExplicação:");
                Console.WriteLine($"Os números de Fibonacci mais próximos são:");
                Console.WriteLine($"- Número anterior na sequência: {anterior}");
                Console.WriteLine($"- Próximo número na sequência: {proximo}");
                Console.WriteLine($"\nA sequência segue o padrão onde cada número é a soma dos dois anteriores:");
                Console.WriteLine($"Por exemplo: {anterior} + {proximo - anterior} = {proximo}");
            }
        }

        private static (bool pertence, int anterior, int proximo) VerificarFibonacciComExplicacao(int numero)
        {
            int a = 0;
            int b = 1;

            if (numero == a) return (true, 0, 1);
            if (numero == b) return (true, 0, 1);

            int c = a + b;
            int anterior = b;

            while (c <= numero)
            {
                if (c == numero) return (true, anterior, c + anterior);

                anterior = c;
                c = a + b;
                a = b;
                b = c;
                c = a + b;
            }

            return (false, anterior, c);
        }

        public static void MostrarSequenciaAte(int limite)
        {
            Console.WriteLine($"\nSequência de Fibonacci até {limite}:");
            var sequencia = GerarSequenciaFibonacci(limite);
            Console.WriteLine(string.Join(", ", sequencia));
        }

        private static List<int> GerarSequenciaFibonacci(int limite)
        {
            var sequencia = new List<int> { 0, 1 };

            while (true)
            {
                int next = sequencia[^1] + sequencia[^2];
                if (next > limite) break;
                sequencia.Add(next);
            }

            return sequencia;
        }
    }
}
