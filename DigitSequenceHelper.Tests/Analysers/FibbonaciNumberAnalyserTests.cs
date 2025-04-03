using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Tests.Analysers
{
    [TestClass]
    public class FibbonaciNumberAnalyserTests
    {
        #region GCD

        [TestMethod]
        public void Fibbonaci_WithValidNumbers_ReturnsCorrectAnswer()
        {
            // Arrange
            var numbers = new List<int> { 3, 9, 27, 81 };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        #endregion

    }
}
