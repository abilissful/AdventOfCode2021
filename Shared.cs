// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public static class Shared
{
    public static IEnumerable<int> ParseIntegerInput(string input)
    {
        var numbers = new List<int>();

        var stringNumbers = Regex.Split(input, @"\D+");
        foreach (var value in stringNumbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var number = int.Parse(value);
                numbers.Add(number);
            }
        }

        return numbers;
    }
}