/*
 * Programmer:  Nich Bruno
 * Name:        UsedNumbersList
 * Description: Stores numbers that have already been called
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public class CalledNumbersList {
        private int ListSize; //max number of values that can be used for the bingo game.
        //I am aware that Professor Friedman suggested this to be constant
        //But I want this program to be flexible for different card sizes.

        public bool[] UsedNumberObj;
        private int counterSize; //stores the amount of numbers that have been called

        public CalledNumbersList(int RNGRange) {
            ListSize = RNGRange;                    //for this project it is 75

            UsedNumberObj = new bool[RNGRange + 1];
            //the number 0 is never used 
            //'+ 1' accounts for not counting 0
            //To be fair accounting for the fact that free space is used is pointless
            //and doesn't affect the program accept storing another int.

            counterSize = 0;
        }

        //report if a number is used or not
        public bool isNumberUsed(int checkNumber) {
            return UsedNumberObj[checkNumber];
        }

        //Stores a number as used
        public void setNumberAsUsed(int setNumber) {
            UsedNumberObj[setNumber] = true;
            counterSize++; //increment counter
        }

        //Check if exhausted all possible numbers
        public void availableNumbersToCallCheck(){
            if (counterSize == ListSize - 1) { //Check if all numbers are called
                MessageBox.Show("Exhausted all possible numbers. Terminating program.", "Error");
                Environment.Exit(0);
                //Terminate the program for an error that should never happen
            }
        }

        //Print all index values (DEBUG PURPOSES)
        public void printUsedNumbers() {
            int i = 1;
            string String;

            while(i <= ListSize) {
                if (UsedNumberObj[i] == false)
                    String = "unused";
                else
                    String = "used";

                Console.WriteLine("Number : " + i + " is " + String);
                i++;
            }
            Console.WriteLine("Numbers recorded as used : " + counterSize);
        }
    }
}
