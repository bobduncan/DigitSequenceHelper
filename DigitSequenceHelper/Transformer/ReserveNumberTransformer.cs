namespace DigitSequenceHelper.Transformer
{
    public class ReserveNumberTransformer : BaseNumberTransformer
    {
        public override List<double> Transform(List<double> sequence)
        {
            sequence.Reverse();
            return sequence;
        }
    }
}
