namespace DigitSequenceHelper.Analysers
{
    public class DivisionNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "/";
        public override string OperationName => "Division";

        public override AnalyseResult? Analyse(double a, double b)
        {
            double product = a / b;
            return product == Math.Round(product) ? new AnalyseResult(product, $"/{product}") : null;
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            return previousNumber / modifier;
        }

    }
}
