namespace DigitSequenceHelper.Analysers
{
    public interface INumberAnalyser
    {
        AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults);
        AnalyseResult? Analyse(double a, double b);
        double? PredictNumber(double? previousNumber, double? modifier);
        string NumberPrefix { get; }
        string OperationName { get; set; }
    }
}