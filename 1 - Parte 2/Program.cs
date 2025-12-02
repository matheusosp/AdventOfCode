using System;
using System.IO;

const string nomeArquivo = "input2.txt";
const int tamanhoMostrador = 100;
int posicaoAtual = 50;
long contadorZeros = 0;

if (!File.Exists(nomeArquivo))
    return;

string[] instrucoes = File.ReadAllLines(nomeArquivo);

foreach (string linha in File.ReadLines(nomeArquivo))
{
    if (string.IsNullOrWhiteSpace(linha)) continue;

    char direcao = linha[0];
    int distancia = int.Parse(linha[1..]);

    contadorZeros += (distancia / tamanhoMostrador);

    int resto = distancia % tamanhoMostrador;

    if (direcao == 'R')
    {
        if (posicaoAtual + resto >= tamanhoMostrador)
        {
            contadorZeros++;
        }

        posicaoAtual = (posicaoAtual + resto) % tamanhoMostrador;
    }
    else
    {
        if (posicaoAtual > 0 && posicaoAtual - resto <= 0)
        {
            contadorZeros++;
        }

        posicaoAtual = ((posicaoAtual - resto) % tamanhoMostrador + tamanhoMostrador) % tamanhoMostrador;
    }
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Senha da Parte 2 (Total de zeros): {contadorZeros}");
Console.WriteLine("--------------------------------------------------");