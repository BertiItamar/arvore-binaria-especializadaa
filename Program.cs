using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== CONSTRUÇÃO DE ÁRVORE BINÁRIA ===\n");

        // Cenário 1
        Console.WriteLine("CENÁRIO 1:");
        int[] arranjo1 = { 3, 2, 1, 6, 0, 5 };
        Console.WriteLine($"Array de entrada: [{string.Join(", ", arranjo1)}]");
        ImprimirArvore(arranjo1);
        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Cenário 2
        Console.WriteLine("CENÁRIO 2:");
        int[] arranjo2 = { 7, 5, 13, 9, 1, 6, 4 };
        Console.WriteLine($"Array de entrada: [{string.Join(", ", arranjo2)}]");
        ImprimirArvore(arranjo2);
        Console.WriteLine("\n" + new string('=', 50));
    }

    static void ImprimirArvore(int[] arranjo)
    {
        if (arranjo == null || arranjo.Length == 0)
            return;

        var dadosArvore = ObterDadosArvore(arranjo);
        Console.WriteLine("\nEstrutura da árvore (níveis horizontais):");
        
        ImprimirRaiz(dadosArvore.raiz, dadosArvore.espacoRaiz);
        ImprimirBarrasRaiz(dadosArvore.temFilhoEsquerda, dadosArvore.temFilhoDireita, dadosArvore.espacoRaiz);
        ImprimirNiveis(dadosArvore.elementosEsquerda, dadosArvore.elementosDireita);
    }

    static (int raiz, int[] elementosEsquerda, int[] elementosDireita, bool temFilhoEsquerda, bool temFilhoDireita, int espacoRaiz) ObterDadosArvore(int[] arranjo)
    {
        int raiz = arranjo.Max();
        int indiceRaiz = Array.IndexOf(arranjo, raiz);
        
        var elementosEsquerda = arranjo.Take(indiceRaiz).OrderByDescending(x => x).ToArray();
        var elementosDireita = arranjo.Skip(indiceRaiz + 1).OrderByDescending(x => x).ToArray();

        return (
            raiz: raiz,
            elementosEsquerda: elementosEsquerda,
            elementosDireita: elementosDireita,
            temFilhoEsquerda: elementosEsquerda.Length > 0,
            temFilhoDireita: elementosDireita.Length > 0,
            espacoRaiz: 20
        );
    }

    static void ImprimirRaiz(int valorRaiz, int espacoRaiz)
    {
        Console.WriteLine(new string(' ', espacoRaiz) + valorRaiz);
    }

    static void ImprimirBarrasRaiz(bool temFilhoEsquerda, bool temFilhoDireita, int espacoRaiz)
    {
        if (temFilhoEsquerda || temFilhoDireita)
        {
            string barras = (temFilhoEsquerda && temFilhoDireita) ? "/   \\" :
                           temFilhoEsquerda ? "/" : "\\";
            Console.WriteLine(new string(' ', espacoRaiz - 1) + barras);
        }
    }

    static void ImprimirNiveis(int[] elementosEsquerda, int[] elementosDireita)
    {
        int espacoInicial = 17;   // Espaço inicial para os primeiros números
        int incremento = 8;       // Quanto aumenta o espaço entre os números
        int maxNiveis = Math.Max(elementosEsquerda.Length, elementosDireita.Length);

        for (int nivel = 0; nivel < maxNiveis; nivel++)
        {
            int espacoEsquerda = Math.Max(2, espacoInicial - (nivel * 2));
            int espacoDireita = espacoInicial + incremento + (nivel * 2);

            ImprimirNivel(nivel, espacoEsquerda, espacoDireita, elementosEsquerda, elementosDireita);
            ImprimirBarrasNivel(nivel, maxNiveis, espacoEsquerda, espacoDireita, elementosEsquerda, elementosDireita);
        }
    }

    static void ImprimirNivel(int nivel, int espacoEsquerda, int espacoDireita, int[] elementosEsquerda, int[] elementosDireita)
    {
        string linha = "";
            
        // Valor da esquerda
        if (nivel < elementosEsquerda.Length)
        {
            linha = new string(' ', espacoEsquerda) + elementosEsquerda[nivel];
        }

        // Valor da direita
        if (nivel < elementosDireita.Length)
        {
            int espacoAteProximo = Math.Max(2, espacoDireita - linha.Length);
            linha += new string(' ', espacoAteProximo) + elementosDireita[nivel];
        }

        Console.WriteLine(linha);
    }

    static void ImprimirBarrasNivel(int nivel, int maxNiveis, int espacoEsquerda, int espacoDireita, int[] elementosEsquerda, int[] elementosDireita)
    {
        if (nivel + 1 < maxNiveis)
        {
            string linhaBarras = "";
                
            // Barra da esquerda
            if (nivel + 1 < elementosEsquerda.Length)
            {
                linhaBarras = new string(' ', espacoEsquerda) + "/";
            }

            // Barra da direita
            if (nivel + 1 < elementosDireita.Length)
            {
                int espacoAteProximo = Math.Max(2, espacoDireita - linhaBarras.Length);
                linhaBarras += new string(' ', espacoAteProximo) + "\\";
            }

            if (!string.IsNullOrEmpty(linhaBarras))
                Console.WriteLine(linhaBarras);
        }
    }
}
