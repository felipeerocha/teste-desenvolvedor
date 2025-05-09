using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTargetSistemas.Services
{
    public class StringService
    {
        public static void InverterString()
        {
            Console.WriteLine("\n--- Inversão de String ---");
            Console.Write("Digite uma string para inverter: ");
            string original = Console.ReadLine();

            string invertida = Inverter(original);

            Console.WriteLine($"String original: {original}");
            Console.WriteLine($"String invertida: {invertida}");
        }

        private static string Inverter(string str)
        {
            char[] caracteres = str.ToCharArray();
            int inicio = 0;
            int fim = str.Length - 1;

            while (inicio < fim)
            {
                char temp = caracteres[inicio];
                caracteres[inicio] = caracteres[fim];
                caracteres[fim] = temp;

                inicio++;
                fim--;
            }

            return new string(caracteres);
        }
    }
}

