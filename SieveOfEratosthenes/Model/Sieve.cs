using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfErasthones.Model
{
    static public class Sieve
    {
        static public IEnumerable<int> Calculate(int number)
        {
            List<int> primes = new List<int>() { 2 };
            List<int> ints = InitializeSieve(number);

            while (primes.Last() * primes.Last() <= number)
            {
                ints = ExecuteSieve(primes, ints);
            }

            primes.AddRange(ints);
            return primes;
        }

        /// <summary>
        /// Remove the first int and add it to the end of the <paramref name="primes"/>, then remove all mutliples of the removed int and return the result.
        /// </summary>
        /// <param name="primes">The current list of primes.</param>
        /// <param name="ints">The list of integers with all the multiples of the currently found primes removed.</param>
        /// <returns></returns>
        private static List<int> ExecuteSieve(List<int> primes, List<int> ints)
        {
            primes.Add(ints[0]);
            ints.RemoveAt(0);
            List<int> newints = new List<int>();
            for (int i = 0; i < ints.Count(); i++)
            {
                if (ints[i] % primes.Last() != 0)
                    newints.Add(ints[i]);
            }
            ints = newints;
            return ints;
        }

        /// <summary>
        /// Inititalize the sieve with all possible primes. 
        /// </summary>
        /// <param name="number">The number to find the highest prime less than or equal to.</param>
        /// <returns>The initialized list of integers.</returns>
        private static List<int> InitializeSieve(int number)
        {
            List<int> ints = new List<int>();
            for (int i = 3; i <= number; i += 2)
            {
                ints.Add(i);
            }

            return ints;
        }
    }
}