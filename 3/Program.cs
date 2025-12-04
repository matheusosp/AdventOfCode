using System;
using System.IO;

const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;

string[] instructions = File.ReadAllLines(fileName);

int sum = 0;
foreach (string line in File.ReadLines(fileName))
{
    char[] numbers = line.ToArray();

    var numberOneMax = numbers
        .Take(numbers.Length - 1)
        .Select((val, index) => new { Value = val, Index = index })
        .OrderByDescending(x => x.Value)
        .First();
    var indexNumberOneMax = numberOneMax.Index;
    var maxValueNumberOne = numberOneMax.Value;

    char numberTwoMaxFound = numbers.Skip(indexNumberOneMax + 1).Max();
    int numberCombinationMax = int.Parse(maxValueNumberOne.ToString() + numberTwoMaxFound.ToString());

    sum += numberCombinationMax;
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Part 2 Password (Total zeros): {sum}");
Console.WriteLine("--------------------------------------------------");