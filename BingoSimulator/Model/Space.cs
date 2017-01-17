using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoSimulator.Model
{
    public struct Space
    {
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0 || value > 75)
                    throw new InvalidOperationException("Value must be between 1 and 75");
                number = value;
            }
        }

        public bool IsMarked { get; set; }
    }
}
