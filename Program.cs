using testTargetSistemas.Services;

namespace test_targetSistemas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Desafio Técnico!");

            Console.WriteLine("\n--- Problema 1: Cálculo da Soma ---");
            int INDICE = 13, SOMA = 0, K = 0;
            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }
            Console.WriteLine($"O valor da variável SOMA ao final do processamento é: {SOMA}");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("2 - Verificar número na sequência de Fibonacci");
                Console.WriteLine("3 - Analisar faturamento mensal");
                Console.WriteLine("4 - Calcular percentual de representação por estado");
                Console.WriteLine("5 - Inverter uma string");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "2":
                        FibonacciService.VerificarNumeroFibonacci();
                        break;
                    case "3":
                        FaturamentoService.ResolverDesafioFaturamento();
                        break;
                    case "4":
                        FaturamentoService.CalcularPercentualEstados();
                        break;
                    case "5":
                        StringService.InverterString();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("\nObrigado por utilizar o sistema. Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}