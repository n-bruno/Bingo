/*
 * Programmer:  Nich Bruno
 * Name:        UsedNumbersList
 * Description: Stores numbers that have already been called
 */

using System;
using System.Windows.Forms;

namespace Bingo
{
    public class CalledNumbersList
    {
        private int ListSize; //max number of values that can be used for the bingo game.
        //I am aware that Professor Friedman suggested this to be constant
        //But I want this program to be flexible for different card sizes.

        public bool[] UsedNumberObj;
        private int counterSize; //stores the amount of numbers that have been called

        public CalledNumbersList(int RNGRange)
        {
            ListSize = RNGRange;                    //for this project it is 75

            UsedNumberObj = new bool[RNGRange + 1];
            //the number 0 is never used 
            //'+ 1' accounts for not counting 0
            //To be fair accounting for the fact that free space is used is pointless
            //and doesn't affect the program accept storing another int.

            counterSize = 0;
        }

        //report if a number is used or not
        public bool IsNumberUsed(int checkNumber)
        { return UsedNumberObj[checkNumber]; }

        //Stores a number as used
        public void SetNumberAsUsed(int setNumber)
        {
            UsedNumberObj[setNumber] = true;
            counterSize++; //increment counter
        }

        //Check if exhausted all possible numbers
        public void AvailableNumbersToCallCheck()
        {
            //Check if all numbers are called
            if (counterSize == ListSize - 1)
            {
                MessageBox.Show("Exhausted all possible numbers. Terminating program.", "Error");
                Environment.Exit(0);
                //Terminate the program for an error that should never happen
            }
        }

        //Print all index values (DEBUG PURPOSES)
        public void PrintUsedNumbers()
        {
            for (int i = 0; i <= ListSize; i++)
                Console.WriteLine("Number : " + i + " is " + (UsedNumberObj[i] ? "" : "un") + "used");
            Console.WriteLine("Numbers recorded as used : " + counterSize);
        }
    }
}