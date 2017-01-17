using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoSimulator.Model
{
    public class BingoCard
    {
        private Random random = new Random();
        private Space[,] card = new Space[5, 5];

        public static int MaxRows { get; } = 5;
        public static int MaxColumns { get; } = 5;
        public static int NumbersPerColumn { get; } = 15;

        /// <summary>
        /// Create a BingoCard.
        /// </summary>
        public BingoCard()
        {
            Debug.Assert(MaxRows > 0);
            Debug.Assert(MaxColumns > 0);
            Debug.Assert(NumbersPerColumn >=MaxColumns);

            for (int row = 0; row < MaxRows; row++)
            {
                int firstNumber = row * NumbersPerColumn + 1;
                for (int column = 0; column < MaxColumns; column++)
                {
                    int n;
                    do
                    {
                        n = random.Next(firstNumber, firstNumber + NumbersPerColumn);
                    } while (CardContains(n));
                    card[row, column].Number = n;
                    card[row, column].IsMarked = false;
                }
            }
            card[(MaxRows) / 2, (MaxColumns) / 2].IsMarked = true;
        }

        /// <summary>
        /// Return a copy of the Card.
        /// </summary>
        /// <returns>A copy of the Card. </returns>
        public Space[,] GetCard() => (Space[,])card.Clone();

        /// <summary>
        /// Return true if the card contains the given number.
        /// </summary>
        /// <param name="number">The number to search for.</param>
        /// <returns>True if the card contains the number; otherwise false.</returns>
        private bool CardContains(int number)
        {
            Debug.Assert(card != null);

            bool cardContains = false;
            foreach (Space space in card)
            {
                if (space.Number == number)
                {
                    cardContains = true;
                    break;
                }
            }
            return cardContains;
        }

        /// <summary>
        /// If the given number is on the card, mark it and check for Bingo.
        /// </summary>
        /// <param name="number">The number to check for.</param>
        /// <returns>True if the card has a Bingo; otherwise false.</returns>
        public bool Mark(int number)
        {
            Debug.Assert(MaxColumns > 0);
            Debug.Assert(MaxRows > 0);
            Debug.Assert(card != null);

            if (number < 1 || number > NumbersPerColumn * MaxColumns)
                throw new ArgumentOutOfRangeException(nameof(number), $"Must be between 1 and {NumbersPerColumn * MaxColumns}");

            for (int row = 0; row < MaxRows; row++)
            {
                for (int column = 0; column < MaxColumns; column++)
                {
                    if (card[row, column].Number == number)
                    {
                        card[row, column].IsMarked = true;
                        return CheckForBingo();
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the card has a Bingo.
        /// </summary>
        /// <returns>True if there is a Bingo; otherwise false.</returns>
        private bool CheckForBingo() => CheckColumns() || CheckRows() || CheckDiagonals();

        /// <summary>
        /// Check each column for Bingo.
        /// </summary>
        /// <returns>True if any column has a Bingo; otherwise false.</returns>
        private bool CheckColumns()
        {
            Debug.Assert(MaxColumns > 0);
            Debug.Assert(MaxRows > 0);
            Debug.Assert(card != null);

            for (int column = 0; column < MaxColumns; column++)
            {
                int total = 0;
                for (int row = 0; row < MaxRows; row++)
                {
                    total += card[row, column].IsMarked ? 1 : 0;
                }
                if (total == MaxRows)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Check each row for Bingo.
        /// </summary>
        /// <returns>True if any row has a Bingo; otherwise false.</returns>
        private bool CheckRows()
        {
            Debug.Assert(MaxColumns > 0);
            Debug.Assert(MaxRows > 0);
            Debug.Assert(card != null);

            for (int row = 0; row < MaxRows; row++)
            {
                int total = 0;
                for (int column = 0; column < MaxColumns; column++)
                {
                    total += card[row, column].IsMarked ? 1 : 0;
                }
                if (total == MaxColumns)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check each diagonal for Bingo.
        /// </summary>
        /// <returns>True if either diagonal has a Bingo; otherwise false.</returns>
        private bool CheckDiagonals()
        {
            Debug.Assert(MaxRows > 0);
            Debug.Assert(card != null);

            int total1 = 0;
            int total2 = 0;
            for (int i = 0; i < MaxRows; i++)
            {
                total1 += card[i, i].IsMarked ? 1 : 0;
                total2 += card[MaxRows - i - 1, i].IsMarked ? 1 : 0;
            }
            return total1 == MaxRows || total2 == MaxRows;
        }
    }
}
