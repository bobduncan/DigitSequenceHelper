using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Transformer
{
    public class ReserveNumberTransformer : BaseNumberTransformer
    {
        public override List<double> Transform(List<double> sequence)
        {
            sequence.Reverse();
            return sequence;
        }

        public override void ParseResults(AnalyseResults results, List<double> sequence)
        {
            if (results.Results == null) return;

            results.OperationName = "Reverse" + results.Analyser?.OperationName;
        }
    }
}
