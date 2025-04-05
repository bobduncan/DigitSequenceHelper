namespace DigitSequenceHelper.Analysers
{
    public class MultiplicationNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "x";
        public override string OperationName { get; set; } = "Multiplication";

        public override AnalyseResult? Analyse(double a, double b)
        {
            double product = b / a;
            return product == Math.Round(product) ? new AnalyseResult(product, $"x{product}") : null;
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            return previousNumber * modifier;
        }

    }
}
