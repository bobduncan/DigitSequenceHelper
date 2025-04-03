namespace DigitSequenceHelper.Analysers
{
    public class AdditionNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "+";
        public override string OperationName => "Add";

        public override AnalyseResult? Analyse(double a, double b)
        {
            var result = b - a;
            return result < 0 ? null : new AnalyseResult(result, $"+{result}");
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            return previousNumber + modifier;
        }
    }
}
