
using Google.Protobuf.WellKnownTypes;
using System.Text;

namespace DigitSequenceHelper.Analysers
{
    public class GeoMetricNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "^";
        public override string OperationName { get; set; } = "Geometric";

        public override AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults)
        {
            var result = new AnalyseResults
            {
                Analyser = this,
                Input = numbers,
                IsMatch = false,
                Results = null
            };

            var additionAnalyserResults = previousResults.FirstOrDefault(x => x.Analyser is AdditionNumberAnalyser)
                ?? new AdditionNumberAnalyser().Analyze(numbers, previousResults);
            var deltaValues = additionAnalyserResults?.Results?
                .Where(x => x != null)
                .Select(x => (int)x.Value!)
                .ToList();

            var greatestCommonDenominator = GCD(deltaValues);
            if (greatestCommonDenominator == null && greatestCommonDenominator <= 1)
            {
                return result;
            }

            var displayValues = additionAnalyserResults?.Results?
                .Select(x => {
                    if (x?.Value == null) return null;
                    var exponent = GetExponent(greatestCommonDenominator!.Value, (int)x!.Value);
                    if (exponent == -1) return null;

                    return new AnalyseResult(x!.Value, $"+{greatestCommonDenominator}{ToSuperscript(exponent)}");
                })
                .ToList();

            var finalResult = new AnalyseResults
            {
                Analyser = this,
                Input = numbers,
                IsMatch = additionAnalyserResults!.IsMatch,
                Results = displayValues!,
                ExtraInfo = greatestCommonDenominator!
            };

            var predictedNumber = PredictNumber(finalResult);
            if (predictedNumber != null) finalResult.PredictedNumber = predictedNumber;

            return finalResult;
        }
        public override AnalyseResult? Analyse(double a, double b)
        {
            return null;
        }

        public override double? PredictNumber(AnalyseResults result)
        {
            if (result.IsMatch
                && result.Results != null
                && result.Results.Count != 0
                && result.Results.All(x => x != null)
                // Since you get the delta between numbers, you dont want each number to be the same as the exponent to be 1.
                && result.Results.Any(x => x.Value != result.Results[0]!.Value))
            {
                int gcd = (int)result.ExtraInfo!;

                // If the module is 0, it means that the numbers are multiples of the gcd.
                var modifiers = result.Results.Select(x => x.Value % gcd).ToList();
                if (modifiers.All(m => m == 0))
                {
                    var lastDelta = result.Results.Last().Value;
                    var lastExponent = GetExponent(gcd, (int)lastDelta!);
                    var modifier = (int)Math.Pow(gcd, lastExponent+1);


                    var lastValue = result.Input!.Last();
                    return PredictNumber(lastValue, modifier);
                }
            }
            return null;
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            return previousNumber + modifier;
        }




        public static int? GCD(List<int>? numbers)
        {
            if (numbers == null || numbers.Count == 0) return null;

            int gcd = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                gcd = GCDTwoNumbers(gcd, numbers[i]);
            }

            return gcd;
        }

        public static int GCDTwoNumbers(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static int GetExponent(int baseValue, int number)
        {
            if (baseValue <= 1 || number < baseValue)
                return -1;

            int exponent = 1;
            int result = baseValue;

            while (result < number)
            {
                result *= baseValue;
                exponent++;
            }

            return (result == number) ? exponent : -1;
        }

        public static string ToSuperscript(int exponent)
        {
            if (exponent < 0 || exponent > 9) return "?";
            string[] superscripts = ["⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹"];
            StringBuilder sb = new();

            foreach (char digit in exponent.ToString())
            {
                int i = digit - '0';
                sb.Append(superscripts[i]);
            }

            return sb.ToString();
        }
    }
}
