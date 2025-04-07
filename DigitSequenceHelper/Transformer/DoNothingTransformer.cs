namespace DigitSequenceHelper.Transformer
{
    public class DoNothingTransformer : BaseNumberTransformer
    {
        public override List<double> Transform(List<double> sequence)
        {
            return sequence;
        }
    }
}
