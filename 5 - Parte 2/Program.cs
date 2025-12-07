using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        const string fileName = "input.txt";

        if (!File.Exists(fileName)) return;

        List<Intervalo> regrasDeValidade = new List<Intervalo>();

        foreach (string line in File.ReadLines(fileName))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.Contains('-'))
            {
                var partes = line.Split('-');
                var inicio = long.Parse(partes[0]);
                var fim = long.Parse(partes[1]);
                regrasDeValidade.Add(new Intervalo { Inicio = inicio, Fim = fim });
            }
        }

        if (regrasDeValidade.Count == 0)
        {
            Console.WriteLine(0);
            return;
        }

        var ordenados = regrasDeValidade.OrderBy(x => x.Inicio).ToList();
        long sum = 0;

        long inicioAtual = ordenados[0].Inicio;
        long fimAtual = ordenados[0].Fim;
        for (int i = 1; i < ordenados.Count; i++)
        {
            var proximo = ordenados[i];

            if (proximo.Inicio <= fimAtual)
            {
                fimAtual = Math.Max(fimAtual, proximo.Fim);
            }
            else
            {
                sum += (fimAtual - inicioAtual + 1);
                inicioAtual = proximo.Inicio;
                fimAtual = proximo.Fim;
            }
        }

        sum += (fimAtual - inicioAtual + 1);

        Console.WriteLine(sum);
    }
}

public class Intervalo
{
    public long Inicio { get; set; }
    public long Fim { get; set; }
}