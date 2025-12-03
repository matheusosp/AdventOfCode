using System;
using System.Text;
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
        var length = numberStr.Length;

        for (int j = 1; j <= length / 2; j++)
        {
            if (length % j == 0)
            {
                var repetitions = length / j;
                string pattern = numberStr.Substring(0, j);
                StringBuilder sb = new StringBuilder();

                for (int k = 0; k < repetitions; k++)
                {
                    sb.Append(pattern);
                }

                if (sb.ToString() == numberStr)
                {
                    sum += i;
                    break; 
                }
            }
        }
    }
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine($"Part 2 Password (Total of numbers with repeating patterns): {sum}");
Console.WriteLine("--------------------------------------------------");