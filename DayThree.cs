public class DayThree
{
    public int GetPowerConsumption(IEnumerable<string> reportLines)
    {
        var results = new DiagnosticReport(reportLines.ToList());
        return results.GetPowerConsumption();

    }
}
public class DiagnosticReport
{
    public DiagnosticReport(List<string> reportLines)
    {
        this.report = reportLines;

        this.gammaRate = string.Empty;
        this.epsilonRate = string.Empty;
        // this.gammaRate = string.Join("", gammaRate);
        // this.epsilonRate = string.Join("", epsilonRate);

        // Console.WriteLine("Creating report with gammaRate of " + gammaRate.ToString());
        // Console.WriteLine("Creating report with epsilon rate of " + epsilonRate.ToString());
    }
    public string gammaRate;
    public string epsilonRate;
    public List<string> report;

    public void RunDiagnostics()
    {
        var gammaRate = new int[report[0].Length];
        var epsilonRate = new int[report[0].Length];

        for (int bit = 0; bit < report[0].Length; bit++)
        {
            var eval = EvaluateLinesForPosition(bit, report);

            if (eval.ZeroCount > eval.OneCount)
            {
                gammaRate[bit] = 0;
                epsilonRate[bit] = 1;
            }
            else
            {
                gammaRate[bit] = 1;
                epsilonRate[bit] = 0;
            }
        }

        this.gammaRate = string.Join("", gammaRate);
        this.epsilonRate = string.Join("", epsilonRate);
    }

    public BitEvaluation EvaluateLinesForPosition(int bit, List<string> report)
    {
        var eval = new BitEvaluation();

        for (var l = 0; l < report.Count(); l++)
        {
            if (report[l][bit] == '0') eval.ZeroCount++;
            if (report[l][bit] == '1') eval.OneCount++;
        }

        // Console.WriteLine("For position " + bit + ", zero count is " + eval.ZeroCount);
        // Console.WriteLine("For position " + bit + ", one count is " + eval.OneCount);

        return eval;
    }

    public int GetPowerConsumption()
    {
        if (string.IsNullOrEmpty(gammaRate) | string.IsNullOrEmpty(epsilonRate))
            RunDiagnostics();

        return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
    }
}

public class BitEvaluation
{
    public int ZeroCount = 0;
    public int OneCount = 0;
}