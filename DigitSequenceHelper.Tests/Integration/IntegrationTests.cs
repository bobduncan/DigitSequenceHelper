using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Tests.Integration
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Integration_Additive_AddingWith2()
        {
            // Arrange
            var sequence = new List<double> { 2, 4, 6, 8 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(10, matchedResult!.PredictedNumber);
            Assert.AreEqual(new AdditionNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_Subtractive_SubtractingWith2()
        {
            // Arrange
            var sequence = new List<double> { 10, 8, 6, 4 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(2, matchedResult!.PredictedNumber);
            Assert.AreEqual(new SubtractionNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_Multiplicative_MultipliedBy2()
        {
            // Arrange
            var sequence = new List<double> { 10, 20, 40 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(80, matchedResult!.PredictedNumber);
            Assert.AreEqual(new MultiplicationNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_Division_DividedBy2()
        {
            // Arrange
            var sequence = new List<double> { 120, 60, 30 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(15, matchedResult!.PredictedNumber);
            Assert.AreEqual(new DivisionNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_GeometricSequence_PowerOf3()
        {
            // Arrange
            var sequence = new List<double> { 1, 4, 13, 40 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(121, matchedResult!.PredictedNumber);
            Assert.AreEqual(new GeoMetricNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_Fibbonaci()
        {
            // Arrange
            var sequence = new List<double> { 1, 1, 2, 3, 5 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(8, matchedResult!.PredictedNumber);
            Assert.AreEqual(new FibonacciNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_OddList_Addition()
        {
            // Arrange
            var sequence = new List<double> { 1, 600, 3, 600, 5, 600, 7, 600};

            // Act

            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(9, matchedResult!.PredictedNumber);
            Assert.AreEqual("Split" + new AdditionNumberAnalyser().OperationName, matchedResult.OperationName);
        }

        [TestMethod]
        public void Integration_EvenList_Constant()
        {
            // Arrange
            var sequence = new List<double> { 1, 600, 3, 600, 5, 600, 7 };

            // Act

            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(600, matchedResult!.PredictedNumber);
        }

        [TestMethod]
        public void Integration_Combination_Plus3Minus1()
        {
            // Arrange
            var sequence = new List<double> { 1, 4, 3, 6, 5 };

            // Act
            var results = Processsor.Process(sequence);
            var matchedResult = results.FirstOrDefault(x => x.PredictedNumber != null);

            // Assert
            Assert.AreEqual(8, matchedResult!.PredictedNumber);
            Assert.AreEqual(new CombinationNumberAnalyser().OperationName, matchedResult.OperationName);
        }
    }
}
