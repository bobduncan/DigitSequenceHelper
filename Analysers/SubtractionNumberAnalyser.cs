namespace DigitSequenceHelper.Analysers
{
    public class SubtractionNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "-";
        public override string OperationName => "Subtract";

        public override AnalyseResult? Analyse(double a, double b)
        {
            var result = a - b;
            return result < 0 ? null : new AnalyseResult(result,$"-{result}");
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            return previousNumber - modifier;
        }
    }
}
