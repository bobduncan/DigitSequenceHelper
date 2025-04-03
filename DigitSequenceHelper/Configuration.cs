using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper
{
    public static class Configuration
    {
        // Order of analysers is important
        public static readonly List<INumberAnalyser> Analysers =
            [
                new GeoMetricNumberAnalyser(),
            
                new MultiplicationNumberAnalyser(),
                new DivisionNumberAnalyser(),

                new SubtractionNumberAnalyser(),
                new AdditionNumberAnalyser(),
            ];
    }
}
