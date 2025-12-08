
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;
var lines = File.ReadAllLines(fileName);

int maxLen = lines.Max(l => l.Length);

var colunasVazias = Enumerable.Range(0, maxLen)
    .Where(col => lines.All(line => col >= line.Length || line[col] == ' '))
    .ToHashSet();

var resultado = lines.Select(line => new string(
    line.Select((c, index) => colunasVazias.Contains(index) ? '-' : c).ToArray()
)).ToArray();

var matriz = lines.Select(line =>
    new string(line.Select((c, index) => colunasVazias.Contains(index) ? '-' : c).ToArray())
    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
).ToArray();

long sum = 0;
int totalColunas = matriz[0].Length;
for (int i = 0; i < totalColunas; i++)
{
    var operacao = "";
    var numbers = new char[matriz.Length - 1][];
    var listaInvertido = new List<long>();

    for (int j = 1; j <= matriz.Length; j++)
    {
        if (j == matriz.Length)
        {
            operacao = matriz[j - 1][i].ToString().Trim();
        }
        else 
        {
            var numero = matriz[j - 1][i].ToString();
            numbers[j - 1] = numero.ToCharArray();
        }
    }
    int maiorTamanho = numbers.Max(resultado => resultado.Length);

    for (int k = 0; k < maiorTamanho; k++)
    {
        StringBuilder numeroVertical = new StringBuilder();

        foreach (var linha in numbers)
        {
            if (linha.Length - 1 - k >= 0)
            {
                numeroVertical.Append(linha[linha.Length - 1 - k]);
            }
        }
        listaInvertido.Add(long.Parse(numeroVertical.ToString()));
    }
    sum += ExecuteOperation(listaInvertido, operacao);
}

Console.WriteLine(sum);
long ExecuteOperation(List<long> numbers, string operation)
{
    return operation switch
    {
        "+" => numbers.Sum(),
        "*" => numbers.Aggregate((acc, x) => acc * x),
        _ => throw new InvalidOperationException("Operação inválida")
    };
}