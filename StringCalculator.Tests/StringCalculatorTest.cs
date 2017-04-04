using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void EmptyStringTest()
        {
            var numbers = string.Empty;
            var result = Calculator.Add(numbers);
            Assert.AreEqual(0,result);
        }

        [TestMethod]
        public void OneNumberTest()
        {
            var numbers = "1";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TwoNumbersTest()
        {
            var numbers = "3,4";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void MultipleNumbersTest()
        {
            var numbers = "3,4,8";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void NewLineDelimeterTest()
        {
            var numbers = "3\n4\n8";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void DifferentDelimetersTest()
        {
            var numbers = "//;\n3;4;8";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void NegativeNumbersThrowExeptionTest()
        {
            var numbers = "//;\n3;-4;8;-12";
            var exceptionMessage = "Negatives not allowed: -4, -12";
               
            var exception = Assert.ThrowsException<NegativesNotAllowedException>(
                                            () => Calculator.Add(numbers));

            Assert.AreEqual(exceptionMessage,exception.Message);
        }

        [TestMethod]
        public void BiggerThan1000AreIgnoredTest()
        {
            var numbers = "//;\n3;1003;4;8;2048";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void MultiplecharDelimetersAreAllowed()
        {
            var numbers = "//[***]\n3***1003***4***8***2048";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void MultipleDifferentDelimetersAreAllowed()
        {
            var numbers = "//[*][%]\n1*2%3";
            var result = Calculator.Add(numbers);
            Assert.AreEqual(15, result);
        }

    }
}
