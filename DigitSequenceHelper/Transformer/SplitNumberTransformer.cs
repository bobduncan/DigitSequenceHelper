using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Transformer
{
    public class SplitNumberTransformer : BaseNumberTransformer
    {
        public override List<double> Transform(List<double> sequence)
        {
            List<double> result = new();
            int startIndex = sequence.Count - 2;//-1 from 0-based index, andother -1 to get the secondlast item.

            for (int i = startIndex; i >= 0; i -= 2)
            {
                result.Insert(0, sequence[i]); // insert at front to preserve order
            }

            return result;
        }

        public override void ParseResults(AnalyseResults analyseResults, List<double> sequence)
        {
            if (analyseResults.Results == null) return;

            List<AnalyseResult> newResultsList = [.. new AnalyseResult[sequence.Count]];
            int index = sequence.Count - 2;

            foreach (var value in analyseResults.Results)
            {
                newResultsList[index] = value;
                index -= 2;
            }
            newResultsList = newResultsList.Skip(1).ToList();
            //int startIndex = analyseResults.Results.Count - 1;

            //for (int i = startIndex; i >= 0; i--)
            //{
            //    newResultsList.Insert(0, null);
            //    newResultsList.Insert(0, analyseResults.Results[i]);
            //}



            //int startIndex = sequence.Count - 2;

            //for (int i = startIndex; i >= 0; i -= 2)
            //{
            //    newResultsList.Insert(0, null);
            //    newResultsList.Insert(0, newResultsList[i]); // insert at front to preserve order
            //}
            analyseResults.Analyser.OperationName = "Split" + analyseResults.Analyser.OperationName;
            analyseResults.Results = newResultsList;
        }
    }
}
