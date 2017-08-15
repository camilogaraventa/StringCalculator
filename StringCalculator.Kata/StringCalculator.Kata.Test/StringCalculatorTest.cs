using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Kata.Test
{
    /// <summary>
    /// Descripción resumida de StringCalculatorTest
    /// </summary>
    [TestClass]
    public class StringCalculatorTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void ReturnsZero_WhenStringEmpty()
        {
            Int32 result = StringCalculator.Add(String.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ReturnsTheSameNumber_WhenUsingOneNumber()
        {
            String numbers = "5";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ReturnsSumOfTwoNumbers_WhenUsingTwoNumbersSeparatedByComma()
        {
            String numbers = "5,2";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void ReturnsSumOfNumbers_WhenUsingFourNumbersSeparatedByComma()
        {
            String numbers = "5,2,6,8";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void ReturnsSumOfNumbers_WhenUsingCommasAndNewLineSeparator()
        {
            String numbers = "5,2\n6,8";
            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void ReturnsSumOfNumbers_WhenUsingCustomDelimiters()
        {
            String numbers = "//:\n1:2:3";
            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ThrowsException_WhenUsingNegativeNumber()
        {
            String numbers = "-2";
            String errorMessage = String.Empty;

            try
            {
                StringCalculator.Add(numbers);
            }
            catch (Exception e )
            {
                errorMessage = e.Message;                
            }

            Assert.IsTrue(errorMessage.Contains("-2"));

        }

        [TestMethod]
        public void ThrowsException_WhenUsingMultipleNegativeNumbers()
        {
            String numbers = "-2,-4,3,-6,2";
            String errorMessage = String.Empty;

            try
            {
                StringCalculator.Add(numbers);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            Assert.IsTrue(errorMessage.Contains("-2, -4, -6"));

        }

        [TestMethod]
        public void ExcludeNumbers_WhenUsingNumbersGreaterThanThousand()
        {
            String numbers = "2,1001";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ReturnSumNumbers_WhenUsingThounsandValue()
        {
            String numbers = "2,1000";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(1002, result);
        }

        [TestMethod]
        public void ReturnSumNumbers_WhenUsingDelimitersOfAnyLenght()
        {
            String numbers = "//[***]\n1***2***3";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ReturnSumNumbers_WhenUsingMultipleCustomDelimiters()
        {
            String numbers = "//[*][&%]\n1*2&%3";

            Int32 result = StringCalculator.Add(numbers);

            Assert.AreEqual(6, result);
        }
    }
}
