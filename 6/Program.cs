
using static System.Runtime.InteropServices.JavaScript.JSType;

const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;
var lines = File.ReadAllLines(fileName)
    .Where(line => !string.IsNullOrWhiteSpace(line))
    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    .ToArray();

long sum = 0;
int totalColunas = lines[0].Length;
int totalLinhas = lines.Length;
for (int i = 0; i < totalColunas; i++)
{
    var operacao = "";
    var numbers = new List<long>();
    for (int j = 1; j <= lines.Length; j++)
    {
        if (j == lines.Length)
        { 
            operacao = lines[j - 1][i];
        }
        else
            numbers.Add(long.Parse(lines[j - 1][i]));
    }
    sum+= ExecuteOperation(numbers, operacao);
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