// Random Number Generator Class -- 
//    Encapsulates all data and methods associated with the generation of 
//        Random Numbers
//    
//    by Frank Friedman
//        Version 1.1 – July 16, 2016
//    modified by Nich Bruno

using System;

namespace Bingo
{
    public class RNGType
    {
        private Random RandomObj;

        public RNGType()
        { RandomObj = new Random(); }

        /* Get Random Value
         * Gets next random value and ensures it is in the correct range for the column
         * involved
         * Returns a valid random number
         */
        public int getRandomValue(char columnHeader, Bingo.CalledNumbersList used)
        {
            int r;   // Random number generated
            switch (columnHeader)
            {
                case 'B': r = getNextUniqueRandomValue(01, 15, used); break;
                case 'I': r = getNextUniqueRandomValue(16, 30, used); break;
                case 'N': r = getNextUniqueRandomValue(31, 45, used); break;
                case 'G': r = getNextUniqueRandomValue(46, 60, used); break;
                case 'O': r = getNextUniqueRandomValue(61, 75, used); break;
                default: throw new ArgumentException("Program Error! Selected Letter no B, I, N, G, or O!");
            }
            return r;
        }

        /*
         * Creates the next set of random values (from 1 to diceToBeRolled values)  
         * Changed the class so it doesn't need a global variable class
         */
        public int getNextUniqueRandomValue(int minVal, int maxVal, Bingo.CalledNumbersList used)
        {
            used.AvailableNumbersToCallCheck();
            int rn = 0; // random number obtained
                        // Assume number is not unique
            for (; ; )
            {
                rn = RandomObj.Next(minVal, maxVal);
                if (!used.IsNumberUsed(rn))
                {
                    used.SetNumberAsUsed(rn);
                    return rn;
                }
            }
        }
    }
}