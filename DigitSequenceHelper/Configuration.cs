﻿using DigitSequenceHelper.Analysers;
using DigitSequenceHelper.Transformer;

namespace DigitSequenceHelper
{
    public static class Configuration
    {
        // Order of analysers is important
        public static readonly List<INumberAnalyser> Analysers =
            [
                new AdditionNumberAnalyser(),
                new SubtractionNumberAnalyser(),

                new MultiplicationNumberAnalyser(),
                new DivisionNumberAnalyser(),

                new FibonacciNumberAnalyser(),
                new GeoMetricNumberAnalyser(), 
            ];

        public static readonly List<BaseNumberTransformer> Transformers =
            [
                new DoNothingTransformer(),
                new SplitNumberTransformer(),
                new ReserveNumberTransformer(),
            ];
    }
}
