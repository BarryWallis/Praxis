using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoSimulator.Model
{
    public sealed class BingoManager
    {
        private static BingoManager instance;
        public static BingoManager Instance => instance = instance ?? new BingoManager();

        /// <summary>
        /// Create a new BingoManager.
        /// </summary>
        private BingoManager()
        {

        }

        /// <summary>
        /// Play a game with the given BingoCards and return the number of numbers called when a Bingo is made.
        /// </summary>
        /// <param name="bingoCards">A collection of BingoCards.</param>
        /// <returns>The number of calls when the first Bingo was made.</returns>
        public int PlayGameWithCards(IEnumerable<BingoCard> bingoCards)
        {
            if (bingoCards is null)
                throw new ArgumentNullException(nameof(bingoCards));

            IList<int> bingoBalls = InitializeBingoBalls();
            for (int i = 0; i < bingoBalls.Count(); i++)
            {
                foreach (BingoCard bingoCard in bingoCards)
                {
                    if (bingoCard.Mark(bingoBalls[i]))
                        return i;
                }
            }

            Debug.Fail("All Bingo balls called but no Bingo found");
            return 0;
        }

        /// <summary>
        /// Play the given number of games with the bingo cards and return the average number of Bingo balls called for each game. You can register an event to get the number of Bingo balls called for each game, if desired.
        /// </summary>
        /// <param name="numberOfGames">The number of games to play.</param>
        /// <param name="numberOfBingoCards">The number of Bingo cards to play for each game.</param>
        /// <returns></returns>
        public int PlayGamesWithCards(int numberOfGames, int numberOfBingoCards)
        {
            BingoCard[] bingoCards = new BingoCard[numberOfBingoCards];

            int total = 0;
            for (int game = 0; game < numberOfGames; game++)
            {
                InitializeBingoCards(bingoCards);
                total += PlayGameWithCards(bingoCards);
            }

            return total / numberOfGames;
        }

        /// <summary>
        /// Initialize the given list with new BingoCards.
        /// </summary>
        /// <param name="bingoCards">The list to initialize.</param>
        private static void InitializeBingoCards(IList<BingoCard> bingoCards)
        {
            for (int i = 0; i < bingoCards.Count(); i++)
                bingoCards[i] = new BingoCard();
        }

        /// <summary>
        /// Randomize the order of the Bingo numbers called.
        /// </summary>
        private static IList<int> InitializeBingoBalls()
        {
            int[] bingoBalls = new int[BingoCard.MaxColumns * BingoCard.NumbersPerColumn];
            for (int i = 0; i < bingoBalls.Length; i++)
            {
                bingoBalls[i] = i + 1;
            }

            Random random = new Random();
            for (int i = 0; i < bingoBalls.Length; i++)
            {
                int swap = bingoBalls[i];
                int position = random.Next(bingoBalls.Length);
                bingoBalls[i] = bingoBalls[position];
                bingoBalls[position] = swap;
            }

            return bingoBalls;
        }
    }
}
