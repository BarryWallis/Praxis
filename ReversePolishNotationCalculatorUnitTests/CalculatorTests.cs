using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversePolishNotationCalculator.Model;

namespace ReversePolishNotationCalculatorUnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ConstructorAndTopThrowsInvalidOperatorException()
        {
            Calculator calculator = new Calculator();
            Assert.ThrowsException<InvalidOperationException>(() => calculator.Top);
        }

        [TestMethod]
        public void PushANumberAndTop()
        {
            Calculator calculator = new Calculator();
            double operand = 123;
            calculator.Push(operand);
            Assert.AreEqual(operand, calculator.Top);
        }

        [TestMethod]
        public void CalculateThrowsInvalidOperationExceptionWhenNoOperandsOnStack()
        {
            Calculator calculator = new Calculator();
            Assert.ThrowsException<InvalidOperationException>(() => calculator.Calculate(CalculatorOperator.Add));
        }

        [TestMethod]
        public void CalculateThrowsInvalidOperationExceptionWhenOneOperandOnStack()
        {
            Calculator calculator = new Calculator();
            double operand = 123;
            calculator.Push(operand);
            Assert.ThrowsException<InvalidOperationException>(() => calculator.Calculate(CalculatorOperator.Add));
        }

        [TestMethod]
        public void CalculateAnInvalidOperatorThrowsArgumentException()
        {
            Calculator calculator = new Calculator();
            double operand1 = 123;
            double operand2 = 456;

            calculator.Push(operand1);
            calculator.Push(operand2);
            CalculatorOperator op = (CalculatorOperator)12;
            Assert.ThrowsException<ArgumentException>(() => calculator.Calculate(op));
        }

        [TestMethod]
        public void CalculateAddReturnsSumOfTopTwoOperands()
        {
            Calculator calculator = new Calculator();
            double operand1 = 123;
            double operand2 = 456;

            calculator.Push(operand1);
            calculator.Push(operand2);
            calculator.Calculate(CalculatorOperator.Add);
            Assert.AreEqual(operand1 + operand2, calculator.Top);
        }

        [TestMethod]
        public void CalculateSubtractReturnsDifferencefTopTwoOperands()
        {
            Calculator calculator = new Calculator();
            double operand1 = 123;
            double operand2 = 456;

            calculator.Push(operand1);
            calculator.Push(operand2);
            calculator.Calculate(CalculatorOperator.Subtract);
            Assert.AreEqual(operand1 - operand2, calculator.Top);
        }

        [TestMethod]
        public void CalculateMultiplyReturnsProductOfTopTwoOperands()
        {
            Calculator calculator = new Calculator();
            double operand1 = 123;
            double operand2 = 456;

            calculator.Push(operand1);
            calculator.Push(operand2);
            calculator.Calculate(CalculatorOperator.Multiply);
            Assert.AreEqual(operand1 * operand2, calculator.Top);
        }

        [TestMethod]
        public void CalculateDivideReturnsQuotientOfTopTwoOperands()
        {
            Calculator calculator = new Calculator();
            double operand1 = 123;
            double operand2 = 456;

            calculator.Push(operand1);
            calculator.Push(operand2);
            calculator.Calculate(CalculatorOperator.Divide);
            Assert.AreEqual(operand1 / operand2, calculator.Top);
        }
    }
}
