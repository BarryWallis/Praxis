using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalculator.Model
{
    public class Calculator
    {
        private Stack<double> stack = new Stack<double>();

        /// <summary>
        /// The top of the Calculator's stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">There are no operands top operate on.</exception>
        public double Top { get => stack.Peek(); }

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
        public void Push(double number) => stack.Push(number);

        /// <summary>
        /// Pop the two top numbers and push the result of applying the operator on the stack.
        /// </summary>
        /// <param name="op">The Operator to apply to the top two numbers on the stack.</param>
        /// <exception cref="InvalidOperationException">Operator needs two arguments.</exception>
        /// <exception cref="ArgumentException"><paramref name="op"/> must be a valid operator.</exception>
        public void Calculate(RpnOperator op)
        {
            if (stack.Count() < 2)
                throw new InvalidOperationException("Operator needs two arguments");

            switch (op)
            {
                case RpnOperator.Add:
                    stack.Push(Add(stack.Pop(), stack.Pop()));
                    break;
                case RpnOperator.Subtract:
                    stack.Push(Subtract(stack.Pop(), stack.Pop()));
                    break;
                case RpnOperator.Multiply:
                    stack.Push(Multiply(stack.Pop(), stack.Pop()));
                    break;
                case RpnOperator.Divide:
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
        private static double Add(double operand2, double operand1) => operand1 + operand2;

        /// <summary>
        /// Return the difference of operand1 + operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The difference of operand1 - operand 2.</returns>
        private static double Subtract(double operand2, double operand1) => operand1 - operand2;

        /// <summary>
        /// Return the product of operand1 * operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The product of operand1 * operand 2.</returns>
        private static double Multiply(double operand2, double operand1) => operand1 * operand2;

        /// <summary>
        /// Return the quotient of operand1 / operand 2.
        /// </summary>
        /// <param name="operand2">The right-hand operator.</param>
        /// <param name="operand1">The left-hand operator.</param>
        /// <returns>The product of operand1 / operand 2.</returns>
        private static double Divide(double operand2, double operand1) => operand1 / operand2;
    }
}