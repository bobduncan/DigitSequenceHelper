using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper
{
    public static class Processsor
    {
        public static IEnumerable<AnalyseResults> Process(List<double> sequence)
        {
            List<AnalyseResults> totalResults = [];

            Configuration.Transformers.ForEach(t =>
            {
                var newSequence = t.Transform(sequence);

                List<AnalyseResults> transformerResults = [];
                Configuration.Analysers.ForEach(a =>
                {
                    var result = a.Analyze(newSequence, transformerResults);
                    transformerResults.Add(result);
                });

                transformerResults.ForEach(r => t.ParseResults(r, sequence));

                totalResults.AddRange(transformerResults);
            });

            return totalResults;
        }
    }
}
