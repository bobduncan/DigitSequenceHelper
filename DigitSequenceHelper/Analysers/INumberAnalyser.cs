namespace DigitSequenceHelper.Analysers
{
    public interface INumberAnalyser
    {
        AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults);
        AnalyseResult? Analyse(double a, double b);
        string NumberPrefix { get; }
        string OperationName { get; set; }
    }
}