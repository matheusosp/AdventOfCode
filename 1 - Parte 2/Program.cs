using System;
using System.IO;

const string fileName = "input2.txt";
const int dialSize = 100;
int currentPosition = 50;
long zeroCount = 0;

if (!File.Exists(fileName))
    return;

string[] instructions = File.ReadAllLines(fileName);

foreach (string line in File.ReadLines(fileName))
{
    if (string.IsNullOrWhiteSpace(line)) continue;

    char direction = line[0];
    int distance = int.Parse(line[1..]);

    zeroCount += (distance / dialSize);

    int remainder = distance % dialSize;

    if (direction == 'R')
    {
        if (currentPosition + remainder >= dialSize)
        {
            zeroCount++;
        }

        currentPosition = (currentPosition + remainder) % dialSize;
    }
    else
    {
        if (currentPosition > 0 && currentPosition - remainder <= 0)
        {
            zeroCount++;
        }

        currentPosition = ((currentPosition - remainder) % dialSize + dialSize) % dialSize;
    }
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Part 2 Password (Total zeros): {zeroCount}");
Console.WriteLine("--------------------------------------------------");