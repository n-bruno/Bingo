// Random Number Generator Class -- 
//    Encapsulates all data and methods associated with the generation of 
//        Random Numbers
//    
//    by Frank Friedman
//        Version 1.1 – July 16, 2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class RNGType {
    private Random RandomObj;

    public RNGType() {
        RandomObj = new Random();
    } 

    // Get Random Value
    // Gets next random value and ensures it is in the correct range for the column
    //    involved
    // Returns a valid random number
    public int getRandomValue(char columnHeader, WindowsFormsApplication1.CalledNumbersList used) {
        int r;   // Random number generated
        switch (columnHeader) {
            case 'B':
                r = getNextUniqueRandomValue(1, 15, used);
                if (r < 1 || r > 15) {
                    MessageBox.Show("Program Error! Selected random number out of range 1-15", "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
                }  // end if
                break;
            case 'I':
                r = getNextUniqueRandomValue(16, 30, used);
                if (r < 16 || r > 30) {
                    MessageBox.Show("Program Error! Selected random number out of range 16-30", "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
                }  // end if
                break;
            case 'N':
                r = getNextUniqueRandomValue(31, 45, used);
                if (r < 31 || r > 45) {
                    MessageBox.Show("Program Error! Selected random number out of range 31-45", "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
                } // end if
                break;
            case 'G':
                r = getNextUniqueRandomValue(46, 60, used);
                if (r < 46 || r > 60) {
                    MessageBox.Show("Program Error! Selected random number out of range 46-60", "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
                } // end if
                break;
            case 'O':
                r = getNextUniqueRandomValue(61, 75, used);
                if (r < 61 || r > 75) {
                    MessageBox.Show("Program Error! Selected random number out of range 61-75", "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
                } // end if
                break;
            default:
                MessageBox.Show("Program Error! Selected Letter no B I N G or O!", "Click to terminate program.", MessageBoxButtons.OK);
                return -1;
        } // end switch
        return r;
    } //  end getRandomValue

    /*
     * Creates the next set of random values (from 1 to diceToBeRolled values)  
     * Changed the class so it doesn't need a global variable class
     */
    public int getNextUniqueRandomValue(int minVal, int maxVal, WindowsFormsApplication1.CalledNumbersList used) {
        used.availableNumbersToCallCheck();

        Boolean isUnique;
        int rn = 0; // random number obtained
                    // Assume number is not unique
        isUnique = false;

        while (isUnique == false) {
            rn = RandomObj.Next(minVal, maxVal);
            if (!used.isNumberUsed(rn)) {
                isUnique = true;
                used.setNumberAsUsed(rn);
            }
        }
        return rn;
    }
}