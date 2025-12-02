using System.Diagnostics;

const string inputFileName = "input.txt";
const int dialSize = 100;
int currentPosition = 50;
int zeroCount = 0;

if (!File.Exists(inputFileName))
    return;

string[] rotations = File.ReadAllLines(inputFileName);

foreach (string line in rotations)
{
    if (string.IsNullOrWhiteSpace(line)) continue;

    char direction = line[0];
    int distance = int.Parse(line[1..]);

    if (direction == 'R')
        currentPosition = (currentPosition + distance) % dialSize;
    else if (direction == 'L')
        currentPosition = ((currentPosition - distance) % dialSize + dialSize) % dialSize;

    if (currentPosition == 0)
        zeroCount++;
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"A senha (vezes que parou no 0) é: {zeroCount}");
Console.WriteLine("--------------------------------------------------");