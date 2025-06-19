using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== CONSTRUÇÃO DE ÁRVORE BINÁRIA ===\n");

        // Cenário 1
        Console.WriteLine("CENÁRIO 1:");
        int[] arr1 = { 3, 2, 1, 6, 0, 5 };
        Console.WriteLine($"Array de entrada: [{string.Join(", ", arr1)}]");
        PrintArvore(arr1);
        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Cenário 2
        Console.WriteLine("CENÁRIO 2:");
        int[] arr2 = { 7, 5, 13, 9, 1, 6, 4 };
        Console.WriteLine($"Array de entrada: [{string.Join(", ", arr2)}]");
        PrintArvore(arr2);
        Console.WriteLine("\n" + new string('=', 50));
    }

    static void PrintArvore(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return;

        int max = arr.Max();
        int maxIndex = Array.IndexOf(arr, max);

        var esquerda = arr.Take(maxIndex).OrderByDescending(x => x).ToArray();
        var direita = arr.Skip(maxIndex + 1).OrderByDescending(x => x).ToArray();

        Console.WriteLine("\nEstrutura da árvore (níveis horizontais):");

        // Controle de espaços por nível
        int espacoRaiz = 20;      // Espaço antes da raiz
        int espacoInicial = 17;   // Espaço inicial para os primeiros números
        int incremento = 8;       // Quanto aumenta o espaço entre os números

        // Imprime a raiz
        Console.WriteLine(new string(' ', espacoRaiz) + max);

        // Imprime as barras da raiz
        if (esquerda.Length > 0 || direita.Length > 0)
        {
            string barras = (esquerda.Length > 0 && direita.Length > 0) ? "/   \\" :
                           (esquerda.Length > 0) ? "/" : "\\";
            Console.WriteLine(new string(' ', espacoRaiz - 1) + barras);
        }

        // Imprime os níveis seguintes
        int maxLen = Math.Max(esquerda.Length, direita.Length);
        for (int nivel = 0; nivel < maxLen; nivel++)
        {
            // Calcula os espaços para este nível (garantindo mínimo de 2 espaços)
            int espacoEsquerda = Math.Max(2, espacoInicial - (nivel * 2));
            int espacoDireita = espacoInicial + incremento + (nivel * 2);

            // Imprime os valores do nível
            string linha = "";
            
            // Valor da esquerda
            if (nivel < esquerda.Length)
            {
                linha = new string(' ', espacoEsquerda) + esquerda[nivel];
            }

            // Valor da direita
            if (nivel < direita.Length)
            {
                int espacoAteProximo = Math.Max(2, espacoDireita - linha.Length);
                linha += new string(' ', espacoAteProximo) + direita[nivel];
            }

            Console.WriteLine(linha);

            // Imprime as barras para o próximo nível
            if (nivel + 1 < maxLen)
            {
                string linhaBarras = "";
                
                // Barra da esquerda
                if (nivel + 1 < esquerda.Length)
                {
                    linhaBarras = new string(' ', espacoEsquerda) + "/";
                }

                // Barra da direita
                if (nivel + 1 < direita.Length)
                {
                    int espacoAteProximo = Math.Max(2, espacoDireita - linhaBarras.Length);
                    linhaBarras += new string(' ', espacoAteProximo) + "\\";
                }

                if (!string.IsNullOrEmpty(linhaBarras))
                    Console.WriteLine(linhaBarras);
            }
        }
    }
}
