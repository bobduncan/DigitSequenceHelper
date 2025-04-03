using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Tests.Analysers
{
    [TestClass]
    public class GeoMetricNumberAnalyserTests
    {
        #region GCD

        [TestMethod]
        public void GCD_WithValidNumbers_ReturnsCorrectGCD()
        {
            // Arrange
            var numbers = new List<int> { 3, 9, 27, 81 };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GCD_WithValidNumbersReverse_ReturnsCorrectGCD()
        {
            // Arrange
            var numbers = new List<int> { 81, 27, 9, 3 };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GCD_WithInvalid_ReturnsOne()
        {
            // Arrange
            var numbers = new List<int> { 4, 8, 9 };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GCD_WithSingleNumber_ReturnsSameNumber()
        {
            // Arrange
            var numbers = new List<int> { 3 };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GCD_EmptyList_ReturnsNull()
        {
            // Arrange
            var numbers = new List<int> { };

            // Act
            int? result = GeoMetricNumberAnalyser.GCD(numbers);

            // Assert
            Assert.AreEqual(null, result);
        }

        #endregion

        #region GetExponent

        [TestMethod]
        public void GetExponent_WithBase3AndNumber9_Returns2()
        {
            // Arrange
            int baseValue = 3;
            int number = 9;

            // Act
            int result = GeoMetricNumberAnalyser.GetExponent(baseValue, number);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetExponent_WithBase3AndNumber27_Returns3()
        {
            // Arrange
            int baseValue = 3;
            int number = 27;

            // Act
            int result = GeoMetricNumberAnalyser.GetExponent(baseValue, number);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetExponent_WithBase3AndNumber10_ReturnsNegative1()
        {
            // Arrange
            int baseValue = 3;
            int number = 10;

            // Act
            int result = GeoMetricNumberAnalyser.GetExponent(baseValue, number);

            // Assert
            Assert.AreEqual(-1, result);
        }

        #endregion
    }
}
