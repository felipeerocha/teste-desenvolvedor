using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using testTargetSistemas.Models;

namespace testTargetSistemas.Services
{
    public class FaturamentoService
    {
        public static void ResolverDesafioFaturamento()
        {
            Console.WriteLine("\n--- Análise de Faturamento ---");

            var faturamento = CarregarFaturamentoJson();
            AnalisarFaturamento(faturamento);
        }

        public static void CalcularPercentualEstados()
        {
            Console.WriteLine("\n--- Percentual de Representação por Estado ---");

            var estados = new List<EstadoFaturamento>
            {
                new EstadoFaturamento { Sigla = "SP", Valor = 67836.43M },
                new EstadoFaturamento { Sigla = "RJ", Valor = 36678.66M },
                new EstadoFaturamento { Sigla = "MG", Valor = 29229.88M },
                new EstadoFaturamento { Sigla = "ES", Valor = 27165.48M },
                new EstadoFaturamento { Sigla = "Outros", Valor = 19849.53M }
            };

            decimal total = estados.Sum(e => e.Valor);

            foreach (var estado in estados)
            {
                decimal percentual = (estado.Valor / total) * 100;
                Console.WriteLine($"{estado.Sigla}: {percentual.ToString("F2")}%");
            }
        }

        private static List<FaturamentoDiario> CarregarFaturamentoJson()
        {
            try
            {
                string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "dados.json");

                if (!File.Exists(jsonPath))
                {
                    Console.WriteLine("Arquivo JSON não encontrado na pasta Data.");
                    return new List<FaturamentoDiario>();
                }

                string json = File.ReadAllText(jsonPath);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json, options);

                if (result == null)
                {
                    Console.WriteLine("O arquivo JSON não contém dados válidos.");
                    return new List<FaturamentoDiario>();
                }

                return result;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Erro ao ler o JSON: {jsonEx.Message}");
                return new List<FaturamentoDiario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return new List<FaturamentoDiario>();
            }
        }

        private static void AnalisarFaturamento(List<FaturamentoDiario> faturamento)
        {
            if (faturamento == null || !faturamento.Any())
            {
                Console.WriteLine("Nenhum dado de faturamento foi carregado.");
                return;
            }

            var diasComFaturamento = faturamento
                .Where(f => f.Valor > 0)
                .ToList();

            if (!diasComFaturamento.Any())
            {
                Console.WriteLine("Não há dias com faturamento positivo para análise.");
                return;
            }

            double menorValor = diasComFaturamento.Min(f => f.Valor);
            Console.WriteLine($"Menor valor de faturamento: {menorValor.ToString("F2")}");

            double maiorValor = diasComFaturamento.Max(f => f.Valor);
            Console.WriteLine($"Maior valor de faturamento: {maiorValor.ToString("F2")}");

            double media = diasComFaturamento.Average(f => f.Valor);
            Console.WriteLine($"Média mensal (dias úteis): {media.ToString("F2")}");

            int diasAcimaMedia = diasComFaturamento.Count(f => f.Valor > media);
            Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");

            Console.WriteLine($"\nResumo:");
            Console.WriteLine($"- Total de dias no mês: {faturamento.Count}");
            Console.WriteLine($"- Dias com faturamento: {diasComFaturamento.Count}");
            Console.WriteLine($"- Dias sem faturamento: {faturamento.Count - diasComFaturamento.Count}");
        }
    }
}