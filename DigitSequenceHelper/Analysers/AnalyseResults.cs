namespace DigitSequenceHelper.Analysers
{
    public record AnalyseResults
    {
        public INumberAnalyser? Analyser { get; set; }
        public bool IsMatch { get; set; }

        public List<double>? Input { get; set; }
        public List<AnalyseResult>? Results { get; set; }

        public double? PredictedNumber { get; set; }

        public object? ExtraInfo { get; set; }

        private string? _operationName;
        public string? OperationName
        {
            get => _operationName ??= this.Analyser?.OperationName;
            set => _operationName = value;
        }
    }

    public record AnalyseResult
    {
        public AnalyseResult(double? value, string? displayValue)
        {
            this.Value = value;
            this.DisplayValue = displayValue;
        }

        public double? Value { get; set; }

        public string? DisplayValue { get; set; }
    }
}