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
    public class ReserveNumberTransformerTests
    {
        [TestMethod]
        public void ReserveNumberTransformer_Reserve()
        {
            // Arrange
            var numbers = new List<double> { 1, 2, 3, 4, 5 };

            // Act
            var result = new ReserveNumberTransformer().Transform(numbers);

            // Assert
            CollectionAssert.AreEqual(new List<double>() { 5, 4, 3, 2, 1 }, result);
        }
    }
}
