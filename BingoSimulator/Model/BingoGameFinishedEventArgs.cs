using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoSimulator.Model
{
    public class BingoGameFinishedEventArgs : EventArgs
    {
        public int NumberOfBallsCalled { get; }

        public BingoGameFinishedEventArgs(int numberOfBallsCalled)
        {
            NumberOfBallsCalled = numberOfBallsCalled;
        }
    }
}
