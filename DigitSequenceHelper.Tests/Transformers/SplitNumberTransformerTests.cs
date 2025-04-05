using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitSequenceHelper.Analysers;
using DigitSequenceHelper.Transformer;

namespace DigitSequenceHelper.Tests.Transformers
{
    [TestClass]
    public class SplitNumberTransformerTests
    {
        [TestMethod]
        public void SplitNumberTransformer_WithEvenList()
        {
            // Arrange
            var numbers = new List<double> { 1, 2, 3, 4, 5 };

            // Act
            var result = new SplitNumberTransformer().Transform(numbers);

            // Assert
            CollectionAssert.AreEqual(new List<double>() { 2, 4 }, result);
        }

        [TestMethod]
        public void SplitNumberTransformer_WithOddList()
        {
            // Arrange
            var numbers = new List<double> { 1, 2, 3, 4, 5, 6 };

            // Act
            var result = new SplitNumberTransformer().Transform(numbers);

            // Assert
            CollectionAssert.AreEqual(new List<double>() { 1, 3, 5 }, result);
        }
    }
}
