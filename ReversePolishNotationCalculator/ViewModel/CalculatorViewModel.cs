using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReversePolishNotationCalculator.Model;

namespace ReversePolishNotationCalculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private Calculator calculator = new Calculator();

        private string expression;
        public string Expression
        {
            get => expression;
            set
            {
                if (expression != value)
                {
                    expression = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private float result;
        public float Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Evaluate the Expression.
        /// </summary>
        public void Evaluate()
        {
            IEnumerable<object> items = Parse();
            foreach (object item in items)
            {
                switch (item)
                {
                    case float number:
                        calculator.Push(number);
                        break;
                    case CalculatorOperator op:
                        calculator.Calculate(op);
                        break;
                    default:
                        Debug.Fail("Invalid item type");
                        break;
                }

                Result = calculator.Top;
            }
        }

        /// <summary>
        /// Clear the calculator.
        /// </summary>
        public void Clear() => calculator = new Calculator();

        /// <summary>
        /// Parse the Expression into doubles and CalculatorOperators.
        /// </summary>
        /// <returns>An array of doubles and CalculatorOperators.</returns>
        private IEnumerable<object> Parse()
        {
            Dictionary<char, CalculatorOperator> mappings = new Dictionary<char, CalculatorOperator>
            {
                ['+'] = CalculatorOperator.Add,
                ['-'] = CalculatorOperator.Subtract,
                ['*'] = CalculatorOperator.Multiply,
                ['/'] = CalculatorOperator.Divide
            };
            StringBuilder parsedString = new StringBuilder();

            foreach (char c in expression)
            {
                if (mappings.ContainsKey(c))
                    parsedString.Append($" {c} ");
                else
                    parsedString.Append(c);
            }

            List<object> results = new List<object>();
            string[] items = parsedString.ToString().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                if (float.TryParse(item, out float number))
                    results.Add(number);
                else if (mappings.ContainsKey(item[0]))
                    results.Add(mappings[item[0]]);
                else
                    throw new InvalidOperationException($"Invalid string / char: {item}");
            }

            return results;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
