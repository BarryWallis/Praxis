using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BingoSimulator.Model;

namespace BingoSimulator.ViewModel
{
    public class BingoSimulatorViewModel : INotifyPropertyChanged
    {
        private int numberOfGamesTextBox;
        public int NumberOfGamesTextBox
        {
            get { return numberOfGamesTextBox; }
            set
            {
                if (value <= 0)
                {
                    System.Windows.MessageBox.Show("Number of games must be greater than zero", "Bingo Simulator");
                    return;
                }

                numberOfGamesTextBox = value;
                NotifyPropertyChanged();
            }
        }

        private int numberOfBingoCardsTextBox;
        public int NumberOfBingoCardsTextBox
        {
            get { return numberOfBingoCardsTextBox; }
            set
            {
                if (value <= 0)
                {
                    MessageBox.Show("Number of Bingo cards must be greater than zero", "Bingo Simulator");
                    return;
                }

                numberOfBingoCardsTextBox = value;
                NotifyPropertyChanged();
            }
        }

        private int averageNumberOfBallsPulledTextBox;
        public int AverageNumberOfBallsPulledTextBox
        {
            get { return averageNumberOfBallsPulledTextBox; }
            set
            {
                averageNumberOfBallsPulledTextBox = value;
                NotifyPropertyChanged();
            }
        }

        private string ballsPulledForEachGameTextBox;
        public string BallsPulledForEachGameTextBox
        {
            get { return ballsPulledForEachGameTextBox; }
            set
            {
                ballsPulledForEachGameTextBox = value;
                NotifyPropertyChanged();
            }
        }

        public BingoSimulatorViewModel() => BingoManager.Instance.OnBingoGameFinished += new EventHandler<BingoGameFinishedEventArgs>(GameFinished);

        private void GameFinished(object sender, BingoGameFinishedEventArgs e) => BallsPulledForEachGameTextBox += $"{e.NumberOfBallsCalled} ";

        /// <summary>
        /// Play the number of games using the given number of cards.
        /// </summary>
        public void Play()
        {
            BallsPulledForEachGameTextBox = "";
            AverageNumberOfBallsPulledTextBox = BingoManager.Instance.PlayGamesWithCards(numberOfGamesTextBox, NumberOfBingoCardsTextBox);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
