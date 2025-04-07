namespace DigitSequenceHelper.Analysers
{
    public abstract class BaseNumberAnalyser : INumberAnalyser
    {
        public virtual AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults)
        {
            if (numbers == null || numbers.Count < 2) return new AnalyseResults
            {
                Analyser = this,
                Input = numbers!,
                IsMatch = false,
                Results = null
            };

            var results = new List<AnalyseResult?>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var result = Analyse(numbers[i], numbers[i + 1]);
                results.Add(result);
            }

            var finalResult = new AnalyseResults
            {
                Analyser = this,
                Input = numbers,
                IsMatch = results != null,
                Results = results!
            };

            var predictedNumber = PredictNumber(finalResult);
            if (predictedNumber != null) finalResult.PredictedNumber = predictedNumber;

            return finalResult;
        }

        public virtual double? PredictNumber(AnalyseResults result)
        {
            if (result.IsMatch
                && result.Results != null
                && result.Results.Count != 0
                && result.Results.All(x => x != null)
                && result.Results.All(x => x.Value == result.Results[0]!.Value))
            {
                var modifier = result.Results[0]!.Value;
                return PredictNumber(result.Input.Last(), modifier);
            }
            return null;
        }

        public abstract double? PredictNumber(double? previousNumber, double? modifier);


        public abstract AnalyseResult? Analyse(double a, double b);

        public abstract string NumberPrefix { get; }
        public abstract string OperationName { get; set; }
    }
}