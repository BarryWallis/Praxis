using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SieveOfErasthones.Model;

namespace SieveOfEratosthenes.ViewModel
{
    public class SieveViewModel : INotifyPropertyChanged
    {
        private int numberTextBox;
        public int NumberTextBox
        {
            get { return numberTextBox; }
            set
            {
                numberTextBox = value;
                NotifyPropertyChanged();
            }
        }

        private string primesTextBlock;
        public string PrimesTextBlock

        {
            get { return primesTextBlock; }
            set
            {
                primesTextBlock = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Evaluate the primes in the NumberTextBox.
        /// </summary>
        public void Evaluate()
        {
            StringBuilder primesText = new StringBuilder();
            IEnumerable<int> primes = Sieve.Calculate(NumberTextBox);
            foreach (int prime in primes)
            {
                primesText.Append(prime).Append(' ');
            }
            PrimesTextBlock = primesText.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
