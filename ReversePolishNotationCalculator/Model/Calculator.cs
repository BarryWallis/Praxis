using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotationCalculator.Model
{
    public class Calculator
    {
        private Stack<float> stack = new Stack<float>();

        /// <summary>
        /// The top of the Calculator's stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">There are no operands top operate on.</exception>
        public float Top { get => stack.Peek(); }

        /// <summary>
        /// Create a new Calculator.
        /// </summary>
        public Calculator()
        {

        }

        /// <summary>
        /// Push a number on the stack.
        /// </summary>
        /// <param name="number">The number to push</param>
        public void Push(float number) => stack.Push(number);

        /// <summary>
        /// Pop the two top numbers and push the result of applying the operator on the stack.
        /// </summary>
        /// <param name="op">The Operator to apply to the top two numbers on the stack.</param>
        /// <exception cref="InvalidOperationException">Operator needs two arguments.</exception>
        /// <exception cref="ArgumentException"><paramref name="op"/> must be a valid operator.</exception>
        public void Calculate(CalculatorOperator op)
        {
            if (stack.Count() < 2)
                throw new InvalidOperationException("Operator needs two arguments");

            switch (op)
            {
                case CalculatorOperator.Add:
                    stack.Push(Add(stack.Pop(), stack.Pop()));
                    break;
                case CalculatorOperator.Subtract:
                    stack.Push(Subtract(stack.Pop(), stack.Pop()));
                    break;
                case CalculatorOperator.Multiply:
                    stack.Push(Multiply(stack.Pop(), stack.Pop()));
                    break;
                case CalculatorOperator.Divide:
                    stack.Push(Divide(stack.Pop(), stack.Pop()));
                    break;
                default:
                    throw new ArgumentException("Must be a valid Operator", nameof(op));
            }
        }

        /// <summary>
        /// Return the sum of operand1 + operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The sum of operand1 + operand 2.</returns>
        private static float Add(float operand2, float operand1) => operand1 + operand2;

        /// <summary>
        /// Return the difference of operand1 + operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The difference of operand1 - operand 2.</returns>
        private static float Subtract(float operand2, float operand1) => operand1 - operand2;

        /// <summary>
        /// Return the product of operand1 * operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The product of operand1 * operand 2.</returns>
        private static float Multiply(float operand2, float operand1) => operand1 * operand2;

        /// <summary>
        /// Return the quotient of operand1 / operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The product of operand1 / operand 2.</returns>
        private static float Divide(float operand2, float operand1) => operand1 / operand2;
    }
}
