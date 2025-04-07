
using System.Collections.Generic;

namespace DigitSequenceHelper.Analysers
{
    public class FibonacciNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "^";
        public override string OperationName { get; set; } = "Fibonacci";

        public override AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults)
        {
            var result = new AnalyseResults
            {
                Analyser = this,
                Input = numbers,
                IsMatch = false,
                Results = null
            };

            if (numbers.Count < 3) return result;

            for (int i = 2; i < numbers.Count; i++)
            {
                // Check if each number is the sum of the two previous numbers
                if (numbers[i] != numbers[i - 1] + numbers[i - 2])
                    return result;
            }

            result.IsMatch = true;

            var additionAnalyserResults = previousResults.FirstOrDefault(x => x.Analyser is AdditionNumberAnalyser)
                                        ?? new AdditionNumberAnalyser().Analyze(numbers, previousResults);
            result.Results = additionAnalyserResults.Results;

            var predictedNumber = PredictNumber(result);
            if (predictedNumber != null) result.PredictedNumber = predictedNumber;

            return result;
        }

        public override double? PredictNumber(AnalyseResults result)
        {
            return result.Input.TakeLast(2).Sum();
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            throw new NotImplementedException();
        }

        public override AnalyseResult? Analyse(double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}
