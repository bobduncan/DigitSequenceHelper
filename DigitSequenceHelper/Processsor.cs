using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper
{
    public static class Processsor
    {
        public static IEnumerable<AnalyseResults> Process(List<double> sequence)
        {
            var totalResults = Configuration.Analysers.Select(a =>
            {
                return a.Analyze(sequence);
            }).ToList();

            Configuration.Transformers.ForEach(t =>
            {
                var newSequence = t.Transform(sequence);
                var results = Configuration.Analysers.Select(a =>
                {
                    return a.Analyze(newSequence);
                }).ToList();

                results.ForEach(r => t.ParseResults(r, sequence));

                totalResults.AddRange(results);
            });

            

            return totalResults;
        }
    }
}
