using Ninject.Activation.Caching;
using System.Linq;

namespace DigitSequenceHelper.Analysers
{
    public class CombinationNumberAnalyser : BaseNumberAnalyser
    {
        public override string NumberPrefix => "";
        public override string OperationName { get; set; } = "Combination";



        public override AnalyseResults Analyze(List<double> numbers, List<AnalyseResults> previousResults)
        {
            var result = new AnalyseResults
            {
                Analyser = this,
                Input = numbers,
                IsMatch = false,
            };


            if (previousResults == null || previousResults.Count == 0)
                return result;

            // Strategy, find all analysers for which the first number matches and the analyser has a match at least twice in the entire sequence.
            var allCombinations = FindAllCombinations(numbers, previousResults, 0);

            // Filter out patterns that are not a combination of multiple patterns.
            var filteredCombinations = allCombinations.Where(pattern => !pattern.All(p => {
                return p!.Analyser?.OperationName == pattern[0]!.Analyser?.OperationName;
            }));

            // Filter out combinations that are not actually a pattern, just a combination of mathes.
            // The first match must atleast occur twice in the entire sequence.
            var possiblePatterns = filteredCombinations.Where(pattern => {
                return pattern.Count(p => p!.Analyser?.OperationName == pattern[0]!.Analyser?.OperationName) >= 2;
            });

            // Needs to be actually a pattern and not just a combination of matches.
            var repeatedPatterns = possiblePatterns.Where(pattern =>
            {
                static bool comparer(CombinationAnalyseResults a, CombinationAnalyseResults b)
                {
                    return a.OperationName == b.OperationName && a.SelectedResult == b.SelectedResult;
                }
                return IsPatternRepeated(pattern, comparer);
            });

            //TODO deal with multi patterns.
            var repeatedPattern = repeatedPatterns.FirstOrDefault();
            if (repeatedPattern != null)
            {
                result.IsMatch = true;
                result.Results = repeatedPattern.Select(x => x.SelectedResult).ToList();
                result.PredictedNumber = PredictNumber(result, repeatedPattern);
            }

            return result;
        }

        public static double? PredictNumber(AnalyseResults result, List<CombinationAnalyseResults> repeatedPatterns)
        {
            if (result == null) return null;

            // 1. Find 1 complete pattern.
            var onePatternCycleCount = GetFundamentalCycle(repeatedPatterns.Select(x=> x.OperationName).ToList()).Count;
            var onePatternCycle = result.Results!.Take(onePatternCycleCount).ToList();
            var onePatternCycleWithAnalyser = onePatternCycle.Select((item, index) => repeatedPatterns[index]).ToList();

            // 2. Determine the next operation in the sequence
            var predictedNextOperation = GetNextInSequence(repeatedPatterns, onePatternCycleWithAnalyser);
            if (predictedNextOperation.SelectedResult?.Value == null) return null;

            // 3. Use that analyser and the delta to determine its next number.
            var preditedNumber = predictedNextOperation.Analyser!.PredictNumber(result.Input!.Last(), predictedNextOperation.SelectedResult.Value);
            return preditedNumber;
        }

        public override double? PredictNumber(double? previousNumber, double? modifier)
        {
            throw new NotImplementedException();
        }

        #region Patterns
        public static List<List<CombinationAnalyseResults>> FindAllCombinations(List<double> numbers, List<AnalyseResults> results, int index)
        {
            List<List<CombinationAnalyseResults>> result = [];
            if (index >= numbers.Count) return result;

            var possibleFollowupPatterns = results.Where(
                    x => x.Results != null
                    && x.Results.Count > index
                    && x.Results[index] != null);

            foreach (var possibleFollowupPattern in possibleFollowupPatterns)
            {
                var patterns = FindAllCombinations(numbers, results, index+1);

                if (patterns.Count == 0)
                {
                    patterns.Add([new CombinationAnalyseResults(possibleFollowupPattern, index)]);
                }
                else
                {
                    patterns.ForEach(p => p.Insert(0, new CombinationAnalyseResults(possibleFollowupPattern, index)));
                }
                patterns.ForEach(result.Add);
            }

            return result;
        }

        public static bool IsPatternRepeated<T>(List<T> list, Func<T, T, bool>? areEqual = null)
        {
            areEqual ??= ((x, y) => EqualityComparer<T>.Default.Equals(x, y));

            int n = list.Count;

            for (int patternLength = 1; patternLength < n; patternLength++)
            {
                bool matches = Enumerable.Range(0, n)
                    .All(i => areEqual(list[i], list[i % patternLength]));

                if (matches)
                    return true;
            }

            return false;
        }

        public static List<T> GetFundamentalCycle<T>(List<T> list)
        {
            int n = list.Count;
            // Try every possible cycle length from 1 up to n
            for (int cycleLength = 1; cycleLength <= n; cycleLength++)
            {
                // Check if every element in list matches the pattern defined by the prefix of length cycleLength.
                bool isCycle = Enumerable.Range(0, n)
                    .All(i => EqualityComparer<T>.Default.Equals(list[i], list[i % cycleLength]));

                if (isCycle)
                {
                    // Return the cycle (first cycleLength elements)
                    return list.Take(cycleLength).ToList();
                }
            }
            // If no repeating cycle is found, return an empty list (should not happen if input is a 100% match)
            return [];
        }

        public static T GetNextInSequence<T>(List<T> sequence, List<T> fundamentalCycle)
        {
            // Calculate the index for the next element.
            // The next element corresponds to the element at index: sequence.Count % cycle.Count.
            int nextIndex = sequence.Count % fundamentalCycle.Count;
            return fundamentalCycle[nextIndex];
        }

        #endregion

        public override AnalyseResult? Analyse(double a, double b)
        {
            throw new NotImplementedException();
        }


    }

    public record CombinationAnalyseResults : AnalyseResults
    {
        public int Index { get; set; }
        public AnalyseResult? SelectedResult { get { return this.Results?[this.Index]; } }

        public CombinationAnalyseResults(AnalyseResults result, int index) : this(index)
        {
            this.Analyser = result.Analyser;
            this.Input = result.Input;
            this.IsMatch = result.IsMatch;
            this.Results = result.Results;
            this.PredictedNumber = result.PredictedNumber;
            this.ExtraInfo = result.ExtraInfo;
        }

        public CombinationAnalyseResults(int index)
        {
            this.Index = index;
        }
    }
}
