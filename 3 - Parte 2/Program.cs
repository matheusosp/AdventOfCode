using System;
using System.IO;
using System.Linq;

const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;

long sum = 0; 

foreach (string line in File.ReadLines(fileName))
{
    char[] numbers = line.ToArray();

    string currentNumberResult = "";
    int lastIndex = -1; 

    for (int i = 0; i < 12; i++)
    {
        int digitsNeededAfter = 11 - i;

        var nextMax = numbers
            .Take(numbers.Length - digitsNeededAfter)
            .Select((val, index) => new { Value = val, Index = index })
            .Where(x => x.Index > lastIndex)
            .OrderByDescending(x => x.Value)
            .First();

        currentNumberResult += nextMax.Value;
        lastIndex = nextMax.Index;
    }

    sum += long.Parse(currentNumberResult);
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Part 2 Password (Total sum): {sum}");
Console.WriteLine("--------------------------------------------------");