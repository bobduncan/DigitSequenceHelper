using DigitSequenceHelper.Analysers;

namespace DigitSequenceHelper.Tests.Analysers
{
    [TestClass]
    public  class CombinationNumberAnalyserTests
    {
        #region IsPatternRepeated

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternABAB_Twice()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternAAB_Twice()
        {
            // Arrange
            var pattern = new List<string> { "A", "A", "B", "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternABC_Twice()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "C", "A", "B", "C" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternABAB_OnceIncomplete()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "A", };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternAAB_OnceIncomplete()
        {
            // Arrange
            var pattern = new List<string> { "A", "A", "B", "A"};

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnTrue_ForPatternABC_OnceIncomplete()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "C", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnFalse_ForPatternAB_Once()
        {
            // Arrange
            var pattern = new List<string> { "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnFalse_ForPatternABC_Once()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "C" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPatternRepeated_ShouldReturnFalse_ForPatternAAB_Once()
        {
            // Arrange
            var pattern = new List<string> { "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.IsPatternRepeated(pattern);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region GetFundamentalCycle

        [TestMethod]
        public void GetFundamentalCycle_ForPatternAB_Twice()
        {
            // Arrange
            var pattern = new List<string> { "A", "B", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetFundamentalCycle(pattern);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "A", "B" }, result);
        }

        [TestMethod]
        public void GetFundamentalCycle_ForPatternAB_OnceIncomplete()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "B", "A" };

            // Act
            var result = CombinationNumberAnalyser.GetFundamentalCycle(pattern);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "A", "B" }, result);
        }

        [TestMethod]
        public void GetFundamentalCycle_ForPatternAAB_Twice()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "A", "B", "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetFundamentalCycle(pattern);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "A", "A", "B" }, result);
        }

        #endregion

        #region NextInSequence

        [TestMethod]
        public void NextInSequence_ForPatternAB_Twice()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "B", "A", "B" };
            var oneCycle = new List<string> { "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetNextInSequence(pattern, oneCycle);

            // Assert
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void NextInSequence_ForPatternAB_OnceIncomplete()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "B", "A" };
            var oneCycle = new List<string> { "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetNextInSequence(pattern, oneCycle);

            // Assert
            Assert.AreEqual("B", result);
        }

        [TestMethod]
        public void NextInSequence_ForPatternAAB_Twice()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "A", "B", "A", "A", "B" };
            var oneCycle = new List<string> { "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetNextInSequence(pattern, oneCycle);

            // Assert
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void NextInSequence_ForPatternAAB_OnceIncomplete()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "A", "B", "A" };
            var oneCycle = new List<string> { "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetNextInSequence(pattern, oneCycle);

            // Assert
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void NextInSequence_ForPatternAAB_OnceIncomplete2()
        {
            // Arrange
            //First match is not repeated.
            var pattern = new List<string> { "A", "A", "B", "A", "A" };
            var oneCycle = new List<string> { "A", "A", "B" };

            // Act
            var result = CombinationNumberAnalyser.GetNextInSequence(pattern, oneCycle);

            // Assert
            Assert.AreEqual("B", result);
        }

        #endregion
    }
}
