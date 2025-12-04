const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;

var lines = File.ReadAllLines(fileName).Select(x => x.ToCharArray()).ToArray();

var alcancaveis = new List<(int, int)>();
var qtdAlcancaveis = 0;
do
{
    alcancaveis = GetAlcancaveis(lines);
    foreach (var (x, y) in alcancaveis)
    {
        lines[x][y] = '.';
        qtdAlcancaveis++;
    }

}
while (alcancaveis.Count > 0);

Console.WriteLine($"Alcancaveis: {qtdAlcancaveis}");

IEnumerable<(int, int)> GetPosicaoVizinho(int rowVetor, int rowCasa)
{
    yield return (rowVetor - 1, rowCasa - 1);
    yield return (rowVetor - 1, rowCasa);
    yield return (rowVetor - 1, rowCasa + 1);
    yield return (rowVetor, rowCasa - 1);
    yield return (rowVetor, rowCasa + 1);
    yield return (rowVetor + 1, rowCasa - 1);
    yield return (rowVetor + 1, rowCasa);
    yield return (rowVetor + 1, rowCasa + 1);
};

List<(int, int)> GetAlcancaveis(char[][] lines)
{
    var alcancaveis = new List<(int,int)> { };
    var tamanho = lines.Length;

    for (int i = 0; i < tamanho; i++)
    {
        for (int j = 0; j < tamanho; j++)
        {
            if (lines[i][j] != '@') continue;

            var qtdVizinhos = 0;
            foreach (var viznho in GetPosicaoVizinho(i, j))
            {
                int rowVetor = viznho.Item1;
                int rowCasa = viznho.Item2;
                if (rowVetor < 0 || rowCasa < 0 || rowVetor >= tamanho || rowCasa >= tamanho)
                    continue;
                var valorVizinho = lines[rowVetor][rowCasa];

                if (valorVizinho == '@')
                    qtdVizinhos++;
            }
            if (qtdVizinhos < 4)
            {
                alcancaveis.Add((i,j));
            }

        }
    }

    return alcancaveis;
}