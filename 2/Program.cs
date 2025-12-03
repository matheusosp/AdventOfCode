using System;
using System.IO;

const string fileName = "input.txt";

if (!File.Exists(fileName))
    return;

string[] lines = File.ReadAllLines(fileName);

string[] ranges = lines[0].Split(',');
long sum = 0;
foreach (string range in ranges)
{
    string[] parts = range.Split("-");
    long start = long.Parse(parts[0]);
    long end = long.Parse(parts[1]);

    for (long i = start; i <= end; i++)
    {
        var numberStr = i.ToString();
        if (numberStr.Length % 2 == 0)
        {
            string firstHalf = numberStr.Substring(0, numberStr.Length / 2);
            string secondHalf = numberStr.Substring(numberStr.Length / 2);
            if (firstHalf == secondHalf)
            {
                sum += i;
            }
        }
    }
}
Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Part 2 Password (Total numbers with equal halves): {sum}");
Console.WriteLine("--------------------------------------------------");