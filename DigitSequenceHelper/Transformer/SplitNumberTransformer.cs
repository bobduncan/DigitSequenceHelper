using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Transformer
{
    public class SplitNumberTransformer : BaseNumberTransformer
    {
        public override List<double> Transform(List<double> sequence)
        {
            List<double> result = [];
            int startIndex = sequence.Count - 2;//-1 from 0-based index, andother -1 to get the secondlast item.

            for (int i = startIndex; i >= 0; i -= 2)
            {
                result.Insert(0, sequence[i]); // insert at front to preserve order
            }

            return result;
        }

        /// <summary>
        /// Fill up the empty spots with null. 
        /// e.g. a numbersequence of 1, 600, 3, 600, 5, 600, ?
        /// The next number will be 7, but it has nothing to do with the 600's in between.
        /// However due to the transformer, the 600's will be removed, so the results will be based on 1, 3, 5, ?
        /// But the end user will see visually see the 600's in the input, so ensure it will look like:
        /// +2, null, +2, null, +2
        /// </summary>
        /// <param name="results"></param>
        /// <param name="sequence"></param>
        public override void ParseResults(AnalyseResults results, List<double> sequence)
        {
            if (results.Results == null) return;

            List<AnalyseResult> newResultsList = [.. new AnalyseResult[sequence.Count]];
            int index = sequence.Count - 2;

            foreach (var value in results.Results)
            {
                newResultsList[index] = value;
                index -= 2;
            }
            newResultsList = newResultsList.Skip(1).ToList();
            results.OperationName = "Split" + results.Analyser?.OperationName;
            results.Results = newResultsList;
        }
    }
}
