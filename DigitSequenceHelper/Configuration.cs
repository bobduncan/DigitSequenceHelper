using DigitSequenceHelper.Analysers;
using DigitSequenceHelper.Transformer;

namespace DigitSequenceHelper
{
    public static class Configuration
    {
        // Order of analysers is important
        public static readonly List<INumberAnalyser> Analysers =
            [
                new FibonacciNumberAnalyser(),
                new GeoMetricNumberAnalyser(),
            
                new MultiplicationNumberAnalyser(),
                new DivisionNumberAnalyser(),

                new SubtractionNumberAnalyser(),
                new AdditionNumberAnalyser(),
            ];

        public static readonly List<BaseNumberTransformer> Transformers =
            [
                new DoNothingTransformer(),
                new SplitNumberTransformer(),
                new ReserveNumberTransformer(),
            ];
    }
}
