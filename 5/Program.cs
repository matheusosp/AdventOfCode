const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;

long sum = 0;

List<Intervalo> regrasDeValidade = new List<Intervalo>();
var listaIds = new List<long>();
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
    else if (line.All(char.IsDigit))
    {
        listaIds.Add(long.Parse(line));
    }
}


foreach (var id in listaIds)
{
    if (regrasDeValidade.Any(regra => id >= regra.Inicio && id <= regra.Fim))
    {
        sum++;
    }
}
Console.WriteLine(sum);
public class Intervalo
{
    public long Inicio { get; set; }
    public long Fim { get; set; }
}