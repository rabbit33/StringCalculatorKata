using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private StringCalculator stringCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            var validators = new List<BaseNumbersValidator>
            {
                new PositiveNumbersValidator(t => t < 0, new NegativesNotAllowedException("Negatives not allowed"))
            };

            stringCalculator = new StringCalculator(validators);    
        }

        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            string numbers = "";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(0, actualResult);
        }

        [TestMethod]
        public void Add_OneNumber_ReturnsTheNumber()
        {
            string numbers = "1";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(1, actualResult);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsTheSum()
        {
            string numbers = "1,2";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(3, actualResult);
        }

        [TestMethod]
        public void Add_UnknownAmountOfNumbers_ReturnsTheSum()
        {
            string numbers = "1,2,3,4,5";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(15, actualResult);
        }

        [TestMethod]
        public void Add_NewLineDelimiters_ReturnsTheSum()
        {
            string numbers = "1\n2,3";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(6, actualResult);
        }
        
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Add_TwoConsecutiveDelimiters_ThrowsException()
        {
            string numbers = "1,\n2,3";

            stringCalculator.Add(numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Add_DelimitersAtTheEndOfTheString_ThrowsException()
        {
            string numbers = "1,\n";

            stringCalculator.Add(numbers);
        }

        [TestMethod]
        public void Add_DelimiterSpecifiedAtTheBegginingOfInputString_ReturnsSum()
        {
            string numbers = "//;\n1;2";

            int actualResult = stringCalculator.Add(numbers);

            Assert.AreEqual(3, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void Add_NegativeNumbers_ThrowsException()
        {
            string numbers = "1,-2";

            stringCalculator.Add(numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void Add_NegativeNumbers_MessageContainsNegativeNumbers()
        {
            string numbers = "1,-2,3,-5";

            try
            {
                stringCalculator.Add(numbers);
            }
            catch (NegativesNotAllowedException e)
            {
                Assert.AreEqual("Negatives not allowed: -2,-5", e.Message);
                throw;
            }
        }

    }
}