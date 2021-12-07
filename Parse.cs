// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public static class Parse
{
    public static IEnumerable<int> IntegerList(string input)
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

    public static List<Command> StringIntegerCommands(string input)
    {
        var asStrings = input.Split(Environment.NewLine);
        var commands = new List<Command>();

        for (var i = 0; i < asStrings.Count(); i++)
        {
            var direction = asStrings[i].Split(" ").First();
            var distance = asStrings[i].Split(" ").Last();

            commands.Add(new Command(direction, Int32.Parse(distance)));
        }

        return commands;
    }
}