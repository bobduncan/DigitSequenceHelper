using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Transformer
{
    public abstract class BaseNumberTransformer
    {
        public abstract List<double> Transform(List<double> sequence);

        public virtual void ParseResults(AnalyseResults results, List<double> sequence)
        {
        }
    }
}